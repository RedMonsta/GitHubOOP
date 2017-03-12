using System;
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
            btnDel.Enabled = false;
            CursorPos = -1;
            isOpenFile = false;
            isFill = false;
            FigList = new FigureList();
            lblWidth.Text = "Width: 2";

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
            this.Activate();
            AcceptButton = btnConfirm;

        }
        private Pen CurrPen;
        private FigureList FigList;
        private BitMaps Layers;
        private bool isPressed, isChanged, isMoved, isPointer, isOpenFile, isFill;
        private Graphics grBack, grTemp, grRez, grEdit, grMajor;
        private Figure figure;
        private int BackSteps = 0, CurrFig = -1;
        private ActivePoints APoints;
        private BinSerializer binser;

        private int CursorPos { get; set; }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog1.Color;
                CurrPen.Color = colorDialog1.Color;
                if (CurrFig != -1) ChangePen(FigList.Item(CurrFig));
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
            if (FigList.Last is IFillingable) if (((IFillingable)FigList.Last).isFilled) ((IFillingable)FigList.Last).Fill(grTemp);
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
            if (FigList.Item(CurrFig) is IEditable) ((IEditable)FigList.Item(CurrFig)).Edit(CursorPos, ee);
            FigList.Item(CurrFig).Draw(grTemp);
            if (FigList.Item(CurrFig) is IFillingable) if (((IFillingable)FigList.Item(CurrFig)).isFilled) ((IFillingable)FigList.Item(CurrFig)).Fill(grTemp);
            if (FigList.Item(CurrFig) is ISelectable)  ((ISelectable)FigList.Item(CurrFig)).SelectFigure(grEdit);
            grMajor.DrawImage(Layers[3], 0, 0);
            grRez.DrawImage(Layers[2], 0, 0);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed && !isPointer && e.Button == MouseButtons.Left) MM_NewFigureDraw(e);
            if (isPointer & !isPressed) 
            {
                if (CurrFig != -1)
                {
                    APoints = new ActivePoints(FigList.Item(CurrFig));
                    Cursor = APoints.ChangeCursor(e, FigList.Item(CurrFig));                  
                }
            }
            if (isPointer && isPressed && e.Button == MouseButtons.Left)
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
                btnDel.Enabled = true;
                grRez.DrawImage(Layers[2], 0, 0);
                ((ISelectable)FigList.Item(lboxFigures.SelectedIndex)).SelectFigure(grEdit);
                CurrFig = lboxFigures.SelectedIndex;
                btnConfirm.Enabled = true;
                grRez.DrawImage(Layers[4], 0, 0);
                pictureBox1.Refresh();
            }
            else
            {
                MessageBoxError("You can't select this figure.", "Selecting error.");
                //lboxFigures.ClearSelected();
                lboxFigures.Items.Clear();
                FigList.PrintList(lboxFigures);
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
            lboxFigures.Items.Clear();
            FigList.PrintList(lboxFigures);
            //lboxFigures.SelectedIndex = -1;
            btnBack.Enabled = true;
            btnDel.Enabled = false;
            btnClear.Enabled = true;
        }

        private void BackStep()
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackStep();
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

            this.ActiveControl = btnConfirm;
        }

        private void trackbarWidth_Scroll(object sender, EventArgs e)
        {
            CurrPen.Width = trackbarWidth.Value;
            lblWidth.Text = "Width: " + trackbarWidth.Value.ToString();
            if (CurrFig != -1) ChangePen(FigList.Item(CurrFig));  
        }

        private void ChangePen(Figure fig)
        {
            btnConfirm.Enabled = true;
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grMajor.Clear(Color.Transparent);
            grTemp.Clear(Color.Transparent);
            FigList.DrawAllExcept(grMajor, CurrFig);
            fig.ChangePen(CurrPen);
            fig.Draw(grTemp);
            if (fig is IFillingable) if (((IFillingable)fig).isFilled) ((IFillingable)fig).Fill(grTemp);
            if (fig is ISelectable) ((ISelectable)fig).SelectFigure(grEdit);
            grMajor.DrawImage(Layers[3], 0, 0);
            grRez.DrawImage(Layers[2], 0, 0);
            grMajor.DrawImage(Layers[1], 0, 0);
            pictureBox1.Refresh();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteFigure();    
        }

        private void DeleteFigure()
        {
            if (CurrFig != -1)
            {
                grRez.Clear(Color.Transparent);
                grMajor.Clear(Color.Transparent);
                grTemp.Clear(Color.Transparent);
                grEdit.Clear(Color.Transparent);
                FigList.Remove(CurrFig);
                lboxFigures.Items.Clear();
                FigList.PrintList(lboxFigures);
                //FigList.DrawAllExcept(grMajor, CurrFig);
                CurrFig = -1;
                FigList.DrawAll(grMajor);
                grRez.DrawImage(Layers[2], 0, 0);
                //grMajor.DrawImage(Layers[1], 0, 0);
                pictureBox1.Refresh();
                lboxFigures.Enabled = true;
                btnDel.Enabled = false;
                grboxFigures.Enabled = true;
                btnConfirm.Enabled = false;
                btnClear.Enabled = true;
                btnBack.Enabled = false;
            }
        }

        private void rbFillOff_CheckedChanged(object sender, EventArgs e)
        {
            isFill = false;
            if (CurrFig != -1)
            {
                var eee = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                if (FigList.Item(CurrFig) is IFillingable) ((IFillingable)FigList.Item(CurrFig)).isFilled = false;
                MM_CurrentFigureEdit(eee);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control && FigList.Size() > 0) { BackStep(); }
           // if (e.KeyCode == Keys.Z) label1.Text = "Key Z";
        }

        private void btnColor_KeyDown(object sender, KeyEventArgs e)
        {
         //   if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control && FigList.Size() > 0) { BackStep(); }
        }

        private void btnConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control && FigList.Size() > 0) { BackStep(); }
        }

        private void rbFillOn_CheckedChanged(object sender, EventArgs e)
        {
            isFill = true;
            if (CurrFig != -1)
            {
                var eee = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                if (FigList.Item(CurrFig) is IFillingable) ((IFillingable)FigList.Item(CurrFig)).isFilled = true;
                MM_CurrentFigureEdit(eee);
            }
        }

        private void MU_CurrentFigureEditEnd(MouseEventArgs ee)
        {
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            if (FigList.Item(CurrFig) is ISelectable) ((ISelectable)FigList.Item(CurrFig)).SelectFigure(grEdit);
            FigList.Item(CurrFig).Check();
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {          
            if (e.Button == MouseButtons.Left)
            {
                if (isMoved && !isPointer) MU_NewFigureDraw(e);
                if (!isMoved && !isPointer && !isOpenFile) FigList.Remove(FigList.Size() - 1);
                if (isMoved && isPointer) MU_CurrentFigureEditEnd(e);
            }
            pictureBox1.Refresh();
            isPressed = false;
            CursorPos = -1;
            isOpenFile = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoved = false;
            if (e.Button == MouseButtons.Left)
            {
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
            if (FigList.Item(CurrFig) is ISelectable) ((ISelectable)FigList.Item(CurrFig)).SelectFigure(grEdit);
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
            isPressed = true;
            CurrPen.Color = FigList.Item(CurrFig).pen.color;
            CurrPen.Width = FigList.Item(CurrFig).pen.Width;
            APoints = new ActivePoints(FigList.Item(CurrFig));
            trackbarWidth.Value = (int)FigList.Item(CurrFig).pen.Width;
            lblWidth.Text = "Width: " + ((int)FigList.Item(CurrFig).pen.Width).ToString();
            if (FigList.Item(CurrFig) is IFillingable)
                if (((IFillingable)FigList.Item(CurrFig)).isFilled) rbFillOn.Checked = true;
                else rbFillOff.Checked = true;
            btnColor.BackColor = FigList.Item(CurrFig).pen.color;
            CursorPos = APoints.GetCursorAPoint(ee);
            btnConfirm.Enabled = true;
            lboxFigures.Enabled = false;
            btnBack.Enabled = false;
            btnClear.Enabled = false;
            btnDel.Enabled = true;
        }

        private void MD_NewFigureBegin(MouseEventArgs ee)
        {
            
            btnBack.Enabled = true;
            if (!isChanged) figure = (Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrPen, 0, 0, 0, 0 });
            //if (figure is IFillingable) ((IFillingable)figure).isFilled = false;  
            FigList.Add(figure);
            if (FigList.Last is IFillingable) ((IFillingable)figure).isFilled = isFill;
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
                pictureBox1.BackgroundImage = Layers[0];
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

//Need to kill bag when lboxFigures.SelectedIndex = -1 after btnConfirm.Click()