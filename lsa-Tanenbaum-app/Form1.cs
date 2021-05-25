using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using lsa_Tanenbaum_app.Structures;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        private const int BUFFER_SIZE = 1500;

        /* Allowed packages headers */
        private const string CONFIGURATION_HEADER = "CONFIGURATION:";
        private const string ELECTION_HEADER = "ELECTION:";
        private const string COORDINATOR_HEADER = "COORDINATOR:";
        private const string PRIORITY_HEADER = "PRIORITY:";
        private const string LIST_HEADER = "LIST:";
        private const string ICMP_ECHO_REQUEST_HEADER = "ICMP_ECHO_REQUEST:";
        private const string ICMP_ECHO_REPLY_HEADER = "ICMP_ECHO_REPLY:";

        private Socket socket;
        private List<IPEndPoint> listOfAddresses;
        private List<int> listOfPriorities;
        private TextBox[] configurationTextBoxes;
        private IPEndPoint ringCoordinatorIP;
        public bool isSocketInitialized = false;

        private HelperMethods helperMethods;

        /* Handlers */

        EndPoint epProcess, epTarget;
        byte[] buffer;

        bool isRingObtained = false; // for callback of the ring synchiornization caller
        bool isCoordinatorMessageSend = false; // for coordinator message initializer 


        string processesTmpContainer; // variable for particular target - obtaining network structure data
        string message; // container for messages (priority update, ping)

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            helperMethods = new HelperMethods();

            configurationTextBoxes = new TextBox[] {
                textProcessName,
                textProcessIp,
                textProcessPort,
                textTargetIp,
                textTargetPort
            };

            helperMethods.RandomizeProcessIdentity(textProcessName);

            listOfAddresses = new List<IPEndPoint>();
            listOfPriorities = new List<int>();
            processesTmpContainer = CONFIGURATION_HEADER;

            stopSocketBtn.Enabled = false;

            // get user IP
            textProcessIp.Text = helperMethods.GetLocalAddress();
            textTargetIp.Text = helperMethods.GetLocalAddress();


            logBox.WriteEvent($"Process {Process.GetCurrentProcess().Id}({textProcessName.Text}) initialized.");
        }

        // **************************************************
        //
        //            DISTRIBUTED COMMUNICATION
        //
        // **************************************************

        private void MessageCallBack(IAsyncResult result)
        {
            if (isSocketInitialized)
            {
                try
                {
                    byte[] receivedData = new byte[BUFFER_SIZE];
                    receivedData = (byte[])result.AsyncState;

                    // Convert byte[] to string
                    string receivedMessage = helperMethods.UnpackMessage(receivedData);

                    // setup callback again
                    buffer = new byte[BUFFER_SIZE];
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(MessageCallBack), buffer);

                    switch (receivedMessage)
                    {
                        case string configurationMessage when receivedMessage.Contains(CONFIGURATION_HEADER):
                            {
                                processesTmpContainer = configurationMessage;

                                if (processesTmpContainer.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                                {
                                    logBox.WriteEvent("Synchronization request returned, ring collected.");
                                    ringSynchronizationBtn.Disable();
                                    isRingObtained = true;
                                    UpdateKnowledgeSection(CONFIGURATION_HEADER, processesTmpContainer);
                                    SendRingList();
                                }
                                else
                                {
                                    ringSynchronizationBtn.Disable();
                                    logBox.WriteEvent($"CONF: Received synchronization request.");
                                    RequestRingSynchronization();
                                }
                            }
                            break;

                        case string listMessage when receivedMessage.Contains(LIST_HEADER) && !isRingObtained:
                            {
                                isRingObtained = true;
                                processesTmpContainer = listMessage;
                                UpdateKnowledgeSection(LIST_HEADER, listMessage);
                                SelectRingCoordinator();
                                UpdateInterfaceOnCompletedRingSynchronization();
                                logBox.WriteEvent($"LIST: Ring structure obtained \n[{processesTmpContainer}]. ");
                                SendRingList();
                            }
                            break;

                        case string listMessage when receivedMessage.Contains(LIST_HEADER) && isRingObtained:
                            {
                                SelectRingCoordinator();
                                UpdateInterfaceOnCompletedRingSynchronization();
                                logBox.BreakLine();
                                logBox.WriteEvent("LIST: Ring structure returned.");

                                if (processesTmpContainer != listMessage)
                                {
                                    processesTmpContainer = listMessage;
                                    logBox.WriteEvent("LIST: Changes found! Overwriting ring structure.");
                                }
                                else
                                {
                                    logBox.WriteEvent("LIST: No changes found. Package ignored.");
                                }
                            }
                            break;

                        case string priorityMessage when receivedMessage.Contains(PRIORITY_HEADER):
                            {
                                logBox.BreakLine();
                                logBox.WriteEvent("PRIO request received.");
                                if (priorityMessage.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                                {
                                    logBox.WriteEvent($"PRIO: Updating knowledge..");
                                    UpdatePriorityInListBox(priorityMessage);
                                    logBox.WriteEvent($"PRIO: Request deleted.");
                                    logBox.BreakLine();
                                }
                                else
                                {
                                    logBox.WriteEvent("PRIO: Updating knowledge..");
                                    UpdatePriorityInListBox(priorityMessage);
                                    logBox.WriteEvent("PRIO: Sending PRIORITY UPDATE request further.");
                                    logBox.BreakLine();
                                    socket.SendTo(receivedData, epTarget);
                                }
                            }
                            break;

                        case string echoRequestMessage when receivedMessage.Contains(ICMP_ECHO_REQUEST_HEADER):
                            {
                                string cutMessage = echoRequestMessage.Replace(ICMP_ECHO_REQUEST_HEADER, "");
                                logBox.WriteEvent($"PING: Received ICMP Echo Request from {cutMessage}");
                                AnswerEchoRequest(cutMessage);
                            }
                            break;

                        case string echopReplyMessage when receivedMessage.Contains(ICMP_ECHO_REPLY_HEADER):
                            {
                                if (echopReplyMessage.Contains(ringCoordinatorIP.ToString()))
                                {
                                    string cutMessage = echopReplyMessage.Replace(ICMP_ECHO_REPLY_HEADER, "");
                                    logBox.WriteEvent($"PING: Received ICMP Echo Reply from {cutMessage}.");
                                    StopDiagnosticPingCoordinatorTimeoutTimer();
                                }
                                else if (echopReplyMessage.Contains(listOfAddresses[testedNeighbourId].ToString()))
                                {
                                    logBox.WriteEvent($"ELEC: Communication established");
                                    isNextAvailableNeighbourFound = true;
                                }
                            }
                            break;

                        case string electionMessage when receivedMessage.Contains(ELECTION_HEADER):
                            {
                                if (electionMessage.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                                {
                                    logBox.WriteEvent($"ELEC: Received back election message with data: {electionMessage}.");

                                    // election message returned to the process that initialized it
                                    // 1. translate data
                                    UpdateKnowledgeSection(ELECTION_HEADER, electionMessage);
                                    // 2. choose leader
                                    SelectRingCoordinator();
                                    // 3. send COORDINATOR message and new ring structure
                                    isCoordinatorMessageSend = true;
                                    SendCoordinatorMessage(electionMessage);
                                    logBox.WriteEvent($"Send coordinator message to other.");
                                }
                                else
                                {
                                    // pass election message further
                                    logBox.WriteEvent($"Pass election message further: {electionMessage}.");
                                    ProcessElectionRequest(electionMessage);
                                }
                            }
                            break;

                        case string coordinatorMessage when receivedMessage.Contains(COORDINATOR_HEADER):
                            {
                                if (isCoordinatorMessageSend)
                                {
                                    UpdateTargetIntel();
                                    logBox.WriteEvent($"Coordinator message returned. Removing it.");
                                    isCoordinatorMessageSend = false;
                                }
                                else
                                {
                                    logBox.WriteEvent($"Coordinator message received. Updating knowledge and passing it further.");
                                    UpdateKnowledgeSection(COORDINATOR_HEADER, coordinatorMessage);
                                    SelectRingCoordinator();
                                    UpdateTargetIntel();
                                    SendCoordinatorMessage(coordinatorMessage);
                                }
                            }
                            break;

                        default:
                            logBox.WriteEvent($"Received message contained header that isn't supported.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void SendCoordinatorMessage(string electionMessage)
        {
            string coordinatorMessage = electionMessage.Replace(ELECTION_HEADER, COORDINATOR_HEADER);
            IPEndPoint nextProcessIPEndPoint = GetNextProcessIPEndPoint();
            socket.SendTo(helperMethods.PackMessage(coordinatorMessage), nextProcessIPEndPoint);

        }

        private IPEndPoint GetNextProcessIPEndPoint()
        {
            int currentProcessId = listOfAddresses.IndexOf((IPEndPoint) epProcess);
            int nextProcessId = currentProcessId + 1;

            if (nextProcessId >= listOfAddresses.Count)
                nextProcessId = 0;

            return listOfAddresses[nextProcessId];
        }

        // **************************************************
        //
        //            THREAD UI UPDATE FUNCTIONS
        //
        // **************************************************

        private void UpdateKnowledgeSection(string header, string source)
        {
            (List<IPEndPoint>, List<int>) data = helperMethods.TranslateDataFromMessage(header, source);
            listOfAddresses = data.Item1;
            listOfPriorities = data.Item2;
            addressesListBox.UpdateCollection(listOfAddresses);
            prioritiesListBox.UpdateCollection(listOfPriorities);
        }

        // **************************************************
        //
        //                    TIMERS
        //
        // **************************************************


        private Timer diagnosticPingCoordinatorTimeoutTimer;
        private Timer diagnosticPingElectionTimeoutTimer;
        private int currentCoordinatorTimeoutTick = 0;
        private int currentElectionTimeoutTick = 0;
        private bool isNextAvailableNeighbourFound = false;
        private int testedNeighbourId;
        private int incrementer = 1;

        #region Diagnostic ping repetition timer

        private Timer diagnosticPingTimer;

        private void diagnosticPingTimer_Tick(object sender, EventArgs e)
        {
            if (diagnosticPingCoordinatorTimeoutTimer == null)
            {
                SendEchoRequest(ringCoordinatorIP);
                InitDiagnosticPingCoordinatorTimeoutTimer();
                logBox.WriteEvent($"PING: Send ICMP Echo Request to coordinator.");
            }
        }

        private void InitDiagnosticPingTimer()
        {
            diagnosticPingTimer = new Timer();
            diagnosticPingTimer.Tick += new EventHandler(diagnosticPingTimer_Tick);
            diagnosticPingTimer.Interval = diagnosticPingFrequency.Value < 1 ? 500 : (int)(diagnosticPingFrequency.Value * 1000); // 5 * 1000 = 5000ms (5s)
            diagnosticPingTimer.Start();
        }

        #endregion

        #region Diagnostic ping coordinator timeout timer

        private void diagnosticPingCoordinatorTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentCoordinatorTimeoutTick == replyTimeout.Value)
            {
                // disable coordinator timeout timer
                StopDiagnosticPingCoordinatorTimeoutTimer();
                // disable diagnostic ping
                deactivateDiagnosticPingBtn_Click(sender, e);
                logBox.WriteEvent($"PING: ICMP Echo Request timed out. Start election.");
                ProcessElectionRequest();
            }
            else
            {
                currentCoordinatorTimeoutTick += 1;
                logBox.WriteEvent($"PING: Waiting for ICMP Echo Reply {currentCoordinatorTimeoutTick}s / {replyTimeout.Value}s.");
            }
        }

        private void InitDiagnosticPingCoordinatorTimeoutTimer()
        {
            diagnosticPingCoordinatorTimeoutTimer = new Timer();
            diagnosticPingCoordinatorTimeoutTimer.Tick += new EventHandler(diagnosticPingCoordinatorTimeoutTimer_Tick);
            diagnosticPingCoordinatorTimeoutTimer.Interval = 1000;
            diagnosticPingCoordinatorTimeoutTimer.Start();
        }

        private void StopDiagnosticPingCoordinatorTimeoutTimer()
        {
            currentCoordinatorTimeoutTick = 0;
            if (diagnosticPingCoordinatorTimeoutTimer != null)
            {
                diagnosticPingCoordinatorTimeoutTimer.Stop();
                diagnosticPingCoordinatorTimeoutTimer = null;
            }
        }

        #endregion

        #region Diagnostic ping election timeout timer

        private void diagnosticPingElectionTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentElectionTimeoutTick == replyTimeout.Value)
            {
                logBox.WriteEvent($"ELEC: Connection with {listOfAddresses[testedNeighbourId]} failed.");
                incrementer += 1;
                StopDiagnosticPingElectionTimeoutTimer();
            }
            else
            {
                currentElectionTimeoutTick += 1;
                logBox.WriteEvent($"ELEC_PING: Waiting for ICMP Echo Reply {currentElectionTimeoutTick}s / {replyTimeout.Value}s.");
            }
        }

        private void InitDiagnosticPingElectionTimeoutTimer()
        {
            diagnosticPingElectionTimeoutTimer = new Timer();
            diagnosticPingElectionTimeoutTimer.Tick += new EventHandler(diagnosticPingElectionTimeoutTimer_Tick);
            diagnosticPingElectionTimeoutTimer.Interval = 1000;
            diagnosticPingElectionTimeoutTimer.Start();
        }

        private void StopDiagnosticPingElectionTimeoutTimer()
        {
            if (diagnosticPingElectionTimeoutTimer != null)
            {
                diagnosticPingElectionTimeoutTimer.Stop();
                diagnosticPingElectionTimeoutTimer = null;
            }
            currentElectionTimeoutTick = 0;
        }

        #endregion

        private IPEndPoint GetIPOfNextProcessOnElectionRequest()
        {
            if (listOfAddresses.Count == 2)
                return helperMethods.BuildIPEndPoint(textProcessIp.Text, textProcessPort.Text);

            testedNeighbourId = listOfAddresses.IndexOf(helperMethods.BuildIPEndPoint(textProcessIp.Text, textProcessPort.Text)) + incrementer;

            if (testedNeighbourId >= listOfAddresses.Count)
            {
                testedNeighbourId -= listOfAddresses.Count;
            }

            if (listOfAddresses[testedNeighbourId] == ringCoordinatorIP)
            {
                logBox.WriteEvent($"{listOfAddresses[testedNeighbourId]} was coordinator so skipping it.");
                testedNeighbourId += 1;
                incrementer += 1;
            }

            if (testedNeighbourId >= listOfAddresses.Count)
            {
                testedNeighbourId -= listOfAddresses.Count;
            }

            return listOfAddresses[testedNeighbourId];
        }
        
        private void ProcessElectionRequest(string previousMessage = "")
        {
            while (!isNextAvailableNeighbourFound)
            {
                if (diagnosticPingElectionTimeoutTimer == null)
                {
                    IPEndPoint nextProcessIP = GetIPOfNextProcessOnElectionRequest();

                    if (nextProcessIP.ToString() == $"{textProcessIp.Text}:{textProcessPort.Text}")
                        break;

                    logBox.WriteEvent($"ELEC: Trying to communicate with {listOfAddresses[testedNeighbourId]}");
                    InitDiagnosticPingElectionTimeoutTimer();
                    SendEchoRequest(nextProcessIP);
                }
                Application.DoEvents();
            }

            StopDiagnosticPingElectionTimeoutTimer();
            incrementer = 1;

            if (!isNextAvailableNeighbourFound)
            {
                logBox.WriteEvent($"ELEC: No other available processes found. Can't resolve election :(");
            } else
            {
                if (previousMessage == string.Empty)
                    message = $"{ELECTION_HEADER}|{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";
                else
                    message = $"{previousMessage}|{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";

                isNextAvailableNeighbourFound = false;

                socket.SendTo(helperMethods.PackMessage(message), listOfAddresses[testedNeighbourId]);
                logBox.WriteEvent($"ELEC: Election message sent to {listOfAddresses[testedNeighbourId]}");
            }
        }


        private void activateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            InitDiagnosticPingTimer();
            helperMethods.SwitchTwoButtonsEnabledStatus(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
        }

        private void deactivateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            if (diagnosticPingTimer != null)
            {
                diagnosticPingTimer.Stop();
                helperMethods.SwitchTwoButtonsEnabledStatus(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
            }
        }

        private void UpdateInterfaceOnCompletedRingSynchronization()
        {
            int highestPriorityId = listOfPriorities.IndexOf(listOfPriorities.Max());
            UpdateRingCoordinatorIntel(highestPriorityId);
            knowledgeGroupBox.SetText($"{textProcessName.Text} network knowledge");
            knowledgeGroupBox.Display();
            diagnosticPingGroupBox.Display();
            HideDiagnosticPingGroupBoxForCoordinator();
            updatePriorityBtn.ReverseEnabledStatus();
        }

        private void UpdateTargetIntel()
        {
            int consequentIndex = listOfAddresses.IndexOf((IPEndPoint) epProcess) + 1;

            if (consequentIndex >= listOfAddresses.Count)
                consequentIndex = 0;

            textTargetIp.SetText(listOfAddresses[consequentIndex].Address.ToString());
            textTargetPort.SetText(listOfAddresses[consequentIndex].Port.ToString());
            epTarget = new IPEndPoint(listOfAddresses[consequentIndex].Address, listOfAddresses[consequentIndex].Port);
        }

        private void ringSynchronizationBtn_Click(object sender, EventArgs e)
        {
            RequestRingSynchronization();
        }

        private void onPriorityTrackBarValueChange(object sender, EventArgs e)
        {
            textPriority.Text = (priorityTrackBar.Value).ToString();
        }

        private void onPriorityTextBoxValueChange(object sender, EventArgs e)
        {
            if (int.TryParse(textPriority.Text, out int result))
            {
                if (result >= 1 && result <= 100)
                    priorityTrackBar.Value = result;
            }
        }

        private void callPriorityUpdateBtn_Click(object sender, EventArgs e)
        {
            logBox.BreakLine();
            logBox.WriteEvent($"PRIO: Send PRIORITY UPDATE request.");
            SendPriorityUpdatePackage();
        }

        // **************************************************
        //
        //               PART FUNCTIONS
        //
        // **************************************************

        private void SendEchoRequest(IPEndPoint target)
        {
            // ICMP_ECHO_REQUEST:FROM
            message = $"{ICMP_ECHO_REQUEST_HEADER}{textProcessIp.Text}:{textProcessPort.Text}";
            socket.SendTo(helperMethods.PackMessage(message), target);
        }

        private void AnswerEchoRequest(string requesterAddress)
        {
            string[] splitRequesterAddress = requesterAddress.Split(':');
            int index = listOfAddresses.IndexOf(helperMethods.BuildIPEndPoint(splitRequesterAddress[0], splitRequesterAddress[1]));
            if (index != -1)
            {
                message = $"{ICMP_ECHO_REPLY_HEADER}{textProcessIp.Text}:{textProcessPort.Text}";
                socket.SendTo(helperMethods.PackMessage(message), listOfAddresses[index]);
                logBox.WriteEvent($"PING: Send ICMP Echo Reply to requester({listOfAddresses[index]}).");
            }
        }

        private void SelectRingCoordinator()
        {
            int highestPriorityId = listOfPriorities.IndexOf(listOfPriorities.Max());
            ringCoordinatorIP = listOfAddresses[highestPriorityId];
            logBox.WriteEvent("Coordinator chosen.");
        }

        private void UpdateRingCoordinatorIntel(int highestPriorityId)
        {
            ringCoordinatorAddressText.SetText(ringCoordinatorIP.ToString());
            ringCoordinatorPriorityText.SetText($"with priority {listOfPriorities[highestPriorityId]} ({helperMethods.GetCurrentTimeStamp(DateTime.Now)})");
        }

        private void HideDiagnosticPingGroupBoxForCoordinator()
        {
            var test = helperMethods.BuildIPEndPoint(textProcessIp.Text, textProcessPort.Text);
            if (ringCoordinatorIP.ToString().Contains(test.ToString()))
            {
                Invoke(new MethodInvoker(() => {
                    diagnosticPingGroupBox.Visible = false;
                    knowledgeGroupBox.Location = new Point(knowledgeGroupBox.Location.X, 200);
                }));
            }
        }

        private void RequestRingSynchronization()
        {
            if (processesTmpContainer == CONFIGURATION_HEADER)
            {
                processesTmpContainer = $"{CONFIGURATION_HEADER}|{textProcessIp.Text}:{textProcessPort.Text}:{Convert.ToInt32(textPriority.Text)}";
            }
            else if (processesTmpContainer.Contains($"{textProcessIp.Text}{textProcessPort.Text}") == false)
            {
                processesTmpContainer = $"{processesTmpContainer}|{textProcessIp.Text}:{textProcessPort.Text}:{Convert.ToInt32(textPriority.Text)}";
            }

            processesTmpContainer = helperMethods.RemoveZeroCharactersFromString(processesTmpContainer);

            logBox.WriteEvent($"CONF: Request network synchronization \n[{processesTmpContainer}].");

            socket.SendTo(helperMethods.PackMessage(processesTmpContainer), epTarget);
        }

        private void SendRingList()
        {
            processesTmpContainer = processesTmpContainer.Replace(CONFIGURATION_HEADER, LIST_HEADER);
            socket.SendTo(helperMethods.PackMessage(processesTmpContainer), epTarget);
            logBox.WriteEvent($"LIST: Pass ring to [{textTargetIp.Text}:{textTargetPort.Text}].");
            logBox.BreakLine();
        }


        private void SendPriorityUpdatePackage()
        {
            message = $"{PRIORITY_HEADER}{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";
            socket.SendTo(helperMethods.PackMessage(message), epTarget);
        }

        private void UpdatePriorityInListBox(string message)
        {
            // pattern: PRIO:192....:80:10
            string[] splitMessage = message.Replace(PRIORITY_HEADER, "").Split(':');
            IPEndPoint address = helperMethods.BuildIPEndPoint(splitMessage[0], splitMessage[1]);
            int index = listOfAddresses.IndexOf(address);

            listOfPriorities[index] = Convert.ToInt32(splitMessage[2]);

            prioritiesListBox.UpdateCollection(listOfPriorities);
        }

        private void initializeSocketBtn_Click(object sender, EventArgs e)
        {
            RawAddress targetRawAddress = new RawAddress(textTargetIp.Text, textTargetPort.Text);

            InitializedSocketResult result = socket.Initialize(
                new EndPoints(epProcess, epTarget),
                new RawAddress(textProcessIp.Text, textProcessPort.Text),
                targetRawAddress);

            socket = result.socket;
            epProcess = result.endPoints.epProcess;
            epTarget = result.endPoints.epTarget;

            // configure listening
            buffer = new byte[BUFFER_SIZE];
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(MessageCallBack), buffer);

            isSocketInitialized = true;

            helperMethods.ChangeTextBoxCollectionReadOnlyStatus(configurationTextBoxes);

            logBox.WriteEvent($"{textProcessName.Text} connection initialization finished.");

            pictureBoxConnectionStatus.Image = Resources.status_connected;

            labelConnectionStatus.SetText("Connected");

            helperMethods.SwitchTwoButtonsEnabledStatus(initializeSocketBtn, stopSocketBtn);

            if (listOfAddresses.Count == 0)
                ringSynchronizationBtn.Enabled = true;
        }

        private void stopSocketBtn_Click(object sender, EventArgs e)
        {
            socket.Stop(ref isSocketInitialized);

            pictureBoxConnectionStatus.SetImage(Resources.status_notconnected);

            labelConnectionStatus.SetText("Not Connected");

            helperMethods.SwitchTwoButtonsEnabledStatus(initializeSocketBtn, stopSocketBtn);

            configTextBoxChanged(sender, e);

            helperMethods.ChangeTextBoxCollectionReadOnlyStatus(configurationTextBoxes);

            logBox.WriteEvent($"{textProcessName.Text} socket closed.");
        }

        /// <summary>Manages button interaction availability by validating if all configuration 
        /// fields are filled in (provided that socket has not been initialized).
        /// </summary>
        private void configTextBoxChanged(object sender, EventArgs e)
        {
            if (!isSocketInitialized)
            {
                initializeSocketBtn.Enabled = helperMethods.CheckIfConfigFieldsAreNotEmpty(configurationTextBoxes);
            }
        }
    }
}
