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
            CurrPen = new Pen(Brushes.DarkRed, 2);

            Layers = new BitMaps();
            Layers[0] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grBack = Graphics.FromImage(Layers[0]);
            Layers[1] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grRez = Graphics.FromImage(Layers[1]);
            Layers[2] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grFront = Graphics.FromImage(Layers[2]);
            Layers[3] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grTemp = Graphics.FromImage(Layers[3]);
            Layers[4] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grLast = Graphics.FromImage(Layers[4]);
            pictureBox1.BackgroundImage = Layers[0];
            pictureBox1.Image = Layers[1];

            FigList = new FiguresList();
            FigureList = new DynamicFigList();
            FigList[0] = new Line(CurrPen, 0, 0, 600, 10);
            CurrPen.Brush = Brushes.DarkSeaGreen;
            FigList[1] = new Rect(CurrPen, 400, 200, 700, 300);
            CurrPen.Brush = Brushes.Black;
            FigList[2] = new Ellipce(CurrPen, 20, 20, 130, 170);
            CurrPen.Brush = Brushes.Firebrick;
            FigList[3] = new IsoTriangle(CurrPen, 100, 100, 200, 200);
            CurrPen.Brush = Brushes.Yellow;
            FigList[4] = new Hexagon(CurrPen, 200, 100, 300, 400);
            CurrPen.Brush = Brushes.White;
            FigList[5] = new RoundRect(CurrPen, 420, 220, 680, 280);
            CurrPen.Brush = Brushes.Red;
            FigList[6] = new StarFour(CurrPen, 200, 300, 300, 400);
            FigureList[0] = new Line(CurrPen, 0, 0, 0, 0);
            FigureList[1] = new Rect(CurrPen, 0, 0, 0, 0);
            FigureList[2] = new Ellipce(CurrPen, 0, 0, 0, 0);
            FigureList[3] = new IsoTriangle(CurrPen, 0, 0, 0, 0);
            FigureList[4] = new RoundRect(CurrPen, 0, 0, 0, 0);
            FigureList[5] = new Hexagon(CurrPen, 0, 0, 0, 0);
            FigureList[6] = new StarFour(CurrPen, 0, 0, 0, 0);

            CurrPen.Brush = Brushes.Black;
        }
        private Pen CurrPen;
        private FiguresList FigList;
        private DynamicFigList FigureList;
        private int CurrentFigure = 0;
        private BitMaps Layers;
        private bool pressed;
        private Graphics grBack, grFront, grTemp, grRez, grLast;
        
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            FigList.DrawAll(gr);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                CurrPen.Color = colorDialog1.Color;
            }
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
                FigureList[CurrentFigure].pen = CurrPen;
                FigureList[CurrentFigure].X2 = e.X;
                FigureList[CurrentFigure].Y2 = e.Y;
                FigureList[CurrentFigure].Draw(grTemp);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[2], 0, 0);
                grRez.DrawImage(Layers[3], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
            btnBack.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grLast.Clear(colorDialog2.Color);
            grLast.DrawImage(Layers[1], 0, 0);
            grRez.Clear(colorDialog2.Color);
            grTemp.Clear(colorDialog2.Color);
            grFront.Clear(colorDialog2.Color);
            pictureBox1.Refresh();
            btnBack.Enabled = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            FigureList[CurrentFigure].Draw(grTemp);
            grLast.Clear(Color.Transparent);
            grLast.DrawImage(Layers[2], 0, 0);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            grFront.Clear(Color.Transparent);
            pictureBox1.Refresh();
            pressed = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            btnBack.Enabled = true;
            FigureList[CurrentFigure].X1 = e.X;
            FigureList[CurrentFigure].Y1 = e.Y;
            grFront.DrawImage(Layers[1], 0, 0);
            grTemp.Clear(Color.Transparent);
            pressed = true;
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                btnBackColor.BackColor = colorDialog2.Color;
                grBack.Clear(colorDialog2.Color);
                pictureBox1.Refresh();
            }
        }
    }
}
