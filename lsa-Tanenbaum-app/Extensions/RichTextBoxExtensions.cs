using System.Drawing;

namespace System.Windows.Forms
{
    // idea from: https://stackoverflow.com/a/1926822
    public static class RichTextBoxExtensions
    {
        public static bool AppendText(this RichTextBox box, DateTime date, string text)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = Color.Blue;
            box.AppendText($"[{GetCurrentTimeStamp(date)}]");
            box.SelectionColor = box.ForeColor;

            box.SelectionColor = Color.Black;
            box.AppendText($" {text}\n");

            return true;
        }

        private static string GetCurrentTimeStamp(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }
    }
}
