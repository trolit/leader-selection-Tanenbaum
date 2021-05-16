﻿using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;
using static lsa_Tanenbaum_app.Helpers;
using System.Linq;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        Socket sck;
        Random randomizer;

        ASCIIEncoding encoding;

        EndPoint epProcess, epTarget, epReceiveFrom;
        byte[] buffer;  // for sending messages

        bool isConnectionEstablished = false; // for handling simple fields checking with disconnect btn behaviour
        bool isRingObtained = false;

        List<IPEndPoint> listOfAddresses;
        List<int> listOfPriorities;

        string processesTmpContainer; // variable for particular target - obtaining network structure data
        string message; // other messages (priority update, ping)

        TextBox[] configurationTextBoxes;

        IPEndPoint ringCoordinator;

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
                textTargetPort,
                textReceiveFromIp,
                textReceiveFromPort
            };

            randomizer = new Random();
            encoding = new ASCIIEncoding();
            RandomizeProcessIdentity(textProcessName, randomizer);

            listOfAddresses = new List<IPEndPoint>();
            listOfPriorities = new List<int>();
            processesTmpContainer = "CONF:";

            disconnectFromTargetBtn.Enabled = false;

            // get user IP
            textProcessIp.Text = GetLocalAddress();
            textTargetIp.Text = GetLocalAddress();
            textReceiveFromIp.Text = GetLocalAddress();
        }

        // **************************************************
        //
        //            DISTRIBUTED COMMUNICATION
        //
        // **************************************************

        private void MessageCallBack(IAsyncResult result)
        {
            if (sck.Connected)
            {
                try
                {
                    byte[] receivedData = new byte[1500];
                    receivedData = (byte[])result.AsyncState;

                    // Convert byte[] to string
                    string receivedMessage = UnpackMessage(encoding, receivedData);

                    if (receivedMessage.Contains("CONF:"))
                    {

                        processesTmpContainer = receivedMessage;

                        if (processesTmpContainer.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            LogEvent("CONF: Synchronization request returned, ring collected.");
                            DisableRingSyncButton();
                            isRingObtained = true;
                            MakeNewLineInLog();
                            UpdateKnowledgeSection();
                            SendRingList();
                        } else
                        {
                            DisableRingSyncButton();
                            LogEvent($"CONF: Received synchronization request.");
                            RequestRingSynchronization();
                        }
                    } else if (receivedMessage.Contains("LIST:") && !isRingObtained)
                    {
                        isRingObtained = true;
                        UpdateKnowledgeSection();
                        processesTmpContainer = receivedMessage;
                        SetupRemainingElementsOfUI($"LIST: Ring structure obtained \n[{processesTmpContainer}]. ");
                        SendRingList();
                    } else if (receivedMessage.Contains("LIST:") && isRingObtained)
                    {
                        SetupRemainingElementsOfUI("LIST: Ring structure returned.");

                        if (processesTmpContainer != receivedMessage)
                        {
                            processesTmpContainer = receivedMessage;
                            LogEvent("LIST: Changes found! Overwriting ring structure.");
                        } else
                        {
                            LogEvent("LIST: No changes found. Package ignored.");
                        }
                    } else if (receivedMessage.Contains("PRIO:"))
                    {
                        MakeNewLineInLog();
                        LogEvent("PRIO request received.");
                        if (receivedMessage.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            LogEvent($"PRIO: Updating knowledge..");
                            UpdatePriorityInListBox(receivedMessage);
                            LogEvent($"PRIO: Request deleted.");
                            MakeNewLineInLog();
                        } else
                        {
                            LogEvent("PRIO: Updating knowledge..");
                            UpdatePriorityInListBox(receivedMessage);
                            LogEvent("PRIO: Sending PRIORITY UPDATE request further.");
                            MakeNewLineInLog();
                            sck.SendTo(receivedData, epTarget);
                        }
                    } else if (receivedMessage.Contains("ICMP_ECHO_REQ:"))
                    {
                        if (receivedMessage.Length > 14)
                        {
                            string cutMessage = receivedMessage.Remove(0, 14);
                            LogEvent($"PING: Received ICMP Echo Request from {cutMessage}");
                            AnswerEchoRequest(cutMessage);
                        }
                    }
                    else if (receivedMessage.Contains("ICMP_ECHO_REPLY:"))
                    {
                        if (receivedMessage.Length > 16)
                        {
                            string cutMessage = receivedMessage.Remove(0, 16);

                            if (receivedMessage.Contains(ringCoordinator.ToString()))
                            {
                                LogEvent($"PING: Received ICMP Echo Reply from {cutMessage}.");
                                StopDiagnosticPingTimeoutTimer();
                            }
                            
                            // neighbour can get election message
                            if (cutMessage.Contains(listOfAddresses[testedProcessId].ToString()))
                            {
                                StopDiagnosticPingElectionTimeoutTimer();
                                isNextAvailableNeighbourFound = true;
                            }
                        }
                    }
                    else if (receivedMessage.Contains("ELEC:"))
                    {
                        if (receivedMessage.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            // election message returned to the process that initialized it

                        } else
                        {
                            // pass election message further
                            SendElectionRequest(receivedMessage);
                        }
                    }

                    // callback again
                    buffer = new byte[1500];
                    sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epReceiveFrom, new AsyncCallback(MessageCallBack), buffer);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        // **************************************************
        //
        //            THREAD UI UPDATE FUNCTIONS
        //
        // **************************************************

        private void DisplayRemainingGroupBoxes() {
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

        private void UpdateKnowledgeSection()
        {
            (List<IPEndPoint>, List<int>) data = TranslateDataFromProcessesTmpContainer(processesTmpContainer);
            listOfAddresses = data.Item1;
            listOfPriorities = data.Item2;
            UpdateList(addressesListBox, listOfAddresses);
            UpdateList(prioritiesListBox, listOfPriorities);
        }

        private void LogEvent(string text)
        {
            Invoke((Func<string, bool>) logBox.AppendText, text);
        }

        private void MakeNewLineInLog()
        {
            Invoke((Func<bool>) logBox.AppendNewLine);
        }

        // **************************************************
        //
        //                 GUI FUNCTIONS
        //
        // **************************************************

        private Timer diagnosticPingTimer;
        private Timer diagnosticPingCoordinatorTimeoutTimer;
        private Timer diagnosticPingElectionTimeoutTimer;
        private int currentElectionTimeoutTick = 0;
        private int currentCoordinatorTimeoutTick = 0;
        private bool isNextAvailableNeighbourFound = false;
        private int testedProcessId;
        
        private void SendElectionRequest(string previousMessage = "")
        {
            int testedProcessId = listOfAddresses.IndexOf(BuildIPEndPoint(textProcessIp.Text, textProcessPort.Text)) + 1;
            if (testedProcessId >= listOfAddresses.Count)
                testedProcessId = 0;

            while (!isNextAvailableNeighbourFound)
            {
                if (diagnosticPingElectionTimeoutTimer == null)
                {
                    SendEchoRequest(listOfAddresses[testedProcessId]);
                    InitDiagnosticPingElectionTimeoutTimer();
                }
            }

            if (previousMessage == string.Empty)
                message = $"ELEC:{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";
            else
                message = $"{previousMessage}:{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";

            sck.SendTo(PackMessage(encoding, message), listOfAddresses[testedProcessId]);
        }

        private void diagnosticPingElectionTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentElectionTimeoutTick == replyTimeout.Value && diagnosticPingElectionTimeoutTimer != null)
            {
                testedProcessId += 1;
                if (testedProcessId >= listOfAddresses.Count)
                    testedProcessId = 0;
                StopDiagnosticPingElectionTimeoutTimer();
            }
            else
            {
                currentCoordinatorTimeoutTick += 1;
                LogEvent($"ELEC_PING: Waiting for ICMP Echo Reply {currentElectionTimeoutTick}s / {replyTimeout.Value}s.");
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
            currentElectionTimeoutTick = 0;
            if (diagnosticPingElectionTimeoutTimer != null)
            {
                diagnosticPingElectionTimeoutTimer.Stop();
                diagnosticPingElectionTimeoutTimer = null;
            }
        }

        private void diagnosticPingCoordinatorTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentCoordinatorTimeoutTick == replyTimeout.Value && diagnosticPingCoordinatorTimeoutTimer != null)
            {
                StopDiagnosticPingTimeoutTimer();
                LogEvent($"PING: ICMP Echo Request timed out. Start election.");
                deactivateDiagnosticPingBtn_Click(sender, e);

                SendElectionRequest();
            } else
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

        private void StopDiagnosticPingTimeoutTimer()
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
            enableDiagnosticPingBtn.Enabled = false;
            disableDiagnosticPingBtn.Enabled = true;
        }

        private void deactivateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            if (diagnosticPingTimer != null)
            {
                diagnosticPingTimer.Stop();
                disableDiagnosticPingBtn.Enabled = false;
                enableDiagnosticPingBtn.Enabled = true;
            }
        }

        private void SetupRemainingElementsOfUI(string logMessage)
        {
            SelectCoordinatorOnRingSynchronization();
            DisplayRemainingGroupBoxes();
            MakeNewLineInLog();
            LogEvent(logMessage);
            Invoke(new MethodInvoker(() => updatePriorityBtn.Enabled = true));
        }

        private void connectToTargetBtn_Click(object sender, EventArgs e)
        {
            // init socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // bind socket
            epProcess = new IPEndPoint(IPAddress.Parse(textProcessIp.Text), Convert.ToInt32(textProcessPort.Text));
            sck.Bind(epProcess);

            // init target
            epTarget = new IPEndPoint(IPAddress.Parse(textTargetIp.Text), Convert.ToInt32(textTargetPort.Text));

            // connect 
            epReceiveFrom = new IPEndPoint(IPAddress.Parse(textReceiveFromIp.Text), Convert.ToInt32(textReceiveFromPort.Text));

            sck.Connect(epReceiveFrom);

            // configure listening
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epReceiveFrom, new AsyncCallback(MessageCallBack), buffer);

            if (sck.Connected)
            {
                ChangeTextBoxCollectionReadOnlyStatus(configurationTextBoxes);

                LogEvent($"INFO: {textProcessName.Text} connection established.");
                MakeNewLineInLog();

                pictureBoxConnectionStatus.Image = Resources.status_connected;
                labelConnectionStatus.Text = "Connected";
                SwapEnabledForConnectAndDisconnectBtns();

                if (listOfAddresses.Count == 0) {
                    ringSynchronizationBtn.Enabled = true;
                }
                
                isConnectionEstablished = true;
            }
            else
            {
                MessageBox.Show("Connection request failed!!");
            }
        }

        private void disconnectFromTargetBtn_Click(object sender, EventArgs e)
        {
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
            message = $"ICMP_ECHO_REQ:{textProcessIp.Text}:{textProcessPort.Text}";
            sck.SendTo(PackMessage(encoding, message), target);
        }

        private void AnswerEchoRequest(string requesterAddress)
        {
            string[] splitRequesterAddress = requesterAddress.Split(':');
            int index = listOfAddresses.IndexOf(BuildIPEndPoint(splitRequesterAddress[0], splitRequesterAddress[1]));
            if (index != -1)
            {
                message = $"ICMP_ECHO_REPLY:{textProcessIp.Text}:{textProcessPort.Text}";
                sck.SendTo(PackMessage(encoding, message), listOfAddresses[index]);
                LogEvent($"PING: Send ICMP Echo Reply to requester({listOfAddresses[index]}).");
            }
        }

        private void SelectCoordinatorOnRingSynchronization()
        {
            int highestPriorityId = listOfPriorities.IndexOf(listOfPriorities.Max());
            ringCoordinator = listOfAddresses[highestPriorityId];
            UpdateLabel(ringCoordinatorAddressText, ringCoordinator.ToString());
            UpdateLabel(ringCoordinatorPriorityText, $"with priority {listOfPriorities[highestPriorityId]} ({GetCurrentTimeStamp(DateTime.Now)})");
            LogEvent("LIST: Initial coordinator chosen.");
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
            if (processesTmpContainer == "CONF:") {
                processesTmpContainer = $"CONF:|{textProcessIp.Text}:{textProcessPort.Text}:{Convert.ToInt32(textPriority.Text)}";
            } 
            else if (processesTmpContainer.Contains($"{textProcessIp.Text}{textProcessPort.Text}") == false) {
                processesTmpContainer = $"{processesTmpContainer}|{textProcessIp.Text}:{textProcessPort.Text}:{Convert.ToInt32(textPriority.Text)}";
            }

            processesTmpContainer = RemoveZeroCharactersFromString(processesTmpContainer);

            LogEvent($"CONF: Request network synchronization \n[{processesTmpContainer}].");

            sck.SendTo(PackMessage(encoding, processesTmpContainer), epTarget);
        }

        private void SendRingList()
        {
            processesTmpContainer = processesTmpContainer.Replace("CONF:", "LIST:");
            sck.SendTo(PackMessage(encoding, processesTmpContainer), epTarget);
            LogEvent($"LIST: Pass ring to [{textTargetIp.Text}:{textTargetPort.Text}].");
            MakeNewLineInLog();
        }


        private void SendPriorityUpdatePackage()
        {
            message = $"PRIO:{textProcessIp.Text}:{textProcessPort.Text}:{textPriority.Text}";
            sck.SendTo(PackMessage(encoding, message), epTarget);
        }

        private void UpdatePriorityInListBox(string message)
        {
            if (message.Length > 6)
            {
                // pattern: PRIO:192....:80:10
                string[] splitMessage = message.Remove(0, 5).Split(':');
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
