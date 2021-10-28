using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_Pictures
{
    public partial class Form1 : Form
    {
        Bitmap basePicture, negativePicture, greyPictur;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                basePicture = new Bitmap(openFileDialog1.FileName);
                negativePicture = new Bitmap(basePicture.Width, basePicture.Height);
                greyPictur = new Bitmap(basePicture.Width, basePicture.Height);
                pictureBox1.Image = basePicture;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Color color;
            for (int i = 0; i < basePicture.Width; i++)
            {
                for (int j = 0; j < basePicture.Height; j++)
                {
                    color = basePicture.GetPixel(i, j);
                    int grey = (color.R + color.G + color.B) / 3;
                    Color newColor = Color.FromArgb(grey, grey, grey);
                    greyPictur.SetPixel(i, j, newColor);
                }
            }
            pictureBox3.Image = greyPictur;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color color;
            for (int i = 0; i < basePicture.Width; i++)
            {
                for (int j = 0; j < basePicture.Height; j++)
                {
                    color = basePicture.GetPixel(i, j);
                    Color newColor = Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
                    negativePicture.SetPixel(i, j, newColor);
                }
            }
            pictureBox2.Image = negativePicture;
        }
    }
}
