using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        Socket sck;
        Random randomizer;
        DateTime date = DateTime.Now;

        EndPoint epProcess, epTarget, epReceiveFrom;
        byte[] buffer;  // for sending messages

        bool isConnectionEstablished = false; // for handling simple fields checking with disconnect btn behaviour
        
        List<string> listOfAllProcesses;
        List<int> listOfProcessesPriorities;
        
        string processesTmpContainer;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            randomizer = new Random();
            RandomizeProcessIdentity();

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
                LogEvent($"{textProcessName.Text} connection established.");

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
            Invoke((Func<DateTime, string, bool>)logBox.AppendText, date, text);
        }

        private void disconnectFromTargetBtn_Click(object sender, EventArgs e)
        {
            sck.Close();
            pictureBoxConnectionStatus.Image = Resources.status_notconnected;
            labelConnectionStatus.Text = "Not Connected";
            SwapEnabledForConnectAndDisconnectBtns();
            isConnectionEstablished = false;
            processConfigChanged(sender, e);
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
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    string receivedMessage = encoding.GetString(receivedData);
                    if (receivedMessage.Contains("CONF:"))
                    {
                        // Add message to the console
                        LogEvent($"Received synchronization request with package: {receivedMessage}.");
                        
                        processesTmpContainer = $"{receivedMessage}";

                        // callback again
                        buffer = new byte[1500];
                        sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epTarget, new AsyncCallback(MessageCallBack), buffer);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void SwapEnabledForConnectAndDisconnectBtns()
        {
            connectToTargetBtn.Enabled = !connectToTargetBtn.Enabled;
            disconnectFromTargetBtn.Enabled = !disconnectFromTargetBtn.Enabled;
        }

        private void ringSynchronizationBtn_Click(object sender, EventArgs e)
        {
            RequestRingSynchronization();
        }

        private void processConfigChanged(object sender, EventArgs e)
        {
            if (!isConnectionEstablished)
            {
                connectToTargetBtn.Enabled = CheckIfConfigFieldsAreNotEmpty() ? true : false;
            }
        }

        private bool CheckIfConfigFieldsAreNotEmpty()
        {
            bool result = true;
            int kappa = 1;

            string[] configFieldsValues = new string[] {
                textProcessName.Text,
                textProcessIp.Text,
                textProcessPort.Text,
                textTargetIp.Text,
                textTargetPort.Text,
                textReceiveFromIp.Text,
                textReceiveFromPort.Text
            };

            foreach (string fieldValue in configFieldsValues)
            {
                if (string.IsNullOrWhiteSpace(fieldValue))
                {
                    result = false;
                    break;
                }
                kappa++;
            }

            return result;
        }

        private void RequestRingSynchronization()
        {
            // Convert string message to byte[]
            ASCIIEncoding encoding = new ASCIIEncoding();

            processesTmpContainer = processesTmpContainer.Equals("CONF:") ? 
                $"CONF: {textProcessName.Text}" : $"{processesTmpContainer}:{textProcessName.Text}";

            byte[] sendingMessage = encoding.GetBytes(processesTmpContainer);

            sck.SendTo(sendingMessage, epTarget);

            LogEvent($"Synchronization request sent to {textTargetIp.Text}:{textTargetPort.Text}.");
        }

        private void RandomizeProcessIdentity()
        {
            textProcessName.Text = "P-" + randomizer.Next(1000, 9999);
        }
    }
}
