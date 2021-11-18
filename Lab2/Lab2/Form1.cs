using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        Bitmap mapa;
        public Form1()
        {
            InitializeComponent();
            NewBitmap();
        }
        public void NewBitmap()
        {
            mapa = new Bitmap(pictureBox1.Width, pictureBox1.Height);     
            Line(50, 25, 100, 100, Color.Black);
            MidPointLine(10, 10, 200, 200, Color.Black);
            MidpointCircle(100, Color.Red);
        }
        void Line(int x0, int y0, int x1, int y1, Color value)
        {
            int x;
            float dy, dx, y, m;

            dy = y1 - y0;
            dx = x1 - x0;
            m = dy / dx;
            y = y0;
            for (x = x0; x <= x1; x++)
            {
                mapa.SetPixel(x, (int)Math.Floor(y + 0.5), value);
                y += m;
            }
            pictureBox1.Image = mapa;
        }
        void MidPointLine(int x0, int y0, int x1, int y1, Color value)
        {
            int dx, dy, incrE, incrNE, d, x, y;
            dx = x1 - x0;
            dy = y1 - y0;
            d = 2 * dy - dx;
            incrE = dy * 2;
            incrNE = (dy - dx) * 2;
            x = x0;
            y = y0;
            mapa.SetPixel(x, y, value);
            while (x < x1)
            {
                if(d<=0)
                {
                    d += incrNE;
                    x++;
                }
                else
                {
                    d += incrNE;
                    x++;
                    y++;
                }
                mapa.SetPixel(x, y, value);
            }
            pictureBox1.Image = mapa;
        }
        void MidpointCircle(int radius, Color value)
        {
            int x, y;
            float d;

            x = 0;
            y = radius;
            d = 5f / 4f - radius;
            mapa.SetPixel(x, y, value);
            while (y > x)
            {
                if(d < 0)
                {
                    d += x * 2f + 3;
                    x++;
                }
                else
                {
                    d += (x - y) * 2f + 5;
                    x++;
                    y--;
                }
                mapa.SetPixel(x, y, value);
            }
            pictureBox1.Image = mapa;

        }
    }
}
