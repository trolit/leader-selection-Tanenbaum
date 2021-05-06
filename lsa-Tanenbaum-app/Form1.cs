using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;
using static lsa_Tanenbaum_app.Helpers;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        Socket sck;
        Random randomizer;
        DateTime date = DateTime.Now;

        ASCIIEncoding encoding;

        EndPoint epProcess, epTarget, epReceiveFrom;
        byte[] buffer;  // for sending messages

        bool isConnectionEstablished = false; // for handling simple fields checking with disconnect btn behaviour
        bool isRingObtained = false;

        List<string> listOfAllProcesses;
        List<int> listOfProcessesPriorities;
        
        string processesTmpContainer;

        TextBox[] configurationTextBoxes;

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

            listOfAllProcesses = new List<string>();
            listOfProcessesPriorities = new List<int>();
            processesTmpContainer = "CONF:";

            disconnectFromTargetBtn.Enabled = false;

            // get user IP
            textProcessIp.Text = GetLocalAddress();
            textTargetIp.Text = GetLocalAddress();
            textReceiveFromIp.Text = GetLocalAddress();
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

                LogEvent($"{textProcessName.Text} connection established.");
                MakeNewLineInLog();

                knowledgeGroupBox.Visible = true;
                knowledgeGroupBox.Text = $"{textProcessName.Text} knowledge";

                listOfAllProcesses.Add(textProcessName.Text);
                pictureBoxConnectionStatus.Image = Resources.status_connected;
                labelConnectionStatus.Text = "Connected";
                SwapEnabledForConnectAndDisconnectBtns();
                ringSynchronizationBtn.Enabled = true;
                isConnectionEstablished = true;
            } else
            {
                MessageBox.Show("Connection request failed!!");
            }      
        }

        private void LogEvent(string text)
        {
            Invoke((Func<DateTime, string, bool>) logBox.AppendText, date, text);
        }

        private void MakeNewLineInLog()
        {
            Invoke((Func<bool>) logBox.AppendNewLine);
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

            LogEvent($"{textProcessName.Text} connection closed.");
            MakeNewLineInLog();
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

        private void MessageCallBack(IAsyncResult result)
        {
            if (sck.Connected)
            {
                try
                {
                    byte[] receivedData = new byte[1500];
                    receivedData = (byte[])result.AsyncState;

                    // Convert byte[] to string
                    string receivedMessage = RemoveZeroCharactersFromString(encoding.GetString(receivedData));

                    if (receivedMessage.Contains("CONF:"))
                    {
                        // Add message to the console
                        LogEvent($"Received synchronization request.");
                        MakeNewLineInLog();

                        processesTmpContainer = receivedMessage;

                        // callback again
                        buffer = new byte[1500];
                        sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epReceiveFrom, new AsyncCallback(MessageCallBack), buffer);

                        if (processesTmpContainer.Contains($"{textProcessIp.Text}:{textProcessPort.Text}"))
                        {
                            isRingObtained = true;
                            LogEvent("Ring structure completed!");
                            (List<IPEndPoint>, List<int>) x = TranslateDataFromProcessesTmpContainer(processesTmpContainer);
                            UpdateList(addressesListBox, x.Item1);
                            UpdateList(prioritiesListBox, x.Item2);

                            SendRingList();
                        } else
                        {
                            RequestRingSynchronization();
                        }
                    } else if (receivedMessage.Contains("LIST:") && !isRingObtained)
                    {
                        isRingObtained = true;
                        (List<IPEndPoint>, List<int>) x = TranslateDataFromProcessesTmpContainer(processesTmpContainer);
                        UpdateList(addressesListBox, x.Item1);
                        UpdateList(prioritiesListBox, x.Item2);


                        processesTmpContainer = receivedMessage;

                        LogEvent($"Ring structure obtained [{processesTmpContainer}]. ");
                        MakeNewLineInLog();

                        SendRingList();
                    } else if (receivedMessage.Contains("LIST:") && isRingObtained)
                    {
                        MakeNewLineInLog();
                        LogEvent("Ring structure obtained.");
                        if (processesTmpContainer != receivedMessage)
                        {
                            processesTmpContainer = receivedMessage;
                            LogEvent("Changes found! Overwriting ring structure.");
                        } else
                        {
                            LogEvent("No changes found. Package ignored.");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void UpdateList<T>(ListBox listBox, List<T> list)
        {
            MethodInvoker inv = delegate
            {
                listBox.DataSource = list;
            };

            Invoke(inv);
        }


        private void ringSynchronizationBtn_Click(object sender, EventArgs e)
        {
            RequestRingSynchronization();
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

            byte[] sendingMessage = encoding.GetBytes(processesTmpContainer);

            LogEvent($"Request network synchronization [{processesTmpContainer}].");
            MakeNewLineInLog();

            sck.SendTo(sendingMessage, epTarget);
        }

        private void SendRingList()
        {
            processesTmpContainer = processesTmpContainer.Replace("CONF:", "LIST:");
            byte[] message = encoding.GetBytes(processesTmpContainer);
            sck.SendTo(message, epTarget);
            LogEvent($"Forward ring to the target.");
        }

        private void processConfigChanged(object sender, EventArgs e)
        {
            if (!isConnectionEstablished)
            {
                connectToTargetBtn.Enabled = CheckIfConfigFieldsAreNotEmpty() ? true : false;
            }
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
