using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using lsa_Tanenbaum_app.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using lsa_Tanenbaum_app.Models;
using lsa_Tanenbaum_app.Structures;
using lsa_Tanenbaum_app.Services;
using static lsa_Tanenbaum_app.Headers;

/* 
 * ---------------------------------------------------------------------------
 * 
 * Leader Selection Algorithm 2021, Tanenbaum's variant
 * Repository: https://github.com/trolit/leader-selection-Tanenbaum
 * App icon made by Becris, https://www.flaticon.com/authors/becris 
 * 
 * ---------------------------------------------------------------------------
 */

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        private const int BUFFER_SIZE = 1500;
        private byte[] _buffer;

        private Process _process;

        private HelperMethods _helperMethods;

        private ConfigurationService _configurationService;
        private RequestService _requestService;
        private TimerService _timerService;

        public Form1()
        {
            InitializeComponent();
        }

        // **************************************************
        //
        //              PROCESS INITIALIZATION
        //
        // **************************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            _helperMethods = new HelperMethods();
            _configurationService = new ConfigurationService();
            _helperMethods.RandomizeProcessIdentity(textProcessName);

            SetProcessTitle();

            _process = new Process()
            {
                ConfigurationTextBoxes = new TextBox[] { textProcessName, textSourceIp, textSourcePort, textTargetIp, textTargetPort },
                LogBox = logBox,
                Priority = Convert.ToInt32(textPriority.Text),
                SynchronizationContainer = Configuration,
                DisableDiagnosticPingButton = disableDiagnosticPingBtn
        };

            _requestService = new RequestService(_helperMethods, _process);
            _timerService = new TimerService(_process, _requestService);

            // put user IP
            textSourceIp.Text = _helperMethods.GetLocalAddress();
            textTargetIp.Text = _helperMethods.GetLocalAddress();

            _process.LogBox.WriteEvent($"Process {System.Diagnostics.Process.GetCurrentProcess().Id}({textProcessName.Text}) initialized.");
        }

        private void SetProcessTitle()
        {
            Text = $"Tanenbaum LSA | {textProcessName.Text}";
        }

        // **************************************************
        //
        //                 CALLBACK CORE 
        //
        // **************************************************

        private void OnDataReceived(IAsyncResult result)
        {
            if (_process.IsInitialized)
            {
                try
                {
                    byte[] receivedData = new byte[BUFFER_SIZE];
                    receivedData = (byte[])result.AsyncState;

                    // Convert byte[] to string
                    string receivedMessage = _helperMethods.UnpackMessage(receivedData);

                    // Setup callback again
                    _buffer = new byte[BUFFER_SIZE];
                    _process.Socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(OnDataReceived), _buffer);

                    switch (receivedMessage)
                    {
                        case string configurationMessage when receivedMessage.Contains(Configuration):
                            {
                                _process.SynchronizationContainer = configurationMessage;
                                ringSynchronizationBtn.Disable();

                                if (_process.SynchronizationContainer.Contains($"{_process.SourceIPEndPoint}"))
                                {
                                    _process.LogBox.WriteEvent("Synchronization request returned to the caller. Ring obtained.");
                                    _process.IsRingObtained = true;

                                    // pass obtained ring further
                                    UpdateKnowledgeSection(Configuration, _process.SynchronizationContainer);
                                    _requestService.SendRingList();
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent($"Synchronization request received. Passing it further.");
                                    _requestService.SendRingSynchronizationRequest();
                                }
                            }
                            break;

                        case string listMessage when receivedMessage.Contains(List):
                            {
                                UpdateReplyTimeOutProperty();
                                UpdatePingFrequencyProperty();
                                _process.SynchronizationContainer = listMessage;
                                UpdateKnowledgeSection(List, listMessage);
                                SelectRingCoordinator();

                                if (_process.IsRingObtained == false)
                                {
                                    _process.IsRingObtained = true;
                                    _process.LogBox.WriteEvent($"Ring structure obtained \nstate:[{_process.SynchronizationContainer}].");
                                    _requestService.SendRingList();
                                } else
                                {
                                    _process.LogBox.WriteEvent("Ring structure returned to synchronization caller. Remove message.");
                                }

                                UpdateInterfaceOnCompletedRingSynchronization();
                            }
                            break;

                        case string priorityMessage when receivedMessage.Contains(Priority):
                            {
                                _process.LogBox.WriteEvent("Priority update request received.");
                                if (priorityMessage.Contains($"{textSourceIp.Text}:{textSourcePort.Text}"))
                                {
                                    _process.LogBox.WriteEvent($"Update priority knowledge and delete request.");
                                    UpdatePriorityInListBox(priorityMessage);
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent("Update priority knowledge and pass request further.");
                                    UpdatePriorityInListBox(priorityMessage);
                                    _process.Socket.SendTo(receivedData, _process.TargetEndPoint);
                                }
                            }
                            break;

                        case string echoRequestMessage when receivedMessage.Contains(EchoRequest):
                            {
                                string cutMessage = echoRequestMessage.Replace(EchoRequest, "");
                                _process.LogBox.WriteEvent($"Received ICMP Echo Request from {cutMessage}. Send reply.");
                                _requestService.SendEchoReply(cutMessage);
                            }
                            break;

                        case string echopReplyMessage when receivedMessage.Contains(EchoReply):
                            {
                                if (echopReplyMessage.Contains(_process.RingCoordinatorIP.ToString()))
                                {
                                    string cutMessage = echopReplyMessage.Replace(EchoReply, "");
                                    _process.LogBox.WriteEvent($"Received ICMP Echo Reply from {cutMessage}.");
                                    _timerService.StopDiagnosticPingCoordinatorTimeoutTimer();
                                }
                                else if (echopReplyMessage.Contains(_process.ListOfAddresses[_requestService.GetTestedNeighbourId()].ToString()))
                                {
                                    _process.LogBox.WriteEvent($"Election diagnostic ping response received!");
                                    _requestService.MarkTestedProcessAsAvailable();
                                }
                            }
                            break;

                        case string electionMessage when receivedMessage.Contains(Election):
                            {
                                if (electionMessage.Contains($"{_process.SourceIPEndPoint}"))
                                {
                                    // election message returned to the process that initialized it
                                    _process.LogBox.WriteEvent($"Received back election message with data: {electionMessage}.");

                                    // 1. translate data
                                    UpdateKnowledgeSection(Election, electionMessage);

                                    // 2. choose leader
                                    SelectRingCoordinator();

                                    // 3. update ring coordinator label
                                    UpdateRingCoordinatorLabel();

                                    // 4. send COORDINATOR message and new ring structure
                                    _process.IsCoordinatorMessageSend = true;
                                    _requestService.SendCoordinatorMessage(electionMessage);

                                    _process.LogBox.WriteEvent($"Send coordinator message containing election results.");
                                }
                                else
                                {
                                    // pass election message further
                                    _process.LogBox.WriteEvent($"Received election message. Begin election request.");
                                    _requestService.SendElectionRequest(_timerService, electionMessage);
                                }
                            }
                            break;

                        case string coordinatorMessage when receivedMessage.Contains(Coordinator):
                            {
                                if (_process.IsCoordinatorMessageSend)
                                {
                                    UpdateTargetIntel();
                                    _process.LogBox.WriteEvent($"Coordinator message returned to election initiator. Message removed.");
                                    _process.IsCoordinatorMessageSend = false;
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent($"Coordinator message received. Updating knowledge and passing it further.");
                                    UpdateKnowledgeSection(Coordinator, coordinatorMessage);
                                    SelectRingCoordinator();
                                    UpdateTargetIntel();
                                    UpdateRingCoordinatorLabel();
                                    _requestService.SendCoordinatorMessage(coordinatorMessage);
                                }
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        // **************************************************
        //
        //               UI UPDATE FUNCTIONS
        //
        // **************************************************

        private void UpdateKnowledgeSection(string header, string source)
        {
            (List<IPEndPoint>, List<int>) data = _helperMethods.TranslateDataFromMessage(header, source);
            _process.ListOfAddresses = data.Item1;
            _process.ListOfPriorities = data.Item2;
            addressesListBox.UpdateCollection(_process.ListOfAddresses);
            prioritiesListBox.UpdateCollection(_process.ListOfPriorities);
        }

        private void UpdateInterfaceOnCompletedRingSynchronization()
        {
            UpdateRingCoordinatorLabel();
            knowledgeGroupBox.SetText($"{textProcessName.Text} network knowledge");
            knowledgeGroupBox.Display();
            diagnosticPingGroupBox.Display();
            HideDiagnosticPingGroupBoxForCoordinator();
            updatePriorityBtn.ReverseEnabledStatus();
        }

        private void UpdateTargetIntel()
        {
            int consequentIndex = _process.ListOfAddresses.IndexOf((IPEndPoint) _process.SourceEndPoint) + 1;

            if (consequentIndex >= _process.ListOfAddresses.Count)
                consequentIndex = 0;

            string newConsequentAddress = _process.ListOfAddresses[consequentIndex].Address.ToString();
            string newConsequentPort = _process.ListOfAddresses[consequentIndex].Port.ToString();

            textTargetIp.SetText(newConsequentAddress);
            textTargetPort.SetText(newConsequentPort);

            _process.UpdateTarget(_helperMethods, newConsequentAddress, newConsequentPort);
        }



        // **************************************************
        //
        //               PART FUNCTIONS
        //
        // **************************************************     

        private void SelectRingCoordinator()
        {
            int highestPriority = _process.ListOfPriorities.Max();
            int highestPriorityId = _process.ListOfPriorities.IndexOf(highestPriority);
            _process.RingCoordinatorIP = _process.ListOfAddresses[highestPriorityId];
            _process.LogBox.WriteEvent("Ring coordinator chosen.");
        }

        private void UpdateRingCoordinatorLabel()
        {
            int highestPriorityId = _helperMethods.GetIdOfHighestPriorityInList(_process.ListOfPriorities);
            ringCoordinatorAddressText.SetText(_process.RingCoordinatorIP.ToString());
            ringCoordinatorPriorityText.SetText($"with priority {_process.ListOfPriorities[highestPriorityId]} ({_helperMethods.GetCurrentTimeStamp(DateTime.Now)})");
        }

        private void HideDiagnosticPingGroupBoxForCoordinator()
        {
            if (_process.RingCoordinatorIP.ToString().Contains(_process.SourceIPEndPoint.ToString()))
            {
                Invoke(new MethodInvoker(() => {
                    diagnosticPingGroupBox.Visible = false;
                    knowledgeGroupBox.Location = new Point(knowledgeGroupBox.Location.X, 200);
                }));
            }
        } 

        private void UpdatePriorityInListBox(string message)
        {
            // pattern: PRIO:192....:80:10
            string[] splitMessage = message.Replace(Priority, "").Split(':');
            IPEndPoint address = _helperMethods.BuildIPEndPoint(splitMessage[0], splitMessage[1]);
            int index = _process.ListOfAddresses.IndexOf(address);

            _process.ListOfPriorities[index] = Convert.ToInt32(splitMessage[2]);

            prioritiesListBox.UpdateCollection(_process.ListOfPriorities);
        }


        // **************************************************
        //
        //             CLICK & ON CHANGE EVENTS
        //
        // **************************************************

        private void activateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            _timerService.InitDiagnosticPingTimer();
            _helperMethods.SwitchTwoButtonsEnabledStatus(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
        }

        private void deactivateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            if (_timerService.diagnosticPingTimer != null)
            {
                _timerService.diagnosticPingTimer.Stop();
                _helperMethods.SwitchTwoButtonsEnabledStatus(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
            }
        }

        private void ringSynchronizationBtn_Click(object sender, EventArgs e)
        {
            _requestService.SendRingSynchronizationRequest();
        }

        private void onPriorityTrackBarValueChange(object sender, EventArgs e)
        {
            textPriority.Text = (priorityTrackBar.Value).ToString();
            UpdateProcessPriority();
        }

        private void onPriorityTextBoxValueChange(object sender, EventArgs e)
        {
            if (int.TryParse(textPriority.Text, out int result))
            {
                if (result >= 1 && result <= 100)
                    priorityTrackBar.Value = result;

                UpdateProcessPriority();
            }
        }

        private void UpdateProcessPriority()
        {
            _process.Priority = Convert.ToInt32(textPriority.Text);
        }

        private void callPriorityUpdateBtn_Click(object sender, EventArgs e)
        {
            _process.LogBox.WriteEvent($"Send PRIORITY UPDATE request.");
            _requestService.SendPriorityUpdateRequest();
        }

        private void initializeSocketBtn_Click(object sender, EventArgs e)
        {
            _process.SourceAddress = new Address(textSourceIp.Text, textSourcePort.Text);
            _process.TargetAddress = new Address(textTargetIp.Text, textTargetPort.Text);

            _configurationService.InitializeSocket(_process, BUFFER_SIZE, OnDataReceived);

            _helperMethods.ChangeTextBoxCollectionReadOnlyStatus(_process.ConfigurationTextBoxes);

            _process.LogBox.WriteEvent($"{textProcessName.Text} initialization finished.");

            pictureBoxConnectionStatus.Image = Resources.status_connected;

            labelConnectionStatus.SetText("Connected");

            _helperMethods.SwitchTwoButtonsEnabledStatus(initializeSocketBtn, stopSocketBtn);

            if (_process.ListOfAddresses.Count == 0)
                ringSynchronizationBtn.Enabled = true;
        }

        private void stopSocketBtn_Click(object sender, EventArgs e)
        {
            _configurationService.StopSocket(_process);

            pictureBoxConnectionStatus.SetImage(Resources.status_notconnected);

            labelConnectionStatus.SetText("Not Connected");

            _helperMethods.SwitchTwoButtonsEnabledStatus(initializeSocketBtn, stopSocketBtn);

            configTextBoxChanged(sender, e);

            _helperMethods.ChangeTextBoxCollectionReadOnlyStatus(_process.ConfigurationTextBoxes);

            _process.LogBox.WriteEvent($"{textProcessName.Text} socket closed.");
        }

        /// <summary>Manages initializeSocketBtn interaction availability by validating if all configuration 
        /// fields are filled in (provided that socket has not been initialized).
        /// </summary>
        private void configTextBoxChanged(object sender, EventArgs e)
        {
            if (_process != null && _process.IsInitialized == false)
            {
                initializeSocketBtn.Enabled = _helperMethods.CheckIfConfigFieldsAreNotEmpty(_process.ConfigurationTextBoxes);
            }
        }

        private void onPingFrequencyValueChange(object sender, EventArgs e)
        {
            UpdatePingFrequencyProperty();
        }

        private void UpdatePingFrequencyProperty()
        {
            _process.PingFrequency = diagnosticPingFrequency.Value;
        }

        private void onReplyTimeOutValueChange(object sender, EventArgs e)
        {
            UpdateReplyTimeOutProperty();
        }

        private void UpdateReplyTimeOutProperty()
        {
            _process.ReplyTimeout = replyTimeout.Value;
        }
    }
}
