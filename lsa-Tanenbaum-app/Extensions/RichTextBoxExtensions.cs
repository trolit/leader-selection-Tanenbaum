using System.Drawing;

namespace System.Windows.Forms
{
    // idea from: https://stackoverflow.com/a/1926822
    public static class RichTextBoxExtensions
    {
        public static void WriteEvent(this RichTextBox box, string text)
        {
            box.Invoke(new MethodInvoker(() =>
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = Color.Blue;
                box.AppendText($"[{GetTimeStamp(DateTime.Now)}]");
                box.SelectionColor = box.ForeColor;

                box.SelectionColor = Color.Black;
                box.AppendText($" {text}");

                box.AppendText(Environment.NewLine);
                box.ScrollToCaret();
            }));
        }

        public static void BreakLine(this RichTextBox box)
        {
            box.Invoke(new MethodInvoker(() => 
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.AppendText(Environment.NewLine);
                box.ScrollToCaret();
            }));
        }

        private static string GetTimeStamp(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }
    }
}
