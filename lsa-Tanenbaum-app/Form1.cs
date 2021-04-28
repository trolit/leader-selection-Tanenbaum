using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        Socket sck;
        IAsyncResult sckResult;
        EndPoint epProcess, epTarget;
        byte[] buffer;  // for sending messages
        List<string> listOfAllProcesses;
        List<int> listOfProcessesPriorities;
        Random randomizer;
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

            //
            disconnectFromTargetBtn.Enabled = false;

            // get user IP
            textProcessIp.Text = GetLocalAddress();
            textTargetIp.Text = GetLocalAddress();



        }

        private void connectToTargetBtn_Click(object sender, EventArgs e)
        {
            // Setup socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // binding Socket
            epProcess = new IPEndPoint(IPAddress.Parse(textProcessIp.Text), 
                Convert.ToInt32(textProcessPort.Text));
            sck.Bind(epProcess);

            // connecting to remote IP (target)
            epTarget = new IPEndPoint(IPAddress.Parse(textTargetIp.Text), 
                Convert.ToInt32(textTargetPort.Text));

            
            Invoke((Func<string, int>)listMessage.Items.Add, $"Configured");
            sck.Connect(epTarget);

            ASCIIEncoding encoding = new ASCIIEncoding();

            // listening to specific port
            buffer = new byte[1500];
            sckResult = sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epTarget, new AsyncCallback(MessageCallBack), buffer);
            sck2.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epProcess, new AsyncCallback(MessageCallBack), buffer);

            if (sck.Connected)
            {
                listOfAllProcesses.Add(textProcessName.Text);
                pictureBoxConnectionStatus.Image = Resources.status_connected;
                labelConnectionStatus.Text = "Connected";
                SwapEnabledForConnectAndDisconnectBtns();            
            }       
        }

        private void disconnectFromTargetBtn_Click(object sender, EventArgs e)
        {
            // sck.EndReceive(sckResult);
            sck.Close();
            listMessage.Items.Add("Socket is connected? " + sck.Connected);
            pictureBoxConnectionStatus.Image = Resources.status_notconnected;
            labelConnectionStatus.Text = "Not Connected";
            SwapEnabledForConnectAndDisconnectBtns();
        }


        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            // Convert string message to byte[]
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = encoding.GetBytes(textMessage.Text);

            // Send encoded message to the target
            sck.Send(sendingMessage);

            // Add to the listbox
            listMessage.Items.Add("Me: " + textMessage.Text);

            textMessage.Text = "";
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
                        processesTmpContainer = "CONF:";

                        // Add message to the console
                        Invoke((Func<string, int>)listMessage.Items.Add, $"{textProcessName.Text}: Received msg: {receivedMessage}");
                        
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

        private void obtainRingBtn_Click(object sender, EventArgs e)
        {
            if (!processesTmpContainer.Contains(textProcessName.Text))
            {
                PerformConfigurationRequest();
            }
        }

        private void PerformConfigurationRequest()
        {
            // Convert string message to byte[]
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];

            // processesTmpContainer = processesTmpContainer == "CONF:" ? processesTmpContainer + textProcessName.Text :
            //    processesTmpContainer + $"-{textProcessName.Text}";

            sendingMessage = encoding.GetBytes(processesTmpContainer == "CONF:" ? processesTmpContainer + textProcessName.Text :
                processesTmpContainer + $"-{textProcessName.Text}");

            // Send encoded message to the target
            // sck.Send(sendingMessage);

            sck.Send(sendingMessage);
            Invoke((Func<string, int>)listMessage.Items.Add, $"Sent from {textProcessName.Text} to {textTargetPort.Text}");


            // Add to the listbox
            listMessage.Items.Add($"{textProcessName.Text}: {processesTmpContainer} sent");

            textMessage.Text = "";
        }

        private void RandomizeProcessIdentity()
        {
            textProcessName.Text = "P-" + randomizer.Next(1000, 9999);
        }
    }
}
