﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;

namespace Lab1
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            colorDialog2.Color = pictureBox1.BackColor;
            DoubleBuffered = true;
            CurrPen = new Pen(Brushes.Black, 2);
            figure = new Line(CurrPen, 0, 0, 0, 0);
            btnConfirm.Enabled = false;
            CursorPos = -1;
            isOpenFile = false;
            FigList = new FigureList();

            Layers = new BitMaps();
            Layers[0] = new Bitmap(pictureBox1.Width, pictureBox1.Height);      // Background layer
            grBack = Graphics.FromImage(Layers[0]);
            Layers[1] = new Bitmap(pictureBox1.Width, pictureBox1.Height);      //Result front layer
            grRez = Graphics.FromImage(Layers[1]);
            Layers[2] = new Bitmap(pictureBox1.Width, pictureBox1.Height);      //Temp (important!) layer to saving already drawed figures
            grMajor = Graphics.FromImage(Layers[2]);
            Layers[3] = new Bitmap(pictureBox1.Width, pictureBox1.Height);      //Temp layer for drawing current figure
            grTemp = Graphics.FromImage(Layers[3]);
            Layers[4] = new Bitmap(pictureBox1.Width, pictureBox1.Height);      //Temp layet for editing frame
            grEdit = Graphics.FromImage(Layers[4]);
            pictureBox1.BackgroundImage = Layers[0];
            pictureBox1.Image = Layers[1];


            //var fig = new Rect(CurrPen, 100, 100, 300, 300);
            //fig.Draw(grTemp);           
            //Filling(CurrPen, grRez, 0, 0);
            //grRez.DrawImage(Layers[3], 0, 0);
            //pictureBox1.Refresh();

        }
        private Pen CurrPen;
        private FigureList FigList;
        private BitMaps Layers;
        private bool isPressed, isChanged, isMoved, isPointer, isOpenFile;
        private Graphics grBack, grTemp, grRez, grEdit, grMajor;
        private Figure figure;
        private int BackSteps = 0, CurrFig = -1;
        private ActivePoints APoints;
        private BinSerializer binser;

        private void Filling(Pen pens, Graphics gr, int X, int Y)
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Point point1 = new Point(100, 100);
            Point point2 = new Point(200, 50);
            Point point3 = new Point(250, 200);
            Point point4 = new Point(50, 150);
            Point[] points = { point1, point2, point3, point4 };
            GraphicsPath grp = new GraphicsPath();
            grp.AddPolygon(points);
            gr.FillPath(redBrush, grp);
        }

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
                    grRez.DrawImage(Layers[2], 0, 0);

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

        private void rbPointer_CheckedChanged(object sender, EventArgs e) { isPointer = true; label1.Text = "choosen pointer"; }

        private void MM_NewFigureDraw(MouseEventArgs ee)
        {
            isMoved = true;
            grTemp.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            FigList.Last.GetPen(CurrPen);
            FigList.Last.X2 = ee.X;
            FigList.Last.Y2 = ee.Y;
            FigList.Last.Draw(grTemp);            
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            pictureBox1.Refresh();
            btnBack.Enabled = true;
        }

        private void MM_CurrentFigureEdit(MouseEventArgs ee)
        {
            isMoved = true;
            btnConfirm.Enabled = true;
            grboxFigures.Enabled = false;
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grMajor.Clear(Color.Transparent);
            grTemp.Clear(Color.Transparent);
            FigList.DrawAllExcept(grMajor, CurrFig);
            FigList.Item(CurrFig).Edit(CursorPos, ee);
            FigList.Item(CurrFig).Draw(grTemp);
            FigList.Item(CurrFig).SelectFigure(grEdit);
            grMajor.DrawImage(Layers[3], 0, 0);
            grRez.DrawImage(Layers[2], 0, 0);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed && !isPointer) MM_NewFigureDraw(e);
            if (isPointer & !isPressed) 
            {
                if (CurrFig != -1)
                {
                    APoints = new ActivePoints(FigList.Item(CurrFig));
                    Cursor = APoints.ChangeCursor(e, FigList.Item(CurrFig));                  
                }
            }
            if (isPointer && isPressed)
            {
                if (FigList.Item(CurrFig) is IEditable) MM_CurrentFigureEdit(e); 
                else MessageBoxError("You can't edit this figure.", "Editing error.");
            }          
        }

        private void lboxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FigList.Item(lboxFigures.SelectedIndex) is ISelectable)
            {
                grEdit.Clear(Color.Transparent);
                grRez.Clear(Color.Transparent);
                lboxFigures.Enabled = false;
                isPointer = true;
                rbPointer.Checked = true;
                grboxFigures.Enabled = false;
                btnBack.Enabled = false;
                btnClear.Enabled = false;
                grRez.DrawImage(Layers[2], 0, 0);
                FigList.Item(lboxFigures.SelectedIndex).SelectFigure(grEdit);
                CurrFig = lboxFigures.SelectedIndex;
                btnConfirm.Enabled = true;
                grRez.DrawImage(Layers[4], 0, 0);
                pictureBox1.Refresh();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            grMajor.Clear(Color.Transparent);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
            CurrFig = -1;
            btnConfirm.Enabled = false;
            grboxFigures.Enabled = true;
            lboxFigures.Enabled = true;
            btnBack.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grRez.Clear(Color.Transparent);
            grMajor.Clear(Color.Transparent);
            FigList.Remove(FigList.Last);
            FigList.PrintList(lboxFigures);
            FigList.DrawAll(grRez);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
            BackSteps++;
            if (BackSteps == 3) btnBack.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grRez.Clear(colorDialog2.Color);
            grMajor.Clear(colorDialog2.Color);
            grTemp.Clear(colorDialog2.Color);
            grBack.Clear(colorDialog2.Color);
            pictureBox1.Refresh();
            FigList.Clear();
            lboxFigures.Items.Clear();
            CurrFig = -1;
            isPressed = false;
            isMoved = false;
            isChanged = false;
            FigList.PrintList(lboxFigures);
            btnBack.Enabled = false;
            btnClear.Enabled = true;
        }

        private void MU_NewFigureDraw(MouseEventArgs ee)
        {
            grRez.Clear(Color.Transparent);
            FigList.Last.Draw(grTemp);
            FigList.Last.Check();
            FigList.AddOneMore(lboxFigures);          
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            grMajor.DrawImage(Layers[1], 0, 0);
            BackSteps = 0;
            CurrFig = -1;
        }

        private void MU_CurrentFigureEditEnd(MouseEventArgs ee)
        {
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            FigList.Item(CurrFig).SelectFigure(grEdit);
            FigList.Item(CurrFig).Check();
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {           
            if ( isMoved && !isPointer ) MU_NewFigureDraw(e);
            if (!isMoved && !isPointer && !isOpenFile) FigList.Remove(FigList.Size() - 1);
            if (isMoved && isPointer) MU_CurrentFigureEditEnd(e);   
            pictureBox1.Refresh();
            isPressed = false;
            CursorPos = -1;
            isOpenFile = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoved = false;
            if (isPointer)
            {
                if (CurrFig == -1) CurrFig = FigList.MouseSelect(e);
                if (CurrFig != -1)
                {
                    if (FigList.Item(CurrFig) is ISelectable) MD_CurrentFigureSelect(e);
                    else MessageBoxError("You can't select this figure.", "Selecting error.");
                }
            }
            else MD_NewFigureBegin(e);
        }

        private void MessageBoxError(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }

        private void MD_CurrentFigureSelect(MouseEventArgs ee)
        {
            lboxFigures.SelectedIndex = CurrFig;
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            FigList.AllOff();
            FigList.Item(CurrFig).SelectFigure(grEdit);
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
            isPressed = true;
            APoints = new ActivePoints(FigList.Item(CurrFig));
            CursorPos = APoints.GetCursorAPoint(ee);
            //label1.Text = "Cursor position: " + CursorPos.ToString();
            btnConfirm.Enabled = true;
            lboxFigures.Enabled = false;
            btnBack.Enabled = false;
            btnClear.Enabled = false;
        }

        private void MD_NewFigureBegin(MouseEventArgs ee)
        {
            btnBack.Enabled = true;
            if (!isChanged) figure = (Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrPen, 0, 0, 0, 0 });
            FigList.Add(figure);
            //label1.Text = "Added a figure";
            FigList.Last.X1 = ee.X;
            FigList.Last.Y1 = ee.Y;
            grMajor.DrawImage(Layers[2], 0, 0);
            grTemp.Clear(Color.Transparent);
            isPressed = true;
            isChanged = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            sfdlgSave.InitialDirectory = Application.StartupPath.ToString() + "\\SavedPictures";
            if (sfdlgSave.ShowDialog() != DialogResult.Cancel)
            {
                if (sfdlgSave.FileName != "")
                {
                    FileStream fs = (FileStream)sfdlgSave.OpenFile();
                    binser = new BinSerializer();
                    binser.Save(fs, FigList);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            isOpenFile = true;
            ofdlgLoad.InitialDirectory = Application.StartupPath.ToString() + "\\SavedPictures";
            if (ofdlgLoad.ShowDialog() != DialogResult.Cancel)
            {
                if (ofdlgLoad.FileName != "")
                {                
                    FileStream fs = (FileStream)ofdlgLoad.OpenFile();
                    binser = new BinSerializer();
                    FigList.Clear();
                    lboxFigures.Items.Clear();
                    CurrFig = -1;
                    isPressed = false;
                    isMoved = false;
                    isChanged = false;
                    FigList = (FigureList)binser.Load(fs);
                    FigList.PrintList(lboxFigures);
                    grRez.Clear(Color.Transparent);
                    grMajor.Clear(Color.Transparent);
                    FigList.DrawAll(grMajor);
                    grRez.DrawImage(Layers[2], 0, 0);
                    btnBack.Enabled = false;
                }
            }
        }
  
    }
}
