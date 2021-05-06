using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace lsa_Tanenbaum_app
{
    public static class Helpers
    {
        public static void RandomizeProcessIdentity(TextBox textBox, Random randomizer)
        {
            textBox.Text = "P-" + randomizer.Next(1000, 9999);
        }

        public static string RemoveZeroCharactersFromString(string text)
        {
            return text.Replace("\0", "");
        }

        public static void ChangeTextBoxCollectionReadOnlyStatus(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.ReadOnly = !textBox.ReadOnly;
            }
        }

        // pattern: LIST:|IP:Port:Priority|IP:Port:Priority|
        // The string split method will have the first element as String.Empty
        // if your delimiter appears at the beginning of the string. 
        // source: https://stackoverflow.com/questions/28901249/why-split-function-doesnt-return-a-null-at-the-first-of-this-string
        public static (List<IPEndPoint>, List<int>) TranslateDataFromProcessesTmpContainer(string processesTmpContainer)
        {
            if (processesTmpContainer.Length <= 5)
            {
                return (null, null);
            }

            List<IPEndPoint> addresses = new List<IPEndPoint>();
            List<int> priorities = new List<int>();

            string text = processesTmpContainer.Remove(0, 5);
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
    }
}
