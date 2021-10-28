using System.Drawing;
using System.Windows.Forms;

namespace Lab1_RGB
{
    public partial class Form1 : Form
    {
        public Image image;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value));
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = "R = " + hScrollBar1.Value.ToString();
            panel1.Invalidate();
            panel2.Invalidate();
            panel3.Invalidate();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = "G = " + hScrollBar2.Value.ToString();
            panel1.Invalidate();
            panel2.Invalidate();
            panel3.Invalidate();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label3.Text = "B = " + hScrollBar3.Value.ToString();
            panel1.Invalidate();
            panel2.Invalidate();
            panel3.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(255 - hScrollBar1.Value, 255 - hScrollBar2.Value, 255 - hScrollBar3.Value));
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            int grayScale = (hScrollBar1.Value + hScrollBar2.Value + hScrollBar3.Value) / 3;
            e.Graphics.Clear(Color.FromArgb(grayScale, grayScale, grayScale));
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
