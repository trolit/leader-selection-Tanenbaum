using lsa_Tanenbaum_app.Structures;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace lsa_Tanenbaum_app.Models
{
    public class Process
    {
        public Socket Socket { get; set; }

        public List<IPEndPoint> ListOfAddresses { get; set; } = new List<IPEndPoint>();

        public List<int> ListOfPriorities { get; set; } = new List<int>();

        public IPEndPoint RingCoordinatorIP { get; set; }

        public EndPoint SourceEndPoint { get; set; }

        public IPEndPoint SourceIPEndPoint => (IPEndPoint) SourceEndPoint;

        public Address SourceAddress { get; set; }

        public EndPoint TargetEndPoint { get; set; }

        public IPEndPoint TargetIPEndPoint => (IPEndPoint)TargetEndPoint;

        public Address TargetAddress { get; set; }

        public int Priority { get; set; }

        public bool IsInitialized { get; set; } = false;

        // to verify callback received by ring synchiornization caller
        public bool IsRingObtained { get; set; } = false;

        // for coordinator message initializer 
        public bool IsCoordinatorMessageSend { get; set; } = false;

        public TextBox[] ConfigurationTextBoxes { get; set; }

        public RichTextBox LogBox { get; set; }

        public string SynchronizationContainer { get; set; }

        public decimal ReplyTimeOut { get; set; } = 3;

        public decimal PingFrequency { get; set; } = 0.5M;

        public Button DisableDiagnosticPingButton { get; set; }
        public void UpdateTarget(HelperMethods helperMethods, string address, string port)
        {
            Address newTargetAddress = new Address(address, port);
            TargetAddress = newTargetAddress;
            TargetEndPoint = helperMethods.BuildIPEndPoint(address, port);
        }
    }
}
