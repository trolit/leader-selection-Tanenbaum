using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace lsa_Tanenbaum_app
{
    public class HelperMethods
    {
        private Random _randomizer;
        private ASCIIEncoding _encoding;

        public HelperMethods()
        {
            _randomizer = new Random();
            _encoding = new ASCIIEncoding();
        }

        public void RandomizeProcessIdentity(TextBox textBox)
        {
            textBox.Text = "P-" + _randomizer.Next(1000, 9999);
        }

        public string RemoveZeroCharactersFromString(string text)
        {
            return text.Replace("\0", "");
        }

        public void ChangeTextBoxCollectionReadOnlyStatus(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.ReadOnly = !textBox.ReadOnly;
            }
        }

        public byte[] PackMessage(string message)
        {
            return _encoding.GetBytes(
                RemoveZeroCharactersFromString(message)
            );
        }

        public string UnpackMessage(byte[] message)
        {
            return RemoveZeroCharactersFromString(
                _encoding.GetString(message)
            );
        }

        public string GetCurrentTimeStamp(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        public IPEndPoint BuildIPEndPoint(string address, string port)
        {
            return new IPEndPoint(IPAddress.Parse(address), Convert.ToInt32(port));
        }

        // pattern: HEADER:|IP:Port:Priority|IP:Port:Priority|
        // The string split method will have the first element as String.Empty
        // if your delimiter appears at the beginning of the string. 
        // source: https://stackoverflow.com/questions/28901249/why-split-function-doesnt-return-a-null-at-the-first-of-this-string
        public (List<IPEndPoint>, List<int>) TranslateDataFromMessage(string header, string message)
        {
            if (String.IsNullOrWhiteSpace(header) || String.IsNullOrWhiteSpace(message))
            {
                return (null, null);
            }

            List<IPEndPoint> addresses = new List<IPEndPoint>();
            List<int> priorities = new List<int>();

            string text = message.Replace(header, "");
            string[] splitText = text.Split('|', ':');

            int addrPtr = 1;
            int portPtr = 2;
            int priorityPtr = 3;

            for (int i = 0; i < splitText.Length; i++)
            {
                if (priorityPtr >= splitText.Length) 
                    break;

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(splitText[addrPtr]), Convert.ToInt32(splitText[portPtr]));
                int priority = Convert.ToInt32(splitText[priorityPtr]);
                addresses.Add(endPoint);
                priorities.Add(priority);

                addrPtr += 3;
                portPtr += 3;
                priorityPtr += 3;
            }

            return (addresses, priorities);
        }

        public void SwitchTwoButtonsEnabledStatus(Button button1, Button button2)
        {
            button1.Enabled = !button1.Enabled;
            button2.Enabled = !button2.Enabled;
        }

        public string GetLocalAddress()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        public bool CheckIfConfigFieldsAreNotEmpty(TextBox[] configurationTextBoxes)
        {
            bool result = true;

            if (configurationTextBoxes != null)
            {
                foreach (TextBox configField in configurationTextBoxes)
                {
                    if (string.IsNullOrWhiteSpace(configField.Text))
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
