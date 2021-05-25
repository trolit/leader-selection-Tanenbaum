namespace System.Windows.Forms
{
    public static class TextBoxExtensions
    {
        public static void SetText(this TextBox textBox, string text)
        {
            textBox.Invoke(new MethodInvoker(() =>
            {
                textBox.Text = text;
            }));
        }
    }
}
