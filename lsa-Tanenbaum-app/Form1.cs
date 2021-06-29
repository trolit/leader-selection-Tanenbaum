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
using static lsa_Tanenbaum_app.LogSymbols;
using lsa_Tanenbaum_app.Requests;

/* 
 * ---------------------------------------------------------------------------
 * 
 * Leader Selection Algorithm 2021, Tanenbaum's variant
 * Author: Pawel Idzikowski
 * Repository: https://github.com/trolit/leader-selection-Tanenbaum
 * App icon made by Becris, https://www.flaticon.com/authors/becris 
 * 
 * ---------------------------------------------------------------------------
 */

namespace lsa_Tanenbaum_app
{
    public partial class Form1 : Form
    {
        #region Declarations

        private const int BUFFER_SIZE = 1500;
        private byte[] _buffer;

        private Process _process;

        private HelperMethods _helpers;

        private ConfigurationService _configurationService;
        private RequestService _requestService;
        private TimerService _timerService;

        private int _lastKnowledgeGroupBoxYLocation;

        #endregion

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
            _helpers = new HelperMethods();
            _configurationService = new ConfigurationService();
            _helpers.RandomizeProcessIdentity(textProcessName);

            _process = new Process()
            {
                Id = textProcessName.Text,
                ConfigurationTextBoxes = new TextBox[] { textProcessName, textSourceIp, textSourcePort, textTargetIp, textTargetPort },
                LogBox = logBox,
                Priority = Convert.ToInt32(textPriority.Text),
                SynchronizationContainer = Configuration,
                DisableDiagnosticPingButton = disableDiagnosticPingBtn
            };

            _lastKnowledgeGroupBoxYLocation = knowledgeGroupBox.Location.Y;

            _requestService = new RequestService(_helpers, _process);
            _timerService = new TimerService(_process, _requestService);

            // put user IP
            textSourceIp.Text = _helpers.GetLocalAddress();
            textTargetIp.Text = _helpers.GetLocalAddress();

            _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} Process {System.Diagnostics.Process.GetCurrentProcess().Id}({textProcessName.Text}) initialized.");
        }

        private void UpdateProcessTitle()
        {
            Text = $"{textProcessName.Text} | {textSourceIp.Text}:{textSourcePort.Text}";
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
                    string receivedMessage = _helpers.UnpackMessage(receivedData);

                    // Setup callback again
                    _buffer = new byte[BUFFER_SIZE];
                    _process.Socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnDataReceived, _buffer);

                    switch (receivedMessage)
                    {
                        case string configurationMessage when receivedMessage.Contains(Configuration):
                            {
                                _process.SynchronizationContainer = configurationMessage;
                                ringSynchronizationBtn.Disable();

                                if (_process.SynchronizationContainer.Contains($"{_process.SourceIPEndPoint}"))
                                {
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} synchronization request returned to the initiator.");
                                    _process.IsRingObtained = true;

                                    // pass obtained ring further
                                    UpdateKnowledgeSection(Configuration, _process.SynchronizationContainer);
                                    _requestService.SendRingList();
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} synchronization request.");
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
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} ring structure.");
                                    _requestService.SendRingList();
                                } else
                                {
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} ring structure returned to the sync caller.");
                                    _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} message removed.");
                                }

                                UpdateInterfaceOnCompletedRingSynchronization();
                            }
                            break;

                        case string priorityMessage when receivedMessage.Contains(Priority):
                            {
                                _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} priority update request.");
                                if (priorityMessage.Contains($"{textSourceIp.Text}:{textSourcePort.Text}"))
                                {
                                    _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} update knowledge and remove message.");
                                    UpdatePriorityInListBox(priorityMessage);
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} update knowledge.");
                                    _process.LogBox.WriteEvent($"{SEND_SYMBOL} send update request further.");
                                    UpdatePriorityInListBox(priorityMessage);

                                    _process.Socket.SendTo(receivedData, _process.TargetEndPoint);
                                }
                            }
                            break;

                        case string echoRequestMessage when receivedMessage.Contains(EchoRequest):
                            {
                                string cutMessage = echoRequestMessage.Replace(EchoRequest, "");
                                _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} echo request from {cutMessage}.");
                                _requestService.SendEchoReply(cutMessage);
                            }
                            break;

                        case string echoReplyMessage when receivedMessage.Contains(EchoReply):
                            {
                                string cutMessage = echoReplyMessage.Replace(EchoReply, "");

                                if (echoReplyMessage.Contains(_process.RingCoordinatorIP.ToString()) && !_process.IsElectionRaised)
                                {
                                    _timerService.StopDiagnosticPingCoordinatorTimeoutTimer();
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} echo reply from {cutMessage}.");
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} election ping response from {cutMessage}");

                                    if (_process.ElectionRequestsContainer.Count > 0)
                                    {
                                        ElectionRequest electionRequest = _process.ElectionRequestsContainer.First();
                                        electionRequest.CompleteNextProcessFindingStage();
                                        _process.ElectionRequestsContainer.Remove(electionRequest);
                                    }
                                } 
                            }
                            break;

                        case string electionMessage when receivedMessage.Contains(Election):
                            {
                                _process.LogBox.BreakLine();
                                if (electionMessage.Contains($"{_process.Id}"))
                                {
                                    // election message returned to the process that initialized it
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} election message \n[{electionMessage}]");

                                    electionMessage = electionMessage.Replace(_process.Id, "");

                                    // 1. translate data
                                    UpdateKnowledgeSection(Election, electionMessage);

                                    // 2. choose leader
                                    SelectRingCoordinator();

                                    // 3. update ring coordinator label
                                    UpdateRingCoordinatorLabel();

                                    // 4. send COORDINATOR message and new ring structure
                                    _requestService.InitiateCoordinatorMessage(electionMessage);
                                }
                                else
                                {                         
                                    // pass election message further
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} election message \n[{electionMessage}]");
                                    _requestService.SendElectionRequest(electionMessage);
                                }
                            }
                            break;

                        case string coordinatorMessage when receivedMessage.Contains(Coordinator):
                            {
                                if (coordinatorMessage.Contains(_process.Id))
                                {
                                    coordinatorMessage = coordinatorMessage.Replace(_process.Id, "");

                                    UpdateTargetIntel();
                                    _process.LogBox.BreakLine();
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} coordinator message returned to election initiator.");
                                    _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} message removed.");
                                }
                                else
                                {
                                    _process.LogBox.WriteEvent($"{RECEIVE_SYMBOL} coordinator message. Updating knowledge.");
                                    UpdateKnowledgeSection(Coordinator, coordinatorMessage);
                                    SelectRingCoordinator();
                                    UpdateTargetIntel();
                                    UpdateRingCoordinatorLabel();
                                    _process.LogBox.WriteEvent($"{SEND_SYMBOL} send coordinator message further.");
                                    _requestService.SendCoordinatorMessage(coordinatorMessage);
                                }

                                if (_process.ElectionRequestsContainer.Count == 0)
                                {
                                    _process.IsElectionRaised = false;
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
            (List<IPEndPoint>, List<int>) data = _helpers.TranslateDataFromMessage(header, source);
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
            UpdateGroupBoxesOnCoordinatorSelection();
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

            _process.UpdateTarget(_helpers, newConsequentAddress, newConsequentPort);
        }

        private void SelectRingCoordinator()
        {
            int highestPriority = _process.ListOfPriorities.Max();
            int highestPriorityId = _process.ListOfPriorities.IndexOf(highestPriority);
            _process.RingCoordinatorIP = _process.ListOfAddresses[highestPriorityId];
            UpdateGroupBoxesOnCoordinatorSelection();
        }

        private void UpdateRingCoordinatorLabel()
        {
            int highestPriorityId = _helpers.GetIdOfHighestPriorityInList(_process.ListOfPriorities);
            ringCoordinatorAddressText.SetText(_process.RingCoordinatorIP.ToString());
            ringCoordinatorPriorityText.SetText($"with priority {_process.ListOfPriorities[highestPriorityId]} ({_helpers.GetCurrentTimeStamp(DateTime.Now)})");
        }

        private void UpdateGroupBoxesOnCoordinatorSelection()
        {
            Invoke(new MethodInvoker(() => {
                bool isRingCoordinator = _process.RingCoordinatorIP.ToString().Contains(_process.SourceIPEndPoint.ToString());
                diagnosticPingGroupBox.Visible = !isRingCoordinator;
                int newYLocation = isRingCoordinator ? 200 : _lastKnowledgeGroupBoxYLocation;
                knowledgeGroupBox.Location = new Point(knowledgeGroupBox.Location.X, newYLocation);
            }));
        } 

        private void UpdatePriorityInListBox(string message)
        {
            // pattern: PRIORITY:192....:80:10
            string[] splitMessage = message.Replace(Priority, "").Split(':');
            IPEndPoint address = _helpers.BuildIPEndPoint(splitMessage[0], splitMessage[1]);
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
            _helpers.SwitchTwoButtonsEnabledStatus(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
        }

        private void deactivateDiagnosticPingBtn_Click(object sender, EventArgs e)
        {
            if (_timerService.diagnosticPingTimer != null)
            {
                _timerService.diagnosticPingTimer.Stop();
                _helpers.SwitchTwoButtonsEnabledStatus(enableDiagnosticPingBtn, disableDiagnosticPingBtn);
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
            _requestService.SendPriorityUpdateRequest();
        }

        private void initializeSocketBtn_Click(object sender, EventArgs e)
        {
            _process.SourceAddress = new Address(textSourceIp.Text, textSourcePort.Text);
            _process.TargetAddress = new Address(textTargetIp.Text, textTargetPort.Text);

            _configurationService.InitializeSocket(_process, BUFFER_SIZE, OnDataReceived);

            _helpers.ChangeTextBoxCollectionReadOnlyStatus(_process.ConfigurationTextBoxes);

            _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} {textProcessName.Text} initialization finished.");

            pictureBoxConnectionStatus.Image = Resources.status_connected;

            labelConnectionStatus.SetText("Connected");

            _helpers.SwitchTwoButtonsEnabledStatus(initializeSocketBtn, stopSocketBtn);

            UpdateProcessTitle();

            if (_process.ListOfAddresses.Count == 0)
                ringSynchronizationBtn.Enabled = true;
        }

        private void stopSocketBtn_Click(object sender, EventArgs e)
        {
            _configurationService.StopSocket(_process);

            pictureBoxConnectionStatus.SetImage(Resources.status_notconnected);

            labelConnectionStatus.SetText("Not Connected");

            _helpers.SwitchTwoButtonsEnabledStatus(initializeSocketBtn, stopSocketBtn);

            configTextBoxChanged(sender, e);

            _helpers.ChangeTextBoxCollectionReadOnlyStatus(_process.ConfigurationTextBoxes);

            _process.LogBox.WriteEvent($"{SOURCE_SYMBOL} {textProcessName.Text} socket closed.");
        }

        /// <summary>Manages initializeSocketBtn interaction availability by validating if all configuration 
        /// fields are filled in (provided that socket has not been initialized yet).
        /// </summary>
        private void configTextBoxChanged(object sender, EventArgs e)
        {
            if (_process != null && _process.IsInitialized == false)
            {
                initializeSocketBtn.Enabled = _helpers.CheckIfConfigFieldsAreNotEmpty(_process.ConfigurationTextBoxes);
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
