using System.Drawing;

namespace System.Windows.Forms
{
    public static class PictureBoxExtensions
    {
        public static void SetImage(this PictureBox pictureBox, Image image)
        {
            pictureBox.Invoke(new MethodInvoker(() => 
            {
                pictureBox.Image = image;
            }));
        }
    }
}
