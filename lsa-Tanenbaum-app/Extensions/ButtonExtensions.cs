namespace System.Windows.Forms
{
    public static class ButtonExtensions
    {
        public static void ReverseEnabledStatus(this Button button)
        {
            button.Invoke(new MethodInvoker(() =>
            {
                button.Enabled = !button.Enabled;
            }));
        }

        public static void Disable(this Button button)
        {
            button.Invoke(new MethodInvoker(() =>
            {
                button.Enabled = false;
            }));
        }
    }
}
