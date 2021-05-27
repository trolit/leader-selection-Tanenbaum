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

        /// <summary>
        /// Flag to control MessageCallback triggering.
        /// </summary>
        public bool IsInitialized { get; set; } = false;

        /// <summary>
        /// Flag to verify callback received by ring synchronization caller.
        /// </summary>
        public bool IsRingObtained { get; set; } = false;

        /// <summary>
        /// Flag to verify callback received by coordinator message invoker.
        /// </summary>
        public bool IsCoordinatorMessageSend { get; set; } = false;

        public TextBox[] ConfigurationTextBoxes { get; set; }

        public RichTextBox LogBox { get; set; }

        /// <summary>
        /// String to exchange ring intel during synchronization stage.
        /// </summary>
        public string SynchronizationContainer { get; set; }

        /// <summary>
        /// Limits diagnostic ping answer waiting time (in seconds). 
        /// </summary>
        public decimal ReplyTimeout { get; set; } = 3;

        /// <summary>
        /// Space between each diagnostic ping invoked by process (in seconds)
        /// </summary>
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
