using lsa_Tanenbaum_app.Models;
using System;
using System.Windows.Forms;

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

        private int currentCoordinatorTimeoutTick = 0;
        private int currentElectionTimeoutTick = 0;

        public void InitDiagnosticPingTimer()
        {
            diagnosticPingTimer = new Timer();
            diagnosticPingTimer.Tick += new EventHandler(diagnosticPingTimer_Tick);
            diagnosticPingTimer.Interval = Process.PingFrequency < 1 ? 500 : (int) (Process.PingFrequency * 1000); // 5 * 1000 = 5000ms (5s)
            diagnosticPingTimer.Start();
        }

        private void diagnosticPingTimer_Tick(object sender, EventArgs e)
        {
            if (diagnosticPingCoordinatorTimeoutTimer == null)
            {
                RequestService.SendEchoRequest(Process.RingCoordinatorIP);
                InitDiagnosticPingCoordinatorTimeoutTimer();
                Process.LogBox.WriteEvent($"Send ICMP Echo Request to coordinator.");
            }
        }

        private void diagnosticPingCoordinatorTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentCoordinatorTimeoutTick == Process.ReplyTimeOut)
            {
                // disable coordinator timeout timer
                StopDiagnosticPingCoordinatorTimeoutTimer();

                Process.DisableDiagnosticPingButton.PerformClick();

                Process.LogBox.WriteEvent($"PING: ICMP Echo Request timed out. Start election.");

                RequestService.SendElectionRequest(this);
            }
            else
            {
                currentCoordinatorTimeoutTick += 1;
                Process.LogBox.WriteEvent($"PING: Waiting for ICMP Echo Reply {currentCoordinatorTimeoutTick}s / {Process.ReplyTimeOut}s.");
            }
        }

        public void InitDiagnosticPingCoordinatorTimeoutTimer()
        {
            diagnosticPingCoordinatorTimeoutTimer = new Timer();
            diagnosticPingCoordinatorTimeoutTimer.Tick += new EventHandler(diagnosticPingCoordinatorTimeoutTimer_Tick);
            diagnosticPingCoordinatorTimeoutTimer.Interval = 1000;
            diagnosticPingCoordinatorTimeoutTimer.Start();
        }

        public void StopDiagnosticPingCoordinatorTimeoutTimer()
        {
            currentCoordinatorTimeoutTick = 0;
            if (diagnosticPingCoordinatorTimeoutTimer != null)
            {
                diagnosticPingCoordinatorTimeoutTimer.Stop();
                diagnosticPingCoordinatorTimeoutTimer = null;
            }
        }

        private void diagnosticPingElectionTimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (currentElectionTimeoutTick == Process.ReplyTimeOut)
            {
                Process.LogBox.WriteEvent($"ELEC: Connection with {Process.ListOfAddresses[RequestService.GetTestedNeighbourId()]} failed.");
                RequestService.IncreaseIncrementer();
                StopDiagnosticPingElectionTimeoutTimer();
            }
            else
            {
                currentElectionTimeoutTick += 1;
                Process.LogBox.WriteEvent($"ELEC_PING: Waiting for ICMP Echo Reply {currentElectionTimeoutTick}s / {Process.ReplyTimeOut}s.");
            }
        }

        public void InitDiagnosticPingElectionTimeoutTimer()
        {
            diagnosticPingElectionTimeoutTimer = new Timer();
            diagnosticPingElectionTimeoutTimer.Tick += new EventHandler(diagnosticPingElectionTimeoutTimer_Tick);
            diagnosticPingElectionTimeoutTimer.Interval = 1000;
            diagnosticPingElectionTimeoutTimer.Start();
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
    }
}
