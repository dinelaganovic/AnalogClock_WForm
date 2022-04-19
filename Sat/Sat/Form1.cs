using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush bk = new SolidBrush(Color.FromArgb(249, 189, 93));
            Graphics g = e.Graphics;
            Pen pn = new Pen(Color.Black, 0);
            Rectangle rect2 = new Rectangle(2, 12, 580, 580);
            e.Graphics.DrawEllipse(pn, rect2);
            Image myImage = Image.FromFile("C:\\Users\\PC\\source\\repos\\Sat\\Sat\\Resources\\okvir.jpg");
            TextureBrush myTextureBrush = new TextureBrush(myImage);
            g.FillEllipse(myTextureBrush, 2,12, 580, 580);//elipsa slika
            g.FillEllipse(bk, 17, 29, 550, 550); //elipsa 1 boja

            g.DrawEllipse(new Pen(Color.Black, 1), 70, 85 ,450, 450); //elipsa 2

            //brojevi
            g.DrawString("12", new Font("Ariel", 15), Brushes.Black, new PointF(280, 100));
            g.DrawString("1", new Font("Ariel", 15), Brushes.Black, new PointF(390, 120));
            g.DrawString("2", new Font("Ariel", 15), Brushes.Black, new PointF(460, 175));
            g.DrawString("3", new Font("Ariel", 15), Brushes.Black, new PointF(490, 300));
            g.DrawString("4", new Font("Ariel", 15), Brushes.Black, new PointF(470, 405));
            g.DrawString("5", new Font("Ariel", 15), Brushes.Black, new PointF(395,480));
            g.DrawString("6", new Font("Ariel", 15), Brushes.Black, new PointF(285, 510));
            g.DrawString("7", new Font("Ariel", 15), Brushes.Black, new PointF(175, 480));
            g.DrawString("8", new Font("Ariel", 15), Brushes.Black, new PointF(100, 405));
            g.DrawString("9", new Font("Ariel", 15), Brushes.Black, new PointF(80, 290));
            g.DrawString("10", new Font("Ariel", 15), Brushes.Black, new PointF(110, 190));
            g.DrawString("11", new Font("Ariel", 15), Brushes.Black, new PointF(175, 115));

            //minute i sekunde
            g.SmoothingMode = SmoothingMode.AntiAlias;
         
            // translacija oko centra
            g.TranslateTransform(
                ClientSize.Width / 2,
                ClientSize.Height / 2);

            DrawClockFace(g);
            
            // centar
            g.FillEllipse(Brushes.Black, -5, -5, 10, 10);

            // strelice
            Pen pennn = new Pen(Color.Black, 8);
            pennn.StartCap = LineCap.ArrowAnchor;
            pennn.EndCap = LineCap.RoundAnchor;
            g.DrawLine(pennn, 60, 50, 0, 0);
            g.DrawLine(pennn, 150, 10, 0, 0);

            //stringovi
            String drawString = "Analogni sat";
            Font drawFont = new Font("Times New Roman", 30);
            SolidBrush drawBrush = new SolidBrush(Color.Brown);
            StringFormat drawFormat = new StringFormat();
            int x = -101;
            int y = 100;
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;
            g.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            //gornji string
            Pen pn1 = new Pen(Color.SaddleBrown, 50);
            g.DrawLine(pn1, -100, -100, 100, -100);
            SolidBrush bkk = new SolidBrush(Color.SaddleBrown);
            Rectangle rect3 = new Rectangle(-60, -140, 120, 70);
            Rectangle rect4 = new Rectangle(-60, -130, 120, 70);
            g.FillEllipse(bkk,rect3 );
            g.FillEllipse(bkk, rect4);
            Font drawFont1 = new Font("Lucida Calligraphy", 20);
            g.DrawString("Royal", drawFont1, new SolidBrush(Color.Wheat),-40, -115);
        }
        private void DrawClockFace(Graphics gr)
        {
            // Draw.
            using (Pen thick_pen = new Pen(Color.Black, 4))
            {
                // Get scale factors.
                float outer_x_factor = 0.45f * ClientSize.Width;
                float outer_y_factor = 0.45f * ClientSize.Height;
                float inner_x_factor = 0.425f * ClientSize.Width;
                float inner_y_factor = 0.425f * ClientSize.Height;
                float big_x_factor = 0.4f * ClientSize.Width;
                float big_y_factor = 0.4f * ClientSize.Height;

                // Draw the tick marks.
                thick_pen.StartCap = LineCap.Triangle;
                for (int minute = 1; minute <= 60; minute++)
                {
                    double angle = Math.PI * minute / 30.0;
                    float cos_angle = (float)Math.Cos(angle);
                    float sin_angle = (float)Math.Sin(angle);
                    PointF outer_pt = new PointF(
                        outer_x_factor * cos_angle,
                        outer_y_factor * sin_angle);
                    if (minute % 5 == 0)
                    {
                        PointF inner_pt = new PointF(
                            big_x_factor * cos_angle,
                            big_y_factor * sin_angle);
                        gr.DrawLine(thick_pen, inner_pt, outer_pt);
                    }
                    else
                    {
                        PointF inner_pt = new PointF(
                            inner_x_factor * cos_angle,
                            inner_y_factor * sin_angle);
                        gr.DrawLine(Pens.Black, inner_pt, outer_pt);
                    }
                }
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}

