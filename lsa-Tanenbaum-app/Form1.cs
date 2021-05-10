using System;
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
                        SelectCoordinatorOnRingSynchronization();
                        DisplayProcessKnowledgeSection();
                        processesTmpContainer = receivedMessage;

                        MakeNewLineInLog();
                        LogEvent($"LIST: Ring structure obtained \n[{processesTmpContainer}]. ");
                        SendRingList();
                    } else if (receivedMessage.Contains("LIST:") && isRingObtained)
                    {
                        SelectCoordinatorOnRingSynchronization();
                        MakeNewLineInLog();
                        LogEvent("LIST: Ring structure returned.");

                        DisplayProcessKnowledgeSection();

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

        private void DisplayProcessKnowledgeSection() {
            Invoke(new MethodInvoker(() => {
                knowledgeGroupBox.Visible = true;
                knowledgeGroupBox.Text = $"{textProcessName.Text} network knowledge";
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
                ringSynchronizationBtn.Enabled = true;
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
