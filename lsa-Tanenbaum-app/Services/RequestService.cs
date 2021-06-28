using lsa_Tanenbaum_app.Models;
using lsa_Tanenbaum_app.Requests;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static lsa_Tanenbaum_app.Headers;
using static lsa_Tanenbaum_app.LogSymbols;

namespace lsa_Tanenbaum_app.Services
{
    public class RequestService
    {
        private readonly HelperMethods _helperMethods;
        private Process _process;

        private Process Process => _process;

        public RequestService(HelperMethods helperMethods, Process process)
        {
            _helperMethods = helperMethods;
            _process = process;
        }

        public void SendEchoRequest(IPEndPoint targetIPEndPoint)
        {
            // ICMP_ECHO_REQUEST:FROM
            byte[] message = PackMessage($"{EchoRequest}{Process.SourceIPEndPoint}");
            Process.Socket.SendTo(message, targetIPEndPoint);
        }

        public void SendEchoReply(string requesterSocketAddress)
        {
            string[] splitRequesterSocketAddress = requesterSocketAddress.Split(':');
            IPEndPoint socketAddress = BuildIPEndPoint(splitRequesterSocketAddress[0], splitRequesterSocketAddress[1]);

            int index = Process.ListOfAddresses.IndexOf(socketAddress);
            if (index != -1)
            {
                byte[] message = PackMessage($"{EchoReply}{Process.SourceIPEndPoint}");
                Process.Socket.SendTo(message, Process.ListOfAddresses[index]);
                Process.LogBox.WriteEvent($"{SEND_SYMBOL} echo reply to {socketAddress}.");
            }
        }

        public void SendRingSynchronizationRequest()
        {
            if (Process.SynchronizationContainer == Configuration)
            {
                Process.SynchronizationContainer = $"{Configuration}|{Process.SourceIPEndPoint}:{Process.Priority}";
            }
            else if (Process.SynchronizationContainer.Contains($"{Process.SourceIPEndPoint}") == false)
            {
                Process.SynchronizationContainer = $"{Process.SynchronizationContainer}|{Process.SourceIPEndPoint}:{Process.Priority}";
            }

            Process.SynchronizationContainer = _helperMethods.RemoveZeroCharactersFromString(Process.SynchronizationContainer);

            Process.LogBox.WriteEvent($"{SEND_SYMBOL} network synchronization request to {Process.TargetIPEndPoint}.");

            Process.Socket.SendTo(PackMessage(Process.SynchronizationContainer), Process.TargetEndPoint);
        }

        public void SendRingList()
        {
            Process.LogBox.WriteEvent($"{SEND_SYMBOL} ring structure to {Process.TargetIPEndPoint}");
            Process.SynchronizationContainer = Process.SynchronizationContainer.Replace(Configuration, List);
            Process.Socket.SendTo(PackMessage(Process.SynchronizationContainer), Process.TargetEndPoint);
        }

        public void SendPriorityUpdateRequest()
        {
            Process.LogBox.WriteEvent($"{SEND_SYMBOL} priority update request to {Process.TargetIPEndPoint}.");
            byte[] message = PackMessage($"{Priority}{Process.SourceIPEndPoint}:{Process.Priority}");
            Process.Socket.SendTo(message, Process.TargetEndPoint);
        }

        public void SendElectionRequest(string electionMessage = "")
        {
            new ElectionRequest(this, Process, electionMessage);
        }

        public void InitiateCoordinatorMessage(string electionMessage)
        {
            string message = electionMessage.Replace(Election, "");
            string coordinatorMessage = $"{Coordinator}{Process.Id}{message}";
            byte[] coordinatorPackedMessage = PackMessage(coordinatorMessage);
            IPEndPoint nextProcessIPEndPoint = GetNextProcessIPEndPointOnCoordinatorRequest();

            Process.LogBox.WriteEvent($"{SEND_SYMBOL} coordinator message to {nextProcessIPEndPoint}.");
            Process.Socket.SendTo(coordinatorPackedMessage, nextProcessIPEndPoint);
        }

        public void SendCoordinatorMessage(string electionMessage)
        {
            string coordinatorMessage = electionMessage.Replace(Election, Coordinator);
            byte[] coordinatorPackedMessage = PackMessage(coordinatorMessage);

            IPEndPoint nextProcessIPEndPoint = GetNextProcessIPEndPointOnCoordinatorRequest();
            Process.Socket.SendTo(coordinatorPackedMessage, nextProcessIPEndPoint);
        }

        private byte[] PackMessage(string message)
        {
            return _helperMethods.PackMessage(message);
        }

        private IPEndPoint BuildIPEndPoint(string address, string port)
        {
            return _helperMethods.BuildIPEndPoint(address, port);
        }

        private IPEndPoint GetNextProcessIPEndPointOnCoordinatorRequest()
        {
            int currentProcessId = Process.ListOfAddresses.IndexOf(Process.SourceIPEndPoint);
            int nextProcessId = currentProcessId + 1;

            if (nextProcessId >= Process.ListOfAddresses.Count)
                nextProcessId = 0;

            return Process.ListOfAddresses[nextProcessId];
        }

    }
}
