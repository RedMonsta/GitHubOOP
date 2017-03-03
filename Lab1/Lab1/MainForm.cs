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
            figure = new Line(CurrPen, 0, 0, 0, 0);

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

            FigureList = new DynamicFigList();

            CurrPen.Brush = Brushes.Black;
        }
        private Pen CurrPen;
        private DynamicFigList FigureList;
        private BitMaps Layers;
        private bool pressed, isChanged;
        private Graphics grBack, grFront, grTemp, grRez, grLast;
        private Figure figure;

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                CurrPen.Color = colorDialog1.Color;
            }
        }

        private void rbLine_Click(object sender, EventArgs e) { figure = new Line(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void rbRect_CheckedChanged(object sender, EventArgs e) { figure = new Rect(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void rbEllipce_CheckedChanged(object sender, EventArgs e) { figure = new Ellipce(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void rbArc_CheckedChanged(object sender, EventArgs e) { figure = new IsoTriangle(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void rbRoundRect_CheckedChanged(object sender, EventArgs e) { figure = new RoundRect(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void rbHexagon_CheckedChanged(object sender, EventArgs e) { figure = new Hexagon(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void rbSymbolA_CheckedChanged(object sender, EventArgs e) { figure = new StarFour(CurrPen, 0, 0, 0, 0); isChanged = true; }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {     
            if (pressed)
            {
                grTemp.Clear(Color.Transparent);
                FigureList[FigureList.Size - 1].pen = CurrPen;
                FigureList[FigureList.Size - 1].X2 = e.X;
                FigureList[FigureList.Size - 1].Y2 = e.Y;
                FigureList[FigureList.Size - 1].Draw(grTemp);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[2], 0, 0);
                grRez.DrawImage(Layers[3], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grTemp.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            FigureList.DrawAll(grTemp);
            
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            pictureBox1.Refresh();
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
            grBack.Clear(colorDialog2.Color);
            pictureBox1.Refresh();
            btnBack.Enabled = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            FigureList[FigureList.Size - 1].Draw(grTemp);
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
            if (!isChanged) figure = (Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrPen, 0, 0, 0, 0 });
            FigureList[FigureList.Size] = figure;
            FigureList[FigureList.Size - 1].X1 = e.X;
            FigureList[FigureList.Size - 1].Y1 = e.Y;
            grFront.DrawImage(Layers[1], 0, 0);
            grTemp.Clear(Color.Transparent);
            pressed = true;
            isChanged = false;
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                btnBackColor.BackColor = colorDialog2.Color;
                grBack.Clear(colorDialog2.Color);
                //grRez.Clear(colorDialog2.Color);
                pictureBox1.Refresh();
            }
        }
    }
}
