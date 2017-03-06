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

        private int GetsCursorPos(Figure fig, MouseEventArgs e)
        {
            if (e.X < fig.X1 + 5 && e.X > fig.X1 - 5 && e.Y < fig.Y1 + 5 && e.Y > fig.Y1 - 5) { return 1; }//this.Cursor = Cursors.SizeNWSE;
            if (e.X < (fig.X1 + fig.X2) / 2 + 5 && e.X > (fig.X1 + fig.X2) / 2 - 5 && e.Y < fig.Y1 + 5 && e.Y > fig.Y1 - 5) { return 2; }
            if (e.X < fig.X2 + 5 && e.X > fig.X2 - 5 && e.Y < fig.Y1 + 5 && e.Y > fig.Y1 - 5) { return 3; }
            if (e.X < fig.X2 + 5 && e.X > fig.X2 - 5 && e.Y < (fig.Y1 + fig.Y2) / 2 + 5 && e.Y > (fig.Y1 + fig.Y2) / 2 - 5) { return 4; }
            if (e.X < fig.X2 + 5 && e.X > fig.X2 - 5 && e.Y < fig.Y2 + 5 && e.Y > fig.Y2 - 5) { return 5; }
            if (e.X < (fig.X1 + fig.X2) / 2 + 5 && e.X > (fig.X1 + fig.X2) / 2 - 5 && e.Y < fig.Y2 + 5 && e.Y > fig.Y2 - 5) { return 6; }
            if (e.X < fig.X1 + 5 && e.X > fig.X1 - 5 && e.Y < fig.Y2 + 5 && e.Y > fig.Y2 - 5) { return 7; }                   
            if (e.X < fig.X1 + 5 && e.X > fig.X1 - 5 && e.Y < (fig.Y1 + fig.Y2) / 2 + 5 && e.Y > (fig.Y1 + fig.Y2) / 2 - 5) { return 8; }            
            if (e.X < (fig.X1 + fig.X2) / 2 + 5 && e.X > (fig.X1 + fig.X2) / 2 - 5 && e.Y < (fig.Y1 + fig.Y2) / 2 + 5 && e.Y > (fig.Y1 + fig.Y2) / 2 - 5) { return 0; }
            return -1;
        }


        public MainForm()
        {
            InitializeComponent();
            colorDialog2.Color = pictureBox1.BackColor;
            DoubleBuffered = true;
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
            btnConfirm.Enabled = false;
            CursorPos = -1;
        }
        private Pen CurrPen;
        //private DynamicFigList FigureList;
        private FigureList FigList;
        private BitMaps Layers;
        private bool isPressed, isChanged, isMoved, isPointer;
        private Graphics grBack, grFront, grTemp, grRez, grLast, grEdit, grMajor;
        private Figure figure;
        private int BackSteps = 0, CurrFig = -1;
        private ActivePoints APoints;

        private int CursorPos { get; set; }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                CurrPen.Color = colorDialog1.Color;
                if (CurrFig != -1)
                {
                    btnConfirm.Enabled = true;
                    //grboxFigures.Enabled = false;
                    grEdit.Clear(Color.Transparent);
                    grRez.Clear(Color.Transparent);
                    grMajor.Clear(Color.Transparent);
                    grTemp.Clear(Color.Transparent);
                    FigList.DrawAllExcept(grMajor, CurrFig);
                    //FigList.Item(CurrFig).pen.Brush = Brushes.Red;
                    FigList.Item(CurrFig).ChangeColor(CurrPen);
                    FigList.Item(CurrFig).Draw(grTemp);
                    //FigList.Item(CurrFig).Check();
                    FigList.Item(CurrFig).SelectFigure(grEdit);

                    label1.Text = "Changed color";
                    grMajor.DrawImage(Layers[3], 0, 0);
                    grRez.DrawImage(Layers[6], 0, 0);

                    //grRez.DrawImage(Layers[5], 0, 0);
                    //grRez.DrawImage(Layers[3], 0, 0);
                    grMajor.DrawImage(Layers[1], 0, 0);
                    pictureBox1.Refresh();
                } 
            }
        }

        private void rbLine_Click(object sender, EventArgs e) { figure = new Line(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbRect_CheckedChanged(object sender, EventArgs e) { figure = new Rect(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbEllipce_CheckedChanged(object sender, EventArgs e) { figure = new Ellipce(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbArc_CheckedChanged(object sender, EventArgs e) { figure = new IsoTriangle(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbRoundRect_CheckedChanged(object sender, EventArgs e) { figure = new RoundRect(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbHexagon_CheckedChanged(object sender, EventArgs e) { figure = new Hexagon(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbSymbolA_CheckedChanged(object sender, EventArgs e) { figure = new StarFour(CurrPen, 0, 0, 0, 0); isChanged = true; isPointer = false; }

        private void rbPointer_CheckedChanged(object sender, EventArgs e) { isPointer = true; label1.Text = "choose pointer"; }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {     
            if (isPressed && !isPointer)
            {
                isMoved = true;
                grTemp.Clear(Color.Transparent);    
                FigList.Last.GetPen(CurrPen);
                FigList.Last.X2 = e.X;
                FigList.Last.Y2 = e.Y;
                FigList.Last.Draw(grTemp);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[6], 0, 0);
                grRez.DrawImage(Layers[3], 0, 0);
                pictureBox1.Refresh();
            }
            if (isPointer & !isPressed)
            {
                //if (CurrFig != -1) ChangeCursor(FigList.Item(CurrFig), e);
                if (CurrFig != -1)
                {
                    APoints = new ActivePoints(FigList.Item(CurrFig));
                    Cursor = APoints.ChangeCursor(e);
                }
            }

            if (isPointer && isPressed)
            {
                isMoved = true;
                btnConfirm.Enabled = true;
                grboxFigures.Enabled = false;
                grEdit.Clear(Color.Transparent);
                grRez.Clear(Color.Transparent);
                grMajor.Clear(Color.Transparent);
                grTemp.Clear(Color.Transparent);
                FigList.DrawAllExcept(grMajor, CurrFig);
                //FigList.Item(CurrFig).pen.Brush = Brushes.Red;
                FigList.Item(CurrFig).Edit(CursorPos, e);
                FigList.Item(CurrFig).Draw(grTemp);
                //FigList.Item(CurrFig).Check();
                FigList.Item(CurrFig).SelectFigure(grEdit);

                //var fig = (Figure)Activator.CreateInstance(FigList.Item(CurrFig).GetType(), new Object[] { new Pen(Brushes.Red, 3),
                //               FigList.Item(CurrFig).X1, FigList.Item(CurrFig).Y1, FigList.Item(CurrFig).X2, FigList.Item(CurrFig).Y2 });
                //fig.Draw(grTemp);

                //label1.Text = CurrFig.ToString() + " " + lboxFigures.Items[CurrFig].ToString();
                label1.Text = "Try to change";
                grMajor.DrawImage(Layers[3], 0, 0);
                grRez.DrawImage(Layers[6], 0, 0);

                //grRez.DrawImage(Layers[5], 0, 0);
                //grRez.DrawImage(Layers[3], 0, 0);
                grMajor.DrawImage(Layers[1], 0, 0);
                pictureBox1.Refresh();
            }

            /*if (isPointer)
            {
                if (CurrFig != -1)
                {
                    grEdit.Clear(Color.Transparent);
                    grRez.Clear(Color.Transparent);
                    grRez.DrawImage(Layers[6], 0, 0);
                    FigList.AllOff();
                    FigList.Item(CurrFig).SelectFigure(grEdit);
                    //label1.Text = index.ToString();
                    grRez.DrawImage(Layers[5], 0, 0);
                    pictureBox1.Refresh();
                }
            }*/
            
        }

        private void lboxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FigList.Item(lboxFigures.SelectedIndex).isSelectable)
            {
                grEdit.Clear(Color.Transparent);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[6], 0, 0);
                FigList.Item(lboxFigures.SelectedIndex).SelectFigure(grEdit);
                CurrFig = lboxFigures.SelectedIndex;
                //label1.Text = lboxFigures.SelectedIndex.ToString();
                grRez.DrawImage(Layers[5], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*grTemp.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            FigList.DrawAll(grTemp);
            FigList.PrintList(lboxFigures);
            
            grRez.DrawImage(Layers[6], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            pictureBox1.Refresh();*/

            if (isPointer)
            {
                if (CurrFig != -1)
                {
                    btnConfirm.Enabled = true;
                    grboxFigures.Enabled = false;
                    grEdit.Clear(Color.Transparent);
                    grRez.Clear(Color.Transparent);
                    grMajor.Clear(Color.Transparent);
                    grTemp.Clear(Color.Transparent);
                    FigList.DrawAllExcept(grMajor, CurrFig);
                    FigList.Item(CurrFig).pen.Brush = Brushes.Red;
                    FigList.Item(CurrFig).Draw(grTemp);
                    FigList.Item(CurrFig).SelectFigure(grEdit);

                    //var fig = (Figure)Activator.CreateInstance(FigList.Item(CurrFig).GetType(), new Object[] { new Pen(Brushes.Red, 3),
                      //               FigList.Item(CurrFig).X1, FigList.Item(CurrFig).Y1, FigList.Item(CurrFig).X2, FigList.Item(CurrFig).Y2 });
                    //fig.Draw(grTemp);
                    
                    label1.Text = CurrFig.ToString() + " " + lboxFigures.Items[CurrFig].ToString();
                    grMajor.DrawImage(Layers[3], 0, 0);
                    grRez.DrawImage(Layers[6], 0, 0);
                    
                    //grRez.DrawImage(Layers[5], 0, 0);
                    //grRez.DrawImage(Layers[3], 0, 0);
                    grMajor.DrawImage(Layers[1], 0, 0);
                    pictureBox1.Refresh();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[6], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            grMajor.Clear(Color.Transparent);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
            CurrFig = -1;
            btnConfirm.Enabled = false;
            grboxFigures.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grRez.Clear(Color.Transparent);
            //grRez.DrawImage(Layers[4], 0, 0);
            FigList.Remove(FigList.Last);
            FigList.PrintList(lboxFigures);
            FigList.DrawAll(grRez);
            grMajor.Clear(Color.Transparent);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
            BackSteps++;
            if (BackSteps == 3) btnBack.Enabled = false;
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
            if ( isMoved && !isPointer )
            {
                FigList.Last.Draw(grTemp);
                FigList.Last.Check();
                FigList.AddOneMore(lboxFigures);
                //grLast.Clear(Color.Transparent);
                //grLast.DrawImage(Layers[2], 0, 0);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[6], 0, 0);
                grRez.DrawImage(Layers[3], 0, 0);
                grFront.Clear(Color.Transparent);
                grMajor.DrawImage(Layers[1], 0, 0);
                BackSteps = 0;
                CurrFig = -1;
            } 
            if ( !isMoved && !isPointer ) FigList.Remove(FigList.Last);
            if (isMoved && isPointer)
            {
                grEdit.Clear(Color.Transparent);
                grRez.Clear(Color.Transparent);
                grRez.DrawImage(Layers[6], 0, 0);
                FigList.Item(CurrFig).SelectFigure(grEdit);
                FigList.Item(CurrFig).Check();
                //CurrFig = lboxFigures.SelectedIndex;
                //label1.Text = lboxFigures.SelectedIndex.ToString();
                grRez.DrawImage(Layers[5], 0, 0);
                pictureBox1.Refresh();
            }
            pictureBox1.Refresh();
            isPressed = false;
            CursorPos = -1;
            //FigList.Remove(FigList.Last); if (!isMoved) FigList.Remove(FigList.Last);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPointer)
            {
                if (CurrFig == -1) CurrFig = FigList.MouseSelect(e);
                if (CurrFig != -1)
                {
                    if (FigList.Item(CurrFig).isSelectable)
                    {
                        lboxFigures.SelectedIndex = CurrFig;
                        grEdit.Clear(Color.Transparent);
                        grRez.Clear(Color.Transparent);
                        grRez.DrawImage(Layers[6], 0, 0);
                        FigList.AllOff();
                        FigList.Item(CurrFig).SelectFigure(grEdit);
                        //label1.Text = index.ToString();
                        grRez.DrawImage(Layers[5], 0, 0);
                        pictureBox1.Refresh();
                        isPressed = true;
                        APoints = new ActivePoints(FigList.Item(CurrFig));
                        CursorPos = APoints.GetCursorAPoint(e);
                        isMoved = false;
                    }
                }
            }
            else
            {
                btnBack.Enabled = true;
                if (!isChanged) figure = (Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrPen, 0, 0, 0, 0 });
                //FigureList[FigureList.Size] = figure;
                FigList.Add(figure);
                label1.Text = "Added a figure";
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
