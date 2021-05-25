namespace System.Windows.Forms
{
    public static class GroupBoxExtensions
    {
        public static void Display(this GroupBox groupBox)
        {
            groupBox.Invoke(new MethodInvoker(() =>
            {
                groupBox.Visible = true;
            }));
        }

        public static void SetText(this GroupBox groupBox, string text)
        {
            groupBox.Invoke(new MethodInvoker(() =>
            {
                groupBox.Text = text;
            }));
        }
    }
}
