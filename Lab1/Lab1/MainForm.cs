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
            colorDialog2.Color = pictureBox1.BackColor;
            this.DoubleBuffered = true;
            //CurrentFigure = 0;
            CurrPen = new Pen(Brushes.DarkRed, 2);

            Layers = new BitMaps();
            //picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Layers[0] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Layers[0].MakeTransparent(Color.White);
            pictureBox1.BackgroundImage = Layers[0];
            grBack = Graphics.FromImage(Layers[0]);

            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            picture.MakeTransparent(Color.White);
            
            grFront = Graphics.FromImage(picture);


            Layers[1] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Layers[1].MakeTransparent(Color.White);
            grTemp = Graphics.FromImage(Layers[1]);
            //var fig = */
            rezpict = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            rezpict.MakeTransparent(Color.White);
            grRez = Graphics.FromImage(rezpict);
            //Layers[2] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Layers[2].MakeTransparent(Color.White);

            pictureBox1.Image = rezpict;

            //pictureBox1.Image = picture;

            //grTemp = pictureBox1.CreateGraphics();

            FigList = new FiguresList();
            FigureList = new RectList();
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
            //FigList[6] = new LetterA(CurrPen, 100, 400, 20);

            FigureList[0] = new Line(CurrPen, 0, 0, 0, 0);
            FigureList[1] = new Rect(CurrPen, 0, 0, 0, 0);
            FigureList[2] = new Ellipce(CurrPen, 0, 0, 0, 0);
            FigureList[3] = new Arc(CurrPen, 0, 0, 0, 0, 0, 0);
            FigureList[4] = new Hexagon(CurrPen, 0, 0, 0, 0);
            FigureList[5] = new RoundRect(CurrPen, 0, 0, 0, 0, 0);
            //FigureList[6] = new LetterA(CurrPen, 0, 0, 0);

            rect = new Rect(CurrPen, 0, 0, 0, 0);

            
            //grFront = Graphics.FromImage(Layers[1]);
            //grTemp = Graphics.FromImage(Layers[2]);
            //grRez = Graphics.FromImage(picture);
        }
        protected Pen CurrPen;
        protected FiguresList FigList;
        protected RectList FigureList;
        private int CurrentFigure = 0;
        protected BitMaps Layers;
        private int OldX, OldY;
        private bool pressed;
        public Rect rect;

        protected Bitmap picture, rezpict;
        public Graphics grBack, grFront, grTemp, grRez;
        //public Graphics grFront;
        


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
            //Graphics grFront = Graphics.FromImage(Layers[1]);

            FigList[CurrentFigure].Draw(grFront);
            //grFront.DrawLine(new Pen(Brushes.Black, 2), 40, 40, 40, 300);
            pictureBox1.Refresh();
        }

        private void rbLine_Click(object sender, EventArgs e) { CurrentFigure = 0; }

        private void rbRect_CheckedChanged(object sender, EventArgs e) { CurrentFigure = 1; }

        private void rbEllipce_CheckedChanged(object sender, EventArgs e) { CurrentFigure = 2; }

        private void rbArc_CheckedChanged(object sender, EventArgs e) { CurrentFigure = 3; }

        private void rbRoundRect_CheckedChanged(object sender, EventArgs e) { CurrentFigure = 4; }

        private void rbHexagon_CheckedChanged(object sender, EventArgs e) { CurrentFigure = 5; }

        private void rbSymbolA_CheckedChanged(object sender, EventArgs e) { CurrentFigure = 6; }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {     

            if (pressed)
            {
                grTemp.Clear(Color.Transparent);
                //grFront.Clear(Color.Transparent);
                FigureList[CurrentFigure].pen = CurrPen;
                FigureList[CurrentFigure].X2 = e.X;
                FigureList[CurrentFigure].Y2 = e.Y;
                FigureList[CurrentFigure].Draw(grTemp);
                // grFront.DrawImage(picture, 0, 0);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(picture, 0, 0);
                grRez.DrawImage(Layers[1], 0, 0);
                //grFront.DrawImage(Layers[1], 0, 0);
                //grTemp.
                //grRez.DrawImage(picture, 0, 0);
                //grRez.DrawImage(Layers[1], 0, 0);
               // grTemp.DrawImage(pictureBox1.BackgroundImage);
                //grTemp.DrawImage(Layers[0], 0, 0);
                //grTemp.DrawImage(Layers[1], 0, 0);
                //grTemp.DrawImage(picture, 0, 0);
                //grRez.DrawImage(picture, 0, 0);
                //pictureBox1.Image = Layers[2];
                //grFront.DrawImage(Layers[2], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            FigureList[CurrentFigure].Draw(grTemp);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(picture, 0, 0);
            grRez.DrawImage(Layers[1], 0, 0);
            grFront.Clear(Color.Transparent);
            //grFront.DrawImage(picture, 0, 0);
            //grFront.DrawImage(Layers[1], 0, 0);
            //grRez.DrawImage(picture, 0, 0);
            //pictureBox1.Image = rezpict;

            pictureBox1.Refresh();
            pressed = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            FigureList[CurrentFigure].X1 = e.X;
            FigureList[CurrentFigure].Y1 = e.Y;
            //grRez.Clear(Color.Transparent);
            grFront.DrawImage(rezpict, 0, 0);
            grTemp.Clear(Color.Transparent);
            //grFront.DrawImage(pictureBox1.Image, 0, 0);
            //pictureBox1.Image = picture;
            pressed = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Graphics grBack = Graphics.FromImage(Layers[0]);
            //Graphics grFront = Graphics.FromImage(Layers[1]);
            grFront.DrawLine(new Pen(Brushes.Black, 2), 20, 20, 320, 320);

            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //grFront.DrawImage(pictureBox1.Image, 0, 0);
            grFront.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                btnBackColor.BackColor = colorDialog2.Color;
                //Graphics g = Graphics.FromImage(Layers[0]);
                Brush brush = new SolidBrush(colorDialog2.Color);
                grBack.FillRectangle(brush, new Rectangle(0, 0, Layers[0].Width, Layers[0].Height));
                pictureBox1.Refresh();
            }
        }
    }
}
