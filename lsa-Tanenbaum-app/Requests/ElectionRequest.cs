﻿using lsa_Tanenbaum_app.Models;
using lsa_Tanenbaum_app.Services;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using static lsa_Tanenbaum_app.LogSymbols;
using static lsa_Tanenbaum_app.Headers;

namespace lsa_Tanenbaum_app.Requests
{
    public class ElectionRequest
    {
        
        private RequestService _requestService;
        private TimerService _timerService;
        private Process _process;
        private HelperMethods _helpers;

        private RequestService RequestService => _requestService;
        private TimerService TimerService => _timerService;
        private Process Process => _process;
        private HelperMethods Helpers => _helpers;

        private int _numberOfAddresses = 0;

        private int _testedProcessId;

        private bool _isNextProcessFound = false;

        private List<IPEndPoint> _listOfAddresses;

        public ElectionRequest(RequestService requestService, Process process, string previousMessage = "")
        {
            _requestService = requestService;
            _process = process;
            _timerService = new TimerService(Process, RequestService);
            _helpers = new HelperMethods();

            Process.ElectionRequestsContainer.Add(this);

            _numberOfAddresses = Process.ListOfAddresses.Count;
            _listOfAddresses = Process.ListOfAddresses;

            InitializeElection(previousMessage);
        }

        private void InitializeElection(string previousMessage = "")
        {
            IPEndPoint nextProcessIP = Process.SourceIPEndPoint;

            while (!_isNextProcessFound)
            {
                if (TimerService.diagnosticPingElectionTimeoutTimer == null)
                {
                    nextProcessIP = GetIPOfNextProcess(nextProcessIP);

                    if (nextProcessIP.ToString() == Process.SourceIPEndPoint.ToString())
                        break;

                    Process.LogBox.WriteEvent($"{SEND_SYMBOL} echo request to {nextProcessIP}");

                    TimerService.InitDiagnosticPingElectionTimeoutTimer();
                    RequestService.SendEchoRequest(nextProcessIP);
                }

                Application.DoEvents();
            }

            TimerService.StopDiagnosticPingElectionTimeoutTimer();

            if (nextProcessIP.ToString() == Process.SourceIPEndPoint.ToString())
            {
                Process.LogBox.WriteEvent($"!=----------------------------------------------");
                Process.LogBox.WriteEvent($"{SOURCE_SYMBOL} No other available processes found. \nCan't resolve election :(");
                Process.LogBox.WriteEvent($"!=----------------------------------------------");
            }
            else
            {
                byte[] message;

                if (previousMessage == "" || previousMessage.Contains(Process.Id))
                    message = Helpers.PackMessage($"{Election}{Process.Id}|{Process.SourceIPEndPoint}:{Process.Priority}");
                else
                    message = Helpers.PackMessage($"{previousMessage}|{Process.SourceIPEndPoint}:{Process.Priority}");

                Process.LogBox.WriteEvent($"{SEND_SYMBOL} election message to {nextProcessIP}");
                Process.LogBox.BreakLine();
                Process.Socket.SendTo(message, nextProcessIP);
            }
        }

        private IPEndPoint GetIPOfNextProcess(IPEndPoint previousIp)
        {
            if (_numberOfAddresses == 2)
            {
                return Process.SourceIPEndPoint;
            }

            _testedProcessId = _listOfAddresses.IndexOf(previousIp) + 1;

            if (_testedProcessId >= _numberOfAddresses)
            {
                _testedProcessId = 0;
            }

            return _listOfAddresses[_testedProcessId];
        }

        public void CompleteNextProcessFindingStage()
        {
            _isNextProcessFound = true;
        }
    }
}
