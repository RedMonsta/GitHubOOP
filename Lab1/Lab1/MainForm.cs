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
            CurrPen = new Pen(Brushes.Black, 2);
        }
        protected Pen CurrPen;

        private void button1_Click(object sender, EventArgs e)
        {
            var FigList = new FiguresList();
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
            FigList[6] = new LetterA(pen, 100, 400, 20);

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

        private void btnLine_Click(object sender, EventArgs e)
        {
            var line = new Line(CurrPen, 0, 0, 600, 10);
            line.Draw(pictureBox1);
        }

        private void btnRect_Click(object sender, EventArgs e)
        {
            var rect = new Rect(CurrPen, 400, 200, 700, 300);
            rect.Draw(pictureBox1);
        }

        private void btnEllipce_Click(object sender, EventArgs e)
        {
            var ellipce = new Ellipce(CurrPen, 20, 20, 130, 170);
            ellipce.Draw(pictureBox1);
        }

        private void btnArc_Click(object sender, EventArgs e)
        {
            var arc = new Arc(CurrPen, 100, 100, 200, 200, 30, 150);
            arc.Draw(pictureBox1);
        }

        private void btnRoundRect_Click(object sender, EventArgs e)
        {
            var rrect = new RoundRect(CurrPen, 420, 220, 680, 280, 25);
            rrect.Draw(pictureBox1);
        }

        private void btnHexagon_Click(object sender, EventArgs e)
        {
            var hexagon = new Hexagon(CurrPen, 200, 100, 300, 400);
            hexagon.Draw(pictureBox1);
        }

        private void btnLetA_Click(object sender, EventArgs e)
        {
            var letA = new LetterA(CurrPen, 100, 400, 20);
            letA.Draw(pictureBox1);
        }
    }
}
