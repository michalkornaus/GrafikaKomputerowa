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
        public bool przepisz = false;
        public int X, Y;
        List <Point> pathPoints = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect1 = new Rectangle(new Point(500, 50), new Size(50, 50));
            Rectangle rect2 = new Rectangle(new Point(550, 50), new Size(50, 50));
            Rectangle rect3 = new Rectangle(new Point(525, 115), new Size(50, 100));
            e.Graphics.DrawEllipse(Pens.CornflowerBlue, rect1);
            e.Graphics.DrawPie(Pens.DarkGray, rect1, 50f, 180f);
            e.Graphics.DrawEllipse(Pens.CornflowerBlue, rect2);
            e.Graphics.DrawPie(Pens.DarkGray, rect2, -50f, 180f);
            e.Graphics.DrawEllipse(Pens.Red, rect3);
            if (show == true)
            {
                /*e.Graphics.DrawLine(Pens.Red, 10, 10, 200, 200);
                Rectangle rect = new Rectangle(new Point(50, 50), new Size(50, 50));
                e.Graphics.DrawEllipse(Pens.CornflowerBlue, rect);*/
                Point[] points = new Point[3]
                 {
                    new Point(500, 200),
                    new Point(550, 250),
                    new Point(600, 200),
                 };
                e.Graphics.DrawCurve(Pens.Green, points);
                if (pathPoints.Count > 1)
                {
                    e.Graphics.DrawPolygon(Pens.DarkTurquoise, pathPoints.ToArray());
                    e.Graphics.FillPolygon(Brushes.Red, pathPoints.ToArray());
                }        
            }
            else
            {
                Point[] points = new Point[3]
                {
                    new Point(500, 300),
                    new Point(550, 250),
                    new Point(600, 300),
                };
                e.Graphics.DrawCurve(Pens.Green, points);
                if (pathPoints.Count > 1)
                    e.Graphics.DrawLines(Pens.DarkTurquoise, pathPoints.ToArray());
            }
            int radius = 300;
            e.Graphics.DrawEllipse(Pens.IndianRed, X - (radius / 2), Y - (radius / 2), radius, radius);
            if(przepisz)
            {
                DrawStringPoint(e);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show = !show;
            panel1.Invalidate();
        }
        public void DrawStringPoint(PaintEventArgs e)
        {
            string drawString = textBox1.Text;
            Font drawFont = new Font("Arial", 17);
            SolidBrush drawBush = new SolidBrush(Color.Pink);
            Point drawPoint = new Point(150, 150);
            e.Graphics.DrawString(drawString, drawFont, drawBush, drawPoint);
            przepisz = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            przepisz = true;
            panel1.Invalidate();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            X = e.X; Y = e.Y;
            pathPoints.Add(new Point(e.X, e.Y));
            panel1.Invalidate();
        }
    }
}
