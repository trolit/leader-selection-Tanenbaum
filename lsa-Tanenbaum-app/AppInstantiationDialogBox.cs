using System;
using System.Threading;
using System.Windows.Forms;

namespace lsa_Tanenbaum_app
{
    public partial class AppInstantiationDialogBox : Form
    {
        private HelperMethods _helpers;

        private Form1 _dialogBoxInvokerRef;

        public AppInstantiationDialogBox(HelperMethods helpers, Form1 dialogBoxInvoker)
        {
            InitializeComponent();

            _helpers = helpers;

            _dialogBoxInvokerRef = dialogBoxInvoker;

            baseIpTextBox.Text = _helpers.GetLocalAddress();
        }

        private void executeBtn_Click(object sender, EventArgs e)
        {
            int numberOfInstances = (int) numberOfInstancesNumeric.Value;
            int currentSourcePort = Convert.ToInt32(basePortTextBox.Text);
            string baseIp = baseIpTextBox.Text.ToString();
            int lastIteration = numberOfInstances - 1;

            UpdateFormInvokingDialogBox(baseIp, currentSourcePort.ToString(), (currentSourcePort + 1).ToString());

            for (int i = 0; i < numberOfInstancesNumeric.Value; i++)
            {
                currentSourcePort++;
                int currentTargetPort = currentSourcePort + 1;

                Form1 form1 = new Form1();

                if (i == lastIteration)
                {
                    form1.textTargetPort.Text = (currentTargetPort - (numberOfInstances + 1)).ToString();
                }

                var thread = new Thread(() => ThreadStart(form1));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }

            Dispose();
        }

        private void UpdateFormInvokingDialogBox(string baseIp, string sourcePort, string targetPort)
        {
            _dialogBoxInvokerRef.textSourceIp.Text = _dialogBoxInvokerRef.textTargetIp.Text = baseIp;

            _dialogBoxInvokerRef.textSourcePort.Text = sourcePort;
            _dialogBoxInvokerRef.textTargetPort.Text = targetPort;

            _dialogBoxInvokerRef.initializeSocketBtn.Enabled = true;
            _dialogBoxInvokerRef.initializeSocketBtn.PerformClick();
        }

        private void ThreadStart(Form1 form1)
        {
            Application.Run(form1);
        }
    }
}
