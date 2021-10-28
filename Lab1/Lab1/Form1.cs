using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public bool show = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (show == true)
            {
                e.Graphics.DrawLine(Pens.Red, 10, 10, 200, 200);
                Rectangle rect = new Rectangle(new Point(50, 50), new Size(50, 50));
                
                e.Graphics.DrawEllipse(Pens.CornflowerBlue, rect);
               
            }
            else
            {
                Rectangle rect1 = new Rectangle(new Point(500, 50), new Size(50, 50));
                Rectangle rect2 = new Rectangle(new Point(550, 50), new Size(50, 50));
                Rectangle rect3 = new Rectangle(new Point(525, 75), new Size(50, 100));
                e.Graphics.DrawEllipse(Pens.CornflowerBlue, rect1);
                e.Graphics.DrawPie(Pens.DarkGray, rect1, 50f, 180f);
                e.Graphics.DrawEllipse(Pens.CornflowerBlue, rect2);
                e.Graphics.DrawPie(Pens.DarkGray, rect2, 50f, 180f);
                e.Graphics.DrawEllipse(Pens.Red, rect3);
                Point[] points = new Point[3]
                {
                    new Point(500, 200),
                    new Point(550, 250),
                    new Point(600, 200),
                };
                e.Graphics.DrawCurve(Pens.Green, points);
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show = !show;
            panel1.Invalidate();
        }
    }
}
