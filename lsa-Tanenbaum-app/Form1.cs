﻿using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;
using static lsa_Tanenbaum_app.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        Socket sck;
        Random randomizer;

        ASCIIEncoding encoding;

        EndPoint epProcess, epTarget;
        byte[] buffer;  // for sending messages

        bool isConnectionEstablished = false; // for handling simple fields checking with disconnect btn behaviour
        bool isRingObtained = false;
        bool isCoordinatorMessageSend = false;

        List<IPEndPoint> listOfAddresses;
        List<int> listOfPriorities;

        string processesTmpContainer; // variable for particular target - obtaining network structure data
        string message; // other messages (priority update, ping)

        TextBox[] configurationTextBoxes;

        IPEndPoint ringCoordinator;

        private const string CONFIGURATION_HEADER = "CONFIGURATION:";
        private const string ELECTION_HEADER = "ELECTION:";
        private const string COORDINATOR_HEADER = "COORDINATOR:";
        private const string PRIORITY_HEADER = "PRIORITY:";
        private const string LIST_HEADER = "LIST:";
        private const string ICMP_ECHO_REQUEST_HEADER = "ICMP_ECHO_REQUEST:";
        private const string ICMP_ECHO_REPLY_HEADER = "ICMP_ECHO_REPLY:";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            configurationTextBoxes = new TextBox[] {
                textProcessName,
                textProcessIp,
                textProcessPort,
                textTargetIp,
                textTargetPort
            };

            randomizer = new Random();
            encoding = new ASCIIEncoding();
            RandomizeProcessIdentity(textProcessName, randomizer);

            listOfAddresses = new List<IPEndPoint>();
            listOfPriorities = new List<int>();
            processesTmpContainer = CONFIGURATION_HEADER;

            disconnectFromTargetBtn.Enabled = false;

            // get user IP
            textProcessIp.Text = GetLocalAddress();
            textTargetIp.Text = GetLocalAddress();
        }

        // **************************************************
        //
        //            DISTRIBUTED COMMUNICATION
        //
        // **************************************************

        private void MessageCallBack(IAsyncResult result)
        {
            if (true)
            {
                try
                {
                    byte[] receivedData = new byte[1500];
                    receivedData = (byte[])result.AsyncState;

                    // Convert byte[] to string
                    string receivedMessage = UnpackMessage(encoding, receivedData);

                    // callback again
                    buffer = new byte[1500];
                    sck.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(MessageCallBack), buffer);

                    if (receivedMessage.Contains(CONFIGURATION_HEADER))
                    {

                        processesTmpContainer = receivedMessage;

                        if (processesTmpContainer.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            LogEvent("CONF: Synchronization request returned, ring collected.");
                            DisableRingSyncButton();
                            isRingObtained = true;
                            MakeNewLineInLog();
                            UpdateKnowledgeSection(CONFIGURATION_HEADER, processesTmpContainer);
                            SendRingList();
                        }
                        else
                        {
                            DisableRingSyncButton();
                            LogEvent($"CONF: Received synchronization request.");
                            RequestRingSynchronization();
                        }
                    }
                    else if (receivedMessage.Contains(LIST_HEADER) && !isRingObtained)
                    {
                        isRingObtained = true;
                        processesTmpContainer = receivedMessage;
                        UpdateKnowledgeSection(LIST_HEADER, processesTmpContainer);
                        SetupRemainingElementsOfUI($"LIST: Ring structure obtained \n[{processesTmpContainer}]. ");
                        SendRingList();
                    }
                    else if (receivedMessage.Contains(LIST_HEADER) && isRingObtained)
                    {
                        SetupRemainingElementsOfUI("LIST: Ring structure returned.");

                        if (processesTmpContainer != receivedMessage)
                        {
                            processesTmpContainer = receivedMessage;
                            LogEvent("LIST: Changes found! Overwriting ring structure.");
                        }
                        else
                        {
                            LogEvent("LIST: No changes found. Package ignored.");
                        }
                    }
                    else if (receivedMessage.Contains(PRIORITY_HEADER))
                    {
                        MakeNewLineInLog();
                        LogEvent("PRIO request received.");
                        if (receivedMessage.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            LogEvent($"PRIO: Updating knowledge..");
                            UpdatePriorityInListBox(receivedMessage);
                            LogEvent($"PRIO: Request deleted.");
                            MakeNewLineInLog();
                        }
                        else
                        {
                            LogEvent("PRIO: Updating knowledge..");
                            UpdatePriorityInListBox(receivedMessage);
                            LogEvent("PRIO: Sending PRIORITY UPDATE request further.");
                            MakeNewLineInLog();
                            sck.SendTo(receivedData, epTarget);
                        }
                    }
                    else if (receivedMessage.Contains(ICMP_ECHO_REQUEST_HEADER))
                    {
                        if (receivedMessage.Length > 14)
                        {
                            string cutMessage = receivedMessage.Replace(ICMP_ECHO_REQUEST_HEADER, "");
                            LogEvent($"PING: Received ICMP Echo Request from {cutMessage}");
                            AnswerEchoRequest(cutMessage);
                        }
                    }
                    else if (receivedMessage.Contains(ICMP_ECHO_REPLY_HEADER))
                    {
                        if (receivedMessage.Length > 16)
                        {
                            if (receivedMessage.Contains(ringCoordinator.ToString()))
                            {
                                string cutMessage = receivedMessage.Replace(ICMP_ECHO_REPLY_HEADER, "");
                                LogEvent($"PING: Received ICMP Echo Reply from {cutMessage}.");
                                StopDiagnosticPingCoordinatorTimeoutTimer();
                            }
                            else if (receivedMessage.Contains(listOfAddresses[testedNeighbourId].ToString()))
                            {
                                LogEvent($"ELEC: Communication established");
                                isNextAvailableNeighbourFound = true;
                            }
                        }
                    }
                    else if (receivedMessage.Contains(ELECTION_HEADER))
                    {
                        if (receivedMessage.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            LogEvent($"ELEC: Received back election message with data: {receivedMessage}.");

                            // election message returned to the process that initialized it
                            // 1. translate data
                            UpdateKnowledgeSection(ELECTION_HEADER, receivedMessage);
                            // 2. choose leader
                            SelectRingCoordinator();
                            // 3. send COORDINATOR message and new ring structure
                            isCoordinatorMessageSend = true;
                            SendCoordinatorMessage(receivedMessage);
                            LogEvent($"Send coordinator message to other.");
                        }
                        else
                        {
                            // pass election message further
                            LogEvent($"Pass election message further: {receivedMessage}.");
                            ProcessElectionRequest(receivedMessage);
                        }
                    }
                    else if (receivedMessage.Contains(COORDINATOR_HEADER))
                    {
                        if (isCoordinatorMessageSend)
                        {
                            LogEvent($"Coordinator message returned. Removing it.");
                            isCoordinatorMessageSend = false;
                        } else
                        {
                            LogEvent($"Coordinator message received. Updating knowledge and passing it further.");
                            UpdateKnowledgeSection(COORDINATOR_HEADER, receivedMessage);
                            SelectRingCoordinator();
                            SendCoordinatorMessage(receivedMessage);
                        }
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
            sck.SendTo(PackMessage(encoding, coordinatorMessage), nextProcessIPEndPoint);

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

        private void DisplayRemainingGroupBoxes()
        {
            Invoke(new MethodInvoker(() => {
                knowledgeGroupBox.Text = $"{textProcessName.Text} network knowledge";
                knowledgeGroupBox.Visible = true;
                diagnosticPingGroupBox.Visible = true;
            }));
        }

        private void DisableRingSyncButton()
        {
            MethodInvoker inv = delegate
            {
                ringSynchronizationBtn.Enabled = false;
            };

            Invoke(inv);
        }

        private void UpdateLabel(Label label, string text)
        {
            MethodInvoker inv = delegate
            {
                label.Text = text;
            };

            Invoke(inv);
        }

        private void UpdateList<T>(ListBox listBox, List<T> list)
        {
            MethodInvoker inv = delegate
            {
                if (listBox.DataSource != null)
                    listBox.DataSource = new List<T>();

                listBox.DataSource = list;
            };

            Invoke(inv);
        }

        private void UpdateKnowledgeSection(string header, string source)
        {
            (List<IPEndPoint>, List<int>) data = TranslateDataFromMessage(header, source);
            listOfAddresses = data.Item1;
            listOfPriorities = data.Item2;
            UpdateList(addressesListBox, listOfAddresses);
            UpdateList(prioritiesListBox, listOfPriorities);
        }

        private void LogEvent(string text)
        {
            Invoke((Func<string, bool>)logBox.AppendText, text);
        }

        private void MakeNewLineInLog()
        {
            Invoke((Func<bool>)logBox.AppendNewLine);
        }

        // **************************************************
        //
        //                 GUI FUNCTIONS
        //
        // **************************************************

        private Timer diagnosticPingTimer;
        private Timer diagnosticPingCoordinatorTimeoutTimer;
        private Timer diagnosticPingElectionTimeoutTimer;
        private int currentCoordinatorTimeoutTick = 0;
        private int currentElectionTimeoutTick = 0;
        private bool isNextAvailableNeighbourFound = false;
        private int testedNeighbourId;
        private int incrementer = 1;

        private IPEndPoint GetIPOfNextProcess()
        {
            if (listOfAddresses.Count == 2)
                return BuildIPEndPoint(textProcessIp.Text, textProcessPort.Text);

            testedNeighbourId = listOfAddresses.IndexOf(BuildIPEndPoint(textProcessIp.Text, textProcessPort.Text)) + incrementer;

            if (testedNeighbourId >= listOfAddresses.Count)
                testedNeighbourId = 0;

            if (listOfAddresses[testedNeighbourId] == ringCoordinator)
            {
                testedNeighbourId += 1;
            }

            if (testedNeighbourId >= listOfAddresses.Count)
                testedNeighbourId = 0;

            return listOfAddresses[testedNeighbourId];
        }
        
        private async void ProcessElectionRequest(string previousMessage = "")
        {
            while (!isNextAvailableNeighbourFound)
            {
                if (diagnosticPingElectionTimeoutTimer == null)
                {
                    IPEndPoint nextProcessIP = GetIPOfNextProcess();

                    if (nextProcessIP.ToString() == $"{textProcessIp.Text}:{textProcessPort.Text}")
                        break;

                    LogEvent($"ELEC: Trying to communicate with {listOfAddresses[testedNeighbourId]}");
                    InitDiagnosticPingElectionTimeoutTimer();
                    SendEchoRequest(nextProcessIP);
                }
                Application.DoEvents();
            }

            StopDiagnosticPingElectionTimeoutTimer();
            await Task.Delay(1000);

            if (!isNextAvailableNeighbourFound)
            {
                LogEvent($"ELEC: No other available processes found. Can't resolve election :(");
            } else
            {
                if (previousMessage == string.Empty)
                    message = $"{ELECTION_HEADER}|{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";
                else
                    message = $"{previousMessage}|{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";

                isNextAvailableNeighbourFound = false;

                sck.SendTo(PackMessage(encoding, message), listOfAddresses[testedNeighbourId]);
                LogEvent($"ELEC: Election message sent to {listOfAddresses[testedNeighbourId]}");
            }
        }

        private void diagnosticPingElectionTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentElectionTimeoutTick == replyTimeout.Value)
            {
                LogEvent($"ELEC: Connection with {listOfAddresses[testedNeighbourId]} failed.");
                incrementer += 1;
                StopDiagnosticPingElectionTimeoutTimer();
            }
            else
            {
                currentElectionTimeoutTick += 1;
                LogEvent($"ELEC_PING: Waiting for ICMP Echo Reply {currentElectionTimeoutTick}s / {replyTimeout.Value}s.");
            }
        }

        private void InitDiagnosticPingElectionTimeoutTimer()
        {
            LogEvent($"Initialize election ping timeout.");
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

        private void diagnosticPingCoordinatorTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentCoordinatorTimeoutTick == replyTimeout.Value)
            {
                // disable coordinator timeout timer
                StopDiagnosticPingCoordinatorTimeoutTimer();
                // disable diagnostic ping
                deactivateDiagnosticPingBtn_Click(sender, e);
                LogEvent($"PING: ICMP Echo Request timed out. Start election.");
                ProcessElectionRequest();
            }
            else
            {
                currentCoordinatorTimeoutTick += 1;
                LogEvent($"PING: Waiting for ICMP Echo Reply {currentCoordinatorTimeoutTick}s / {replyTimeout.Value}s.");
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

        private void diagnosticPingTimer_Tick(object sender, EventArgs e)
        {
            if (diagnosticPingCoordinatorTimeoutTimer == null)
            {
                SendEchoRequest(ringCoordinator);
                InitDiagnosticPingCoordinatorTimeoutTimer();
                LogEvent($"PING: Send ICMP Echo Request to coordinator.");
            }
        }

        private void InitDiagnosticPingTimer()
        {
            diagnosticPingTimer = new Timer();
            diagnosticPingTimer.Tick += new EventHandler(diagnosticPingTimer_Tick);
            diagnosticPingTimer.Interval = diagnosticPingFrequency.Value < 1 ? 500 : (int) (diagnosticPingFrequency.Value * 1000); // 5 * 1000 = 5000ms (5s)
            diagnosticPingTimer.Start();
        }

        private void activateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            InitDiagnosticPingTimer();
            SwitchTwoButtons(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
        }

        private void deactivateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            if (diagnosticPingTimer != null)
            {
                diagnosticPingTimer.Stop();
                SwitchTwoButtons(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
            }
        }

        private void SetupRemainingElementsOfUI(string logMessage)
        {
            SelectRingCoordinator();
            DisplayRemainingGroupBoxes();
            MakeNewLineInLog();
            LogEvent(logMessage);
            Invoke(new MethodInvoker(() => updatePriorityBtn.Enabled = true));
        }

        private void connectToTargetBtn_Click(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // bind socket
            epProcess = new IPEndPoint(IPAddress.Parse(textProcessIp.Text), Convert.ToInt32(textProcessPort.Text));
            sck.Bind(epProcess);

            // init target
            epTarget = new IPEndPoint(IPAddress.Parse(textTargetIp.Text), Convert.ToInt32(textTargetPort.Text));

            // configure listening
            buffer = new byte[1500];
            sck.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(MessageCallBack), buffer);


            ChangeTextBoxCollectionReadOnlyStatus(configurationTextBoxes);

            LogEvent($"INFO: {textProcessName.Text} connection established.");
            MakeNewLineInLog();

            pictureBoxConnectionStatus.Image = Resources.status_connected;
            labelConnectionStatus.Text = "Connected";
            SwapEnabledForConnectAndDisconnectBtns();

            if (listOfAddresses.Count == 0)
            {
                ringSynchronizationBtn.Enabled = true;
            }

            isConnectionEstablished = true;
        }

        private void disconnectFromTargetBtn_Click(object sender, EventArgs e)
        {
            sck.Shutdown(SocketShutdown.Both);
            sck.Close();
            pictureBoxConnectionStatus.Image = Resources.status_notconnected;
            labelConnectionStatus.Text = "Not Connected";
            SwapEnabledForConnectAndDisconnectBtns();
            isConnectionEstablished = false;
            processConfigChanged(sender, e);

            ChangeTextBoxCollectionReadOnlyStatus(configurationTextBoxes);

            LogEvent($"INFO: {textProcessName.Text} connection closed.");
            MakeNewLineInLog();
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

        private void processConfigChanged(object sender, EventArgs e)
        {
            if (!isConnectionEstablished)
            {
                connectToTargetBtn.Enabled = CheckIfConfigFieldsAreNotEmpty() ? true : false;
            }
        }

        private void callPriorityUpdateBtn_Click(object sender, EventArgs e)
        {
            MakeNewLineInLog();
            LogEvent($"PRIO: Send PRIORITY UPDATE request.");
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
            sck.SendTo(PackMessage(encoding, message), target);
        }

        private void AnswerEchoRequest(string requesterAddress)
        {
            string[] splitRequesterAddress = requesterAddress.Split(':');
            int index = listOfAddresses.IndexOf(BuildIPEndPoint(splitRequesterAddress[0], splitRequesterAddress[1]));
            if (index != -1)
            {
                message = $"{ICMP_ECHO_REPLY_HEADER}{textProcessIp.Text}:{textProcessPort.Text}";
                sck.SendTo(PackMessage(encoding, message), listOfAddresses[index]);
                LogEvent($"PING: Send ICMP Echo Reply to requester({listOfAddresses[index]}).");
            }
        }

        private void SelectRingCoordinator()
        {
            int highestPriorityId = listOfPriorities.IndexOf(listOfPriorities.Max());
            ringCoordinator = listOfAddresses[highestPriorityId];
            UpdateLabel(ringCoordinatorAddressText, ringCoordinator.ToString());
            UpdateLabel(ringCoordinatorPriorityText, $"with priority {listOfPriorities[highestPriorityId]} ({GetCurrentTimeStamp(DateTime.Now)})");
            LogEvent("Coordinator chosen.");
        }

        private string GetLocalAddress()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
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

            processesTmpContainer = RemoveZeroCharactersFromString(processesTmpContainer);

            LogEvent($"CONF: Request network synchronization \n[{processesTmpContainer}].");

            sck.SendTo(PackMessage(encoding, processesTmpContainer), epTarget);
        }

        private void SendRingList()
        {
            processesTmpContainer = processesTmpContainer.Replace(CONFIGURATION_HEADER, LIST_HEADER);
            sck.SendTo(PackMessage(encoding, processesTmpContainer), epTarget);
            LogEvent($"LIST: Pass ring to [{textTargetIp.Text}:{textTargetPort.Text}].");
            MakeNewLineInLog();
        }


        private void SendPriorityUpdatePackage()
        {
            message = $"{PRIORITY_HEADER}{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";
            sck.SendTo(PackMessage(encoding, message), epTarget);
        }

        private void UpdatePriorityInListBox(string message)
        {
            if (message.Length > 6)
            {
                // pattern: PRIO:192....:80:10
                string[] splitMessage = message.Replace(PRIORITY_HEADER, "").Split(':');
                IPEndPoint address = BuildIPEndPoint(splitMessage[0], splitMessage[1]);
                int index = listOfAddresses.IndexOf(address);

                listOfPriorities[index] = Convert.ToInt32(splitMessage[2]);

                UpdateList(prioritiesListBox, listOfPriorities);
            }
        }

        private void SwapEnabledForConnectAndDisconnectBtns()
        {
            connectToTargetBtn.Enabled = !connectToTargetBtn.Enabled;
            disconnectFromTargetBtn.Enabled = !disconnectFromTargetBtn.Enabled;
        }

        private bool CheckIfConfigFieldsAreNotEmpty()
        {
            bool result = true;

            if (configurationTextBoxes != null)
            {
                foreach (TextBox configField in configurationTextBoxes)
                {
                    if (string.IsNullOrWhiteSpace(configField.Text))
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
