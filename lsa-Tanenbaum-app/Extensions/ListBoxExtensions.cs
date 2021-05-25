using System.Collections.Generic;

namespace System.Windows.Forms
{
    public static class ListBoxExtensions
    {
        public static void UpdateCollection<T>(this ListBox listBox, List<T> newCollection)
        {
            listBox.Invoke(new MethodInvoker(() =>
            {
                if (listBox.DataSource != null)
                    listBox.DataSource = new List<T>();

                listBox.DataSource = newCollection;
            }));
        }
    }
}
