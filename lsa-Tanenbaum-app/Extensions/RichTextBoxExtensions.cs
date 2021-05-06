using System.Drawing;

namespace System.Windows.Forms
{
    // idea from: https://stackoverflow.com/a/1926822
    public static class RichTextBoxExtensions
    {
        public static bool AppendText(this RichTextBox box, string text)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = Color.Blue;
            box.AppendText($"[{GetCurrentTimeStamp(DateTime.Now)}]");
            box.SelectionColor = box.ForeColor;

            box.SelectionColor = Color.Black;
            box.AppendText($" {text}");

            box.AppendText(Environment.NewLine);
            box.ScrollToCaret();

            return true;
        }

        public static bool AppendNewLine(this RichTextBox box)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.AppendText(Environment.NewLine);
            box.ScrollToCaret();
            return true;
        }

        private static string GetCurrentTimeStamp(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }
    }
}
