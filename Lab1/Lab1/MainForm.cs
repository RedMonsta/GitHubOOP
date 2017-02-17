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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CurrentFigure = 0;
            CurrPen = new Pen(Brushes.DarkRed, 2);


            Layers = new BitMaps();
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Layers[0] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Layers[0].MakeTransparent(Color.White);
            /*for (int x = 0; x < Layers[0].Width; x++)
            {
                for (int y = 0; y < Layers[0].Height; y++)
                {
                    Layers[0].SetPixel(x, y, Color.Aqua);
                }
            }*/

            Layers[1] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Layers[1].MakeTransparent(Color.White);
            //var fig = */

            pictureBox1.Image = Layers[1];
            pictureBox1.BackgroundImage = Layers[0];



            FigList = new FiguresList();
            //var pen = new Pen(Brushes.DarkRed, 2);

            FigList[0] = new Line(CurrPen, 0, 0, 600, 10);
            CurrPen.Brush = Brushes.DarkSeaGreen;
            FigList[1] = new Rect(CurrPen, 400, 200, 700, 300);
            CurrPen.Brush = Brushes.Black;
            FigList[2] = new Ellipce(CurrPen, 20, 20, 130, 170);
            CurrPen.Brush = Brushes.Firebrick;
            FigList[3] = new Arc(CurrPen, 100, 100, 200, 200, 30, 150);
            CurrPen.Brush = Brushes.Yellow;
            FigList[4] = new Hexagon(CurrPen, 200, 100, 300, 400);
            CurrPen.Brush = Brushes.White;
            FigList[5] = new RoundRect(CurrPen, 420, 220, 680, 280, 25);
            CurrPen.Brush = Brushes.BlueViolet;
            FigList[6] = new LetterA(CurrPen, 100, 400, 20);

        }
        protected Pen CurrPen;
        protected FiguresList FigList;
        private int CurrentFigure;
        protected BitMaps Layers;
        protected Bitmap picture;
        public Graphics grBack { get; set; }
        public Graphics grFront { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {

            /*var FigList = new FiguresList();
            var pen = new Pen(Brushes.DarkRed, 2);

            FigList[0] = new Line(pen, 0, 0, 600, 10);
            pen.Brush = Brushes.DarkSeaGreen;
            FigList[1] = new Rect(pen, 400, 200, 700, 300);
            pen.Brush = Brushes.Black;
            FigList[2] = new Ellipce(pen, 20, 20, 130, 170);
            pen.Brush = Brushes.Firebrick;
            FigList[3] = new Arc(pen, 100, 100, 200, 200, 30, 150);
            pen.Brush = Brushes.Yellow;
            FigList[4] = new Hexagon(pen, 200, 100, 300, 400);
            pen.Brush = Brushes.White;
            FigList[5] = new RoundRect(pen, 420, 220, 680, 280, 25);
            pen.Brush = Brushes.BlueViolet;
            FigList[6] = new LetterA(pen, 100, 400, 20);*/

            FigList.DrawAll(pictureBox1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                CurrPen.Color = colorDialog1.Color;
            }
        }

        private void btnDrawOne_Click(object sender, EventArgs e)
        {
            /*var FigList = new FiguresList();
            var pen = new Pen(Brushes.DarkRed, 2);

            FigList[0] = new Line(pen, 0, 0, 600, 10);
            pen.Brush = Brushes.DarkSeaGreen;
            FigList[1] = new Rect(pen, 400, 200, 700, 300);
            pen.Brush = Brushes.Black;
            FigList[2] = new Ellipce(pen, 20, 20, 130, 170);
            pen.Brush = Brushes.Firebrick;
            FigList[3] = new Arc(pen, 100, 100, 200, 200, 30, 150);
            pen.Brush = Brushes.Yellow;
            FigList[4] = new Hexagon(pen, 200, 100, 300, 400);
            pen.Brush = Brushes.White;
            FigList[5] = new RoundRect(pen, 420, 220, 680, 280, 25);
            pen.Brush = Brushes.BlueViolet;
            FigList[6] = new LetterA(pen, 100, 400, 20);*/

            //FigList[CurrentFigure].pen = CurrPen;
            //FigList[CurrentFigure].Draw(pictureBox1); 

           
             
            Graphics grFront = Graphics.FromImage(Layers[1]);



            grFront.DrawLine(new Pen(Brushes.Black, 2), 40, 40, 40, 300);
            pictureBox1.Refresh();
        }

        private void rbLine_Click(object sender, EventArgs e)
        {
            CurrentFigure = 0;
        }

        private void rbRect_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFigure = 1;
        }

        private void rbEllipce_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFigure = 2;
        }

        private void rbArc_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFigure = 3;
        }

        private void rbRoundRect_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFigure = 4;
        }

        private void rbHexagon_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFigure = 5;
        }

        private void rbSymbolA_CheckedChanged(object sender, EventArgs e)
        {
            CurrentFigure = 6;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Graphics grBack = Graphics.FromImage(Layers[0]);
            Graphics grFront = Graphics.FromImage(Layers[1]);

            

            grFront.DrawLine(new Pen(Brushes.Black, 2), 20, 20, 320, 320);

            pictureBox1.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            var rect = new Rect(CurrPen, 0, 0, 100, 100);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            rect.Draw(g);
        }
    }
}
