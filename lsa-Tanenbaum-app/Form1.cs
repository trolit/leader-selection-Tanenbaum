using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epProcess, epTarget;
        byte[] buffer;  // for sending messages


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // setup socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // get user IP
            textProcessIp.Text = GetLocalAddress();
            textSourceIp.Text = GetLocalAddress();



        }

        private void connectToTargetBtn_Click(object sender, EventArgs e)
        {
            // binding Socket
            epProcess = new IPEndPoint(IPAddress.Parse(textProcessIp.Text), 
                Convert.ToInt32(textProcessPort.Text));

            sck.Bind(epProcess);

            // connecting to remote IP (target)
            epTarget = new IPEndPoint(IPAddress.Parse(textSourceIp.Text), 
                Convert.ToInt32(textSourcePort.Text));

            sck.Connect(epTarget);

            // listening to specific port
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epTarget, new AsyncCallback(MessageCallBack), buffer);
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
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[]) result.AsyncState;

                // Convert byte[] to string
                ASCIIEncoding encoding = new ASCIIEncoding();
                string receivedMessage = encoding.GetString(receivedData);

                // Add message to the console
                Invoke((Func<string, int>) listMessage.Items.Add, "Friend: " + receivedMessage);

                // callback again
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epTarget, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
