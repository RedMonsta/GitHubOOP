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
            Layers[5] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grEdit = Graphics.FromImage(Layers[5]);
            Layers[6] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grMajor = Graphics.FromImage(Layers[6]);
            pictureBox1.BackgroundImage = Layers[0];
            pictureBox1.Image = Layers[1];

            //FigureList = new DynamicFigList();
            FigList = new FigureList();

            CurrPen.Brush = Brushes.Black;
        }
        private Pen CurrPen;
        //private DynamicFigList FigureList;
        private FigureList FigList;
        private BitMaps Layers;
        private bool isPressed, isChanged, isMoved, isPointer;
        private Graphics grBack, grFront, grTemp, grRez, grLast, grEdit, grMajor;
        private Figure figure;

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                CurrPen.Color = colorDialog1.Color;
            }
        }

        private void rbLine_Click(object sender, EventArgs e) { figure = new Line(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbRect_CheckedChanged(object sender, EventArgs e) { figure = new Rect(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbEllipce_CheckedChanged(object sender, EventArgs e) { figure = new Ellipce(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbArc_CheckedChanged(object sender, EventArgs e) { figure = new IsoTriangle(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbRoundRect_CheckedChanged(object sender, EventArgs e) { figure = new RoundRect(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbHexagon_CheckedChanged(object sender, EventArgs e) { figure = new Hexagon(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbSymbolA_CheckedChanged(object sender, EventArgs e) { figure = new StarFour(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbPointer_CheckedChanged(object sender, EventArgs e) { isPointer = true; }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {     
            if (isPressed)
            {
                isMoved = true;
                grTemp.Clear(Color.Transparent);
                //FigureList[FigureList.Size - 1].pen = CurrPen;
                //FigureList[FigureList.Size - 1].X2 = e.X;
                //FigureList[FigureList.Size - 1].Y2 = e.Y;
                //FigureList[FigureList.Size - 1].Draw(grTemp);
                FigList.Last.GetPen(CurrPen);// = CurrPen;
                FigList.Last.X2 = e.X;
                FigList.Last.Y2 = e.Y;
                FigList.Last.Draw(grTemp);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[2], 0, 0);
                grRez.DrawImage(Layers[3], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void lboxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FigList.Item(lboxFigures.SelectedIndex).isSelectable)
            {
                grEdit.Clear(Color.Transparent);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[6], 0, 0);
                FigList.Item(lboxFigures.SelectedIndex).SelectFigure(grEdit);
                label1.Text = lboxFigures.SelectedIndex.ToString();
                //FigList.Item(lboxFigures.SelectedIndex).SelectFigure(grEdit);
                grRez.DrawImage(Layers[5], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grTemp.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            FigList.DrawAll(grTemp);
            FigList.PrintList(lboxFigures);
            
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            pictureBox1.Refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[4], 0, 0);
            FigList.Remove(FigList.Last);
            FigList.PrintList(lboxFigures);
            pictureBox1.Refresh();
            btnBack.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grLast.Clear(colorDialog2.Color);
            grLast.DrawImage(Layers[1], 0, 0);
            grRez.Clear(colorDialog2.Color);
            grMajor.Clear(colorDialog2.Color);
            grTemp.Clear(colorDialog2.Color);
            grFront.Clear(colorDialog2.Color);
            grBack.Clear(colorDialog2.Color);
            pictureBox1.Refresh();
            FigList.Clear();
            FigList.PrintList(lboxFigures);
            btnBack.Enabled = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //FigureList[FigureList.Size - 1].Draw(grTemp);
            if (isMoved)
            {
                FigList.Last.Draw(grTemp);
                FigList.AddOneMore(lboxFigures);
                grLast.Clear(Color.Transparent);
                grLast.DrawImage(Layers[2], 0, 0);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[2], 0, 0);
                grRez.DrawImage(Layers[3], 0, 0);
                grFront.Clear(Color.Transparent);
                grMajor.DrawImage(Layers[1], 0, 0);
            } else
                FigList.Remove(FigList.Last);
            pictureBox1.Refresh();
            isPressed = false;
            //FigList.Remove(FigList.Last); if (!isMoved) FigList.Remove(FigList.Last);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPointer)
            {
                var index = FigList.MouseSelect(e);
                if (index != -1)
                {
                    if (FigList.Item(index).isSelectable)
                    {
                        grEdit.Clear(Color.Transparent);
                        grRez.Clear(Color.Transparent);
                        grRez.DrawImage(Layers[6], 0, 0);
                        FigList.Item(index).SelectFigure(grEdit);
                        label1.Text = index.ToString();
                        grRez.DrawImage(Layers[5], 0, 0);
                        pictureBox1.Refresh();
                    }
                }
            }
            else
            {
                btnBack.Enabled = true;
                if (!isChanged) figure = (Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrPen, 0, 0, 0, 0 });
                //FigureList[FigureList.Size] = figure;
                FigList.Add(figure);
                FigList.Last.X1 = e.X;
                FigList.Last.Y1 = e.Y;
                grFront.DrawImage(Layers[6], 0, 0);
                grTemp.Clear(Color.Transparent);
                isPressed = true;
                isChanged = false;
                isMoved = false;
                //lboxFigures.SelectedIndex = -1;
            }
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
