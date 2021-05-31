using lsa_Tanenbaum_app.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using static lsa_Tanenbaum_app.Headers;

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
                Process.LogBox.WriteEvent($"Send ICMP Echo Reply to requester({socketAddress}).");
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

            Process.LogBox.WriteEvent($"Request network synchronization \nstate:[{Process.SynchronizationContainer}].");

            Process.Socket.SendTo(PackMessage(Process.SynchronizationContainer), Process.TargetEndPoint);
        }

        public void SendRingList()
        {
            Process.SynchronizationContainer = Process.SynchronizationContainer.Replace(Configuration, List);
            Process.Socket.SendTo(PackMessage(Process.SynchronizationContainer), Process.TargetEndPoint);
            Process.LogBox.WriteEvent($"Send obtained ring to [{Process.TargetIPEndPoint}].");
        }

        public void SendPriorityUpdateRequest()
        {
            byte[] message = PackMessage($"{Priority}{Process.SourceIPEndPoint}:{Process.Priority}");
            Process.Socket.SendTo(message, Process.TargetEndPoint);
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

        // ***************************************
        //
        // ELECTION REQUEST
        //
        // ***************************************

        private bool isNextAvailableNeighbourFound = false;
        private int testedNeighbourId;
        private int incrementer = 1;

        public void IncreaseIncrementer()
        {
            incrementer += 1;
        }

        public int GetTestedNeighbourId()
        {
            return testedNeighbourId;
        }

        public void MarkTestedProcessAsAvailable()
        {
            isNextAvailableNeighbourFound = true;
        }

        public void SendElectionRequest(TimerService timerService, string previousMessage = "")
        {
            int numberOfAddresses = Process.ListOfAddresses.Count;
            IPEndPoint nextProcessIP = Process.SourceIPEndPoint;
            List<IPEndPoint> temporaryListOfAddresses = Process.ListOfAddresses;

            while (!isNextAvailableNeighbourFound)
            {
                if (timerService.diagnosticPingElectionTimeoutTimer == null)
                {
                    nextProcessIP = GetIPOfNextProcessOnElectionRequest(numberOfAddresses, temporaryListOfAddresses);

                    if (nextProcessIP.ToString() == Process.SourceIPEndPoint.ToString())
                        break;

                    Process.LogBox.WriteEvent($"Trying to communicate with {nextProcessIP}.");

                    timerService.InitDiagnosticPingElectionTimeoutTimer();
                    SendEchoRequest(nextProcessIP);
                }

                Application.DoEvents();
            }

            timerService.StopDiagnosticPingElectionTimeoutTimer();
            incrementer = 1;

            if (!isNextAvailableNeighbourFound)
            {
                Process.LogBox.WriteEvent($"No other available processes found. Can't resolve election :(");
            }
            else
            {
                byte[] message;

                if (previousMessage == string.Empty)
                    message = PackMessage($"{Election}|{Process.SourceIPEndPoint}:{Process.Priority}");
                else
                    message = PackMessage($"{previousMessage}|{Process.SourceIPEndPoint}:{Process.Priority}");

                isNextAvailableNeighbourFound = false;

                Process.Socket.SendTo(message, nextProcessIP);
                Process.LogBox.WriteEvent($"Election message sent to {nextProcessIP}");
            }
        }

        private IPEndPoint GetIPOfNextProcessOnElectionRequest(int numberOfAddresses, List<IPEndPoint> temporaryListOfAddresses)
        {
            if (numberOfAddresses == 2)
            {
                return Process.SourceIPEndPoint;
            }

            testedNeighbourId = temporaryListOfAddresses.IndexOf(Process.SourceIPEndPoint) + incrementer;

            if (testedNeighbourId >= numberOfAddresses)
            {
                testedNeighbourId -= numberOfAddresses;
            }

            return temporaryListOfAddresses[testedNeighbourId];
        }
    }
}
