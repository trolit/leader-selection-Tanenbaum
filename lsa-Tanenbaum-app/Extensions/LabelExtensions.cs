namespace System.Windows.Forms
{
    public static class LabelExtensions
    {
        public static void SetText(this Label label, string text)
        {
            label.Invoke(new MethodInvoker(() =>
            {
                label.Text = text;
            }));
        }
    }
}
