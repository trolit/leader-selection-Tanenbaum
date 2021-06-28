using lsa_Tanenbaum_app.Models;
using System;
using System.Net;
using System.Windows.Forms;
using static lsa_Tanenbaum_app.LogSymbols;

namespace lsa_Tanenbaum_app.Services
{
    public class TimerService
    {
        private Process _process;
        private RequestService _requestService;

        private Process Process => _process;
        private RequestService RequestService => _requestService;

        public TimerService(Process process, RequestService requestService)
        {
            _process = process;
            _requestService = requestService;
        }

        public Timer diagnosticPingCoordinatorTimeoutTimer;
        public Timer diagnosticPingElectionTimeoutTimer;
        public Timer diagnosticPingTimer;

        #region Diagnostic Ping Timer

        public void InitDiagnosticPingTimer()
        {
            diagnosticPingTimer = new Timer();
            diagnosticPingTimer.Tick += new EventHandler(diagnosticPingTimer_Tick);
            diagnosticPingTimer.Interval = Process.PingFrequency < 1 ? 500 : (int)(Process.PingFrequency * 1000); // 5 * 1000 = 5000ms (5s)
            diagnosticPingTimer.Start();
        }

        private void diagnosticPingTimer_Tick(object sender, EventArgs e)
        {
            if (diagnosticPingCoordinatorTimeoutTimer == null)
            {
                RequestService.SendEchoRequest(Process.RingCoordinatorIP);
                InitDiagnosticPingCoordinatorTimeoutTimer();
                Process.LogBox.WriteEvent($"{SEND_SYMBOL} echo request to coordinator.");
            }
        }

        #endregion

        #region Diagnostic Ping Coordinator Timeout Timer

        private int currentCoordinatorTimeoutTick = 0;

        public void InitDiagnosticPingCoordinatorTimeoutTimer()
        {
            diagnosticPingCoordinatorTimeoutTimer = new Timer();
            diagnosticPingCoordinatorTimeoutTimer.Tick += new EventHandler(diagnosticPingCoordinatorTimeoutTimer_Tick);
            diagnosticPingCoordinatorTimeoutTimer.Interval = 1000;
            diagnosticPingCoordinatorTimeoutTimer.Start();
        }

        private void diagnosticPingCoordinatorTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentCoordinatorTimeoutTick == Process.ReplyTimeout)
            {
                // disable coordinator timeout timer
                StopDiagnosticPingCoordinatorTimeoutTimer();

                Process.DisableDiagnosticPingButton.PerformClick();

                Process.LogBox.WriteEvent($"{SOURCE_SYMBOL} echo request timed out");
                Process.LogBox.WriteEvent($"{SEND_SYMBOL} initialize election");

                RequestService.SendElectionRequest();
            }
            else
            {
                currentCoordinatorTimeoutTick += 1;
                Process.LogBox.WriteEvent($"{SOURCE_SYMBOL} ..waiting for Echo Reply {currentCoordinatorTimeoutTick}s / {Process.ReplyTimeout}s from coordinator.");
            }
        }

        public void StopDiagnosticPingCoordinatorTimeoutTimer()
        {
            if (diagnosticPingCoordinatorTimeoutTimer != null)
            {
                diagnosticPingCoordinatorTimeoutTimer.Stop();
                diagnosticPingCoordinatorTimeoutTimer = null;
            }
            currentCoordinatorTimeoutTick = 0;
        }

        #endregion

        #region Diagnostic Ping Election Timeout Timer 

        private int currentElectionTimeoutTick = 0;

        private IPEndPoint _target;

        public void InitDiagnosticPingElectionTimeoutTimer(IPEndPoint target)
        {
            _target = target;
            diagnosticPingElectionTimeoutTimer = new Timer();
            diagnosticPingElectionTimeoutTimer.Tick += new EventHandler(diagnosticPingElectionTimeoutTimer_Tick);
            diagnosticPingElectionTimeoutTimer.Interval = 1000;
            diagnosticPingElectionTimeoutTimer.Start();
        }

        private void diagnosticPingElectionTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentElectionTimeoutTick == Process.ReplyTimeout)
            {
                Process.LogBox.WriteEvent($"{SOURCE_SYMBOL} Connection attempt failed!");
                StopDiagnosticPingElectionTimeoutTimer();
            }
            else
            {
                currentElectionTimeoutTick += 1;
                Process.LogBox.WriteEvent($"{SOURCE_SYMBOL} waiting for Echo Reply {currentElectionTimeoutTick}s / {Process.ReplyTimeout}s from {_target}.");
            }
        }

        public void StopDiagnosticPingElectionTimeoutTimer()
        {
            if (diagnosticPingElectionTimeoutTimer != null)
            {
                diagnosticPingElectionTimeoutTimer.Stop();
                diagnosticPingElectionTimeoutTimer = null;
            }
            currentElectionTimeoutTick = 0;
        }

        #endregion
    }
}
