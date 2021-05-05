using System;
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
    }
}
