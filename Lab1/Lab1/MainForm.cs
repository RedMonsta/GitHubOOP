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
using System.Windows.Input;
using System.Reflection;
using System.Security.Cryptography;

namespace Lab1
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            CurrPen = new Pen(Brushes.Black, 2);
            colorDialog2.Color = pictureBox1.BackColor;
            DoubleBuffered = true;
            DllList = new List<string>();
            UserFigsList = new List<string>();
            NamesList = new List<string>();
            UserNamesList = new List<string>();
            TypesList = new List<Type>();
            SourceLists = new List<FiguresList.FigureList>();
            CurrentList = new FiguresList.FigureList();
            

            var Connecter = new AssembliesCollector();
            DllList = Connecter.GetRightFiguresAssemblies(Application.StartupPath + "\\Dlls");
            ConnectFiguresAssemblies();

            var UserConnecter = new UserFiguresCollector();
            UserFigsList = UserConnecter.GetRightFiguresAssemblies(Application.StartupPath + "\\UserFigures");
            ConnectUserFigures();
            

            btnConfirm.Enabled = false;
            btnDel.Enabled = false;
            CursorPos = -1;
            isOpenFile = false;
            isFill = false;
            FigList = new FiguresList.FigureList();
            usrlst = new FiguresList.FigureList();
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

            ActiveControl = trackbarWidth;
        }

        private Pen CurrPen;
        private FiguresList.FigureList FigList, usrlst;
        private BitMaps Layers;
        private bool isPressed, isChanged, isMoved, isPointer, isOpenFile, isFill;
        private Graphics grBack, grTemp, grRez, grEdit, grMajor;
        private Figure.Figure figure;
        private int BackSteps = 0, CurrFig = -1;
        private ActivePoints APoints;
        private MyCustomFiguresBinarySerializer userfigsbinser;
        private List<string> DllList;
        private List<string> UserFigsList;
        private List<string> NamesList;
        public List<string> UserNamesList;
        public List<FiguresList.FigureList> SourceLists;
        private FiguresList.FigureList CurrentList;
        private string CurrentName;


        public List<Type> TypesList;
        private Type typ;
        private int StartRBPos = 65;

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
            if (FigList.Last is MyInterfaces.IFillingable) if (((MyInterfaces.IFillingable)FigList.Last).isFilled) ((MyInterfaces.IFillingable)FigList.Last).Fill(grTemp);
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
            if (FigList.Item(CurrFig) is MyInterfaces.IEditable) ((MyInterfaces.IEditable)FigList.Item(CurrFig)).Edit(CursorPos, ee);
            FigList.Item(CurrFig).Draw(grTemp);
            if (FigList.Item(CurrFig) is MyInterfaces.IFillingable) if (((MyInterfaces.IFillingable)FigList.Item(CurrFig)).isFilled) ((MyInterfaces.IFillingable)FigList.Item(CurrFig)).Fill(grTemp);
            if (FigList.Item(CurrFig) is MyInterfaces.ISelectable)  ((MyInterfaces.ISelectable)FigList.Item(CurrFig)).SelectFigure(grEdit);
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
                if (FigList.Item(CurrFig) is MyInterfaces.IEditable) MM_CurrentFigureEdit(e); 
                else MessageBoxError("You can't edit this figure.", "Editing error.");
            }
        }

        private void lboxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxFigures.SelectedIndex != -1)
            {
                if (FigList.Item(lboxFigures.SelectedIndex) is MyInterfaces.ISelectable)
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
                    ((MyInterfaces.ISelectable)FigList.Item(lboxFigures.SelectedIndex)).SelectFigure(grEdit);
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
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Confirmation();    
        }

        private void Confirmation()
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
            for (int i = 0; i < FigList.Size(); i++)
            {
                richTextBox1.AppendText(FigList.Item(i).GetName() + "1\n");
            }

            grRez.Clear(Color.Transparent);
            FigList.Last.Draw(grTemp);
            FigList.Last.Check();
            FigList.AddOneMore(lboxFigures);          
            grRez.DrawImage(Layers[2], 0, 0);
            grRez.DrawImage(Layers[3], 0, 0);
            grMajor.DrawImage(Layers[1], 0, 0);
            BackSteps = 0;
            CurrFig = -1;

            for (int i = 0; i < FigList.Size(); i++)
            {
                richTextBox1.AppendText(FigList.Item(i).GetName() + "2\n");
            }

            //richTextBox1.AppendText(minx.ToString() + " " + miny.ToString() + " " + maxx.ToString() + " " + maxy.ToString() + "\n");
            richTextBox1.AppendText(FigList.Last.X1.ToString() + " " + FigList.Last.Y1.ToString() + " " + FigList.Last.X2.ToString() + " " + FigList.Last.Y2.ToString() + "\n");
            //richTextBox1.AppendText(FigList.Last.GetType().ToString() + "\n");
            //this.ActiveControl = btnConfirm;
        }

        private void trackbarWidth_Scroll(object sender, EventArgs e)
        {
            CurrPen.Width = trackbarWidth.Value;
            lblWidth.Text = "Width: " + trackbarWidth.Value.ToString();
            if (CurrFig != -1) ChangePen(FigList.Item(CurrFig));  
        }

        private void ChangePen(Figure.Figure fig)
        {
            btnConfirm.Enabled = true;
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grMajor.Clear(Color.Transparent);
            grTemp.Clear(Color.Transparent);
            FigList.DrawAllExcept(grMajor, CurrFig);
            fig.ChangePen(CurrPen);
            fig.Draw(grTemp);
            if (fig is MyInterfaces.IFillingable) if (((MyInterfaces.IFillingable)fig).isFilled) ((MyInterfaces.IFillingable)fig).Fill(grTemp);
            if (fig is MyInterfaces.ISelectable) ((MyInterfaces.ISelectable)fig).SelectFigure(grEdit);
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
                if (FigList.Item(CurrFig) is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)FigList.Item(CurrFig)).isFilled = false;
                MM_CurrentFigureEdit(eee);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool rez = base.ProcessCmdKey(ref msg, keyData);
            if (keyData == Keys.Delete && CurrFig != -1) DeleteFigure();
            if (keyData == Keys.Enter && CurrFig != -1) Confirmation();
            if (keyData == Keys.Back && CurrFig == -1) BackStep();
            if (keyData == Keys.P) rbPointer.Checked = true;
            if (keyData == Keys.F && rbFillOff.Checked == true) rbFillOn.Checked = true;
            if (keyData == Keys.G && rbFillOn.Checked == true) rbFillOff.Checked = true;
            if (keyData == Keys.W) ActiveControl = trackbarWidth;
            return rez;
        }

        //private void grboxFigures_Enter(object sender, EventArgs e)
        //{
        //    ActiveControl = trackbarWidth;
        //}

        private void rbFillOn_CheckedChanged(object sender, EventArgs e)
        {
            isFill = true;
            if (CurrFig != -1)
            {
                var eee = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);
                if (FigList.Item(CurrFig) is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)FigList.Item(CurrFig)).isFilled = true;
                MM_CurrentFigureEdit(eee);
            }
        }

        private void MU_CurrentFigureEditEnd(MouseEventArgs ee)
        {
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            if (FigList.Item(CurrFig) is MyInterfaces.ISelectable) ((MyInterfaces.ISelectable)FigList.Item(CurrFig)).SelectFigure(grEdit);
            FigList.Item(CurrFig).Check();
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {          
            if (e.Button == MouseButtons.Left)
            {
                if (isMoved && !isPointer && !isOpenFile) MU_NewFigureDraw(e); 
                if (!isMoved && !isPointer && !isOpenFile) FigList.Remove(FigList.Size() - 1);
                if (isMoved && isPointer) MU_CurrentFigureEditEnd(e);
            }
            pictureBox1.Refresh();
            isPressed = false;
            CursorPos = -1;
            isOpenFile = false;
        }

        private void btnMkUsrFig_Click(object sender, EventArgs e)
        {
            isOpenFile = true;
            //sfdlgSave.InitialDirectory = Application.StartupPath.ToString() + "\\UserFigures";
            //if (sfdlgSave.ShowDialog() != DialogResult.Cancel)
            string name = Microsoft.VisualBasic.Interaction.InputBox("Creating figure...", "Enter name:");
            //richTextBox1.AppendText(name + "\n");
            {
                //if (sfdlgSave.FileName != "")
                if (name != "")
                {
                    if (!IsExistName(name))
                    {
                        FileStream fs = new FileStream(Application.StartupPath.ToString() + "\\UserFigures\\" + name + ".ufg", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        userfigsbinser = new MyCustomFiguresBinarySerializer();
                        var transformer = new UserFiguresTransformer();
                        var tmplist = transformer.TransformToFullList(FigList);
                        userfigsbinser.SaveFiguresList(fs, tmplist);
                        fs.Close();

                        for (int i = 0; i < tmplist.Size(); i++)
                        {
                            usrlst.Add(tmplist.Item(i).Copy());
                        }

                        SourceLists.Add(usrlst);
                        typ = Type.GetType("Lab1.UserFigure");
                        var nextRB = new RadioButton();
                        nextRB.Parent = grboxFigures;
                        nextRB.Left = 8;
                        nextRB.Top = StartRBPos;
                        StartRBPos += 27;
                        nextRB.Width = 100;
                        nextRB.Height = 21;
                        nextRB.Text = name;
                        UserNamesList.Add(name);

                        nextRB.CheckedChanged += (a, b) =>
                        {
                            try
                            {
                                CurrentList = usrlst;
                                CurrentName = name;
                                figure = (Figure.Figure)Activator.CreateInstance(typ, new Object[] { CurrentName, CurrentList, CurrPen, 0, 0, 0, 0 });
                                isChanged = true;
                                isPointer = false;
                            }
                            catch (Exception ee)
                            {
                                MessageBoxException(ee.Message);
                            }
                        };
                        isOpenFile = false;

                    }
                    else MessageBoxError("Such name is already exist.", "Error");
                }
                else MessageBoxError("Field couldn't be empty.", "Error");
            }
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
                        if (FigList.Item(CurrFig) is MyInterfaces.ISelectable) MD_CurrentFigureSelect(e);
                        else MessageBoxError("You can't select this figure.", "Selecting error.");
                    }
                }
                else MD_NewFigureBegin(e); 
            }
        }

        private void btnLdUsrFig_Click(object sender, EventArgs e)
        {

        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            if (lboxFigures.SelectedIndex != -1)
            {
                var transformer = new UserFiguresTransformer();
                var tmplist = transformer.TransformOneFigureToPrimitives(FigList, CurrFig);
                FigList.Clear();
                for (int i = 0; i < tmplist.Size(); i++)
                {
                    FigList.Add(tmplist.Item(i));
                }
                lboxFigures.Items.Clear();
                CurrFig = -1;
                isPressed = false;
                isMoved = false;
                isChanged = false;
                FigList.PrintList(lboxFigures);
                grRez.Clear(Color.Transparent);
                grMajor.Clear(Color.Transparent);
                FigList.DrawAll(grMajor);
                grRez.DrawImage(Layers[2], 0, 0);
                btnBack.Enabled = false;
            }
        }

        private void MessageBoxError(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }       

        private void MessageBoxException(string ex)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(ex, "Error!", buttons);
        }

        private void MessageBoxWrongDll(string message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, "Assembly error.", buttons);
        }

        private void MD_CurrentFigureSelect(MouseEventArgs ee)
        {
            lboxFigures.SelectedIndex = CurrFig;
            grEdit.Clear(Color.Transparent);
            grRez.Clear(Color.Transparent);
            grRez.DrawImage(Layers[2], 0, 0);
            FigList.AllOff();
            if (FigList.Item(CurrFig) is MyInterfaces.ISelectable) ((MyInterfaces.ISelectable)FigList.Item(CurrFig)).SelectFigure(grEdit);
            grRez.DrawImage(Layers[4], 0, 0);
            pictureBox1.Refresh();
            isPressed = true;
            CurrPen.Color = FigList.Item(CurrFig).pen.color;
            CurrPen.Width = FigList.Item(CurrFig).pen.Width;
            APoints = new ActivePoints(FigList.Item(CurrFig));
            trackbarWidth.Value = (int)FigList.Item(CurrFig).pen.Width;
            lblWidth.Text = "Width: " + ((int)FigList.Item(CurrFig).pen.Width).ToString();
            if (FigList.Item(CurrFig) is MyInterfaces.IFillingable)
                if (((MyInterfaces.IFillingable)FigList.Item(CurrFig)).isFilled) rbFillOn.Checked = true;
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
            if (!isChanged)
            {
                if (figure.GetType().ToString() == "Lab1.UserFigure")
                {
                    figure = (Figure.Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrentName, CurrentList, CurrPen, 0, 0, 0, 0 });///////////////////////////////////////////посмотреть что можно сделать
                }
                else
                {
                    figure = (Figure.Figure)Activator.CreateInstance(figure.GetType(), new Object[] { CurrPen, 0, 0, 0, 0 });
                }
            }
            //if (figure is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)figure).isFilled = false;  
            FigList.Add(figure);
            if (FigList.Last is MyInterfaces.IFillingable) ((MyInterfaces.IFillingable)figure).isFilled = isFill;
            //label1.Text = "Added a figure";
            FigList.Last.X1 = ee.X;
            FigList.Last.Y1 = ee.Y;
            grMajor.DrawImage(Layers[2], 0, 0);
            grTemp.Clear(Color.Transparent);
            isPressed = true;
            isChanged = false;

            //richTextBox1.AppendText(minx.ToString() + " " + miny.ToString() + " " + maxx.ToString() + " " + maxy.ToString() + "\n");
            
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
            isOpenFile = true;
            sfdlgSave.InitialDirectory = Application.StartupPath.ToString() + "\\SavedPictures";
            if (sfdlgSave.ShowDialog() != DialogResult.Cancel)
            {
                if (sfdlgSave.FileName != "")
                {
                    FileStream fs = (FileStream)sfdlgSave.OpenFile();
                    //binser = new MyCustomFiguresListBinarySerializer();
                    //binser.SaveFiguresList(fs, FigList);
                    //for (int i = 0; i < FigList.Size(); i++)
                    //{
                    //    richTextBox1.AppendText(FigList.Item(i).GetName() + "\n");
                    //    for (int j = 0; j < ((UserFigure)FigList.Item(i)).SourceFigures.Size(); j++)
                    //    {
                    //        richTextBox1.AppendText("   " + ((UserFigure)FigList.Item(i)).SourceFigures.Item(j).GetName() + "\n");
                    //    }
                    //}
                    userfigsbinser = new MyCustomFiguresBinarySerializer();
                    userfigsbinser.SaveFiguresList(fs, FigList);
                    fs.Close();
              
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

                    //binser = new MyCustomFiguresListBinarySerializer();
                    userfigsbinser = new MyCustomFiguresBinarySerializer();
                    FigList.Clear();
                    lboxFigures.Items.Clear();
                    CurrFig = -1;
                    isPressed = false;
                    isMoved = false;
                    isChanged = false;
                    try
                    {
                        //FigList = binser.LoadFiguresList(fs, TypesList);
                        FigList = userfigsbinser.LoadFiguresList(fs, TypesList, UserNamesList);
                        fs.Close();
                    }
                    catch (System.Runtime.Serialization.SerializationException ee)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(ee.Message, "Loading error.", buttons);
                    }
                    FigList.PrintList(lboxFigures);
                    grRez.Clear(Color.Transparent);
                    grMajor.Clear(Color.Transparent);
                    FigList.DrawAll(grMajor);
                    for (int i = 0; i < FigList.Size(); i++)
                    {
                        richTextBox1.AppendText(FigList.Item(i).X1.ToString() + " " + FigList.Item(i).Y1.ToString() + " " + FigList.Item(i).X2.ToString() + " " + FigList.Item(i).Y2.ToString() + "\n");

                    }
                    grRez.DrawImage(Layers[2], 0, 0);
                    btnBack.Enabled = false;
                }
            }
        }
    
        private void ConnectFiguresAssemblies()
        {
            try
            {
                foreach (var lib in DllList)
                {
                    Assembly asm = Assembly.LoadFile(lib);
                    Type[] typ = asm.GetTypes();
                    figure = (Figure.Figure)Activator.CreateInstance(typ[0], new Object[] { CurrPen, 0, 0, 0, 0 });
                    bool isExist = false;
                    foreach (var i in NamesList)
                    {
                        if (figure.GetName() == i) isExist = true;
                    }
                    if (!isExist)
                    {
                        var nextRB = new RadioButton();
                        nextRB.Parent = grboxFigures;
                        nextRB.Left = 8;
                        nextRB.Top = StartRBPos;
                        nextRB.Width = 100;
                        nextRB.Height = 21;
                        TypesList.Add(typ[0]);
                        //figure = (Figure.Figure)Activator.CreateInstance(typ[0], new Object[] { CurrPen, 0, 0, 0, 0 });
                        if (figure.GetName().Length > 11) nextRB.Text = figure.GetName().Substring(0, 10);
                        else nextRB.Text = figure.GetName();
                        nextRB.CheckedChanged += (a, b) => { figure = (Figure.Figure)Activator.CreateInstance(typ[0], new Object[] { CurrPen, 0, 0, 0, 0 }); isChanged = true; isPointer = false; };
                        StartRBPos += 27;
                        nextRB.Checked = true;
                        NamesList.Add(figure.GetName());
                    }
                    else MessageBoxWrongDll("There is a repeated figure name \"" + figure.GetName() + "\" in assemblies.");
                }
            }
            catch (Exception e)
            {
                MessageBoxException(e.Message);
            }
        }

        private void ConnectUserFigures()
        {
            try
            {
                foreach (var figpath in UserFigsList)
                {
                    var fs = new FileStream(figpath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    userfigsbinser = new MyCustomFiguresBinarySerializer();
                    var tmplist = userfigsbinser.LoadFiguresList(fs, TypesList, UserNamesList);
                    fs.Close();
                    SourceLists.Add(tmplist);
                    int length = (Application.StartupPath.ToString() + "\\UserFigures").Length;

                    //var alist = new FiguresList.FigureList();
                    //alist = tmplist;

                    typ = Type.GetType("Lab1.UserFigure");
                    var nextRB = new RadioButton();
                    nextRB.Parent = grboxFigures;
                    nextRB.Left = 8;
                    nextRB.Top = StartRBPos;
                    StartRBPos += 27;
                    nextRB.Width = 100;
                    nextRB.Height = 21;
                    string tmpstr = figpath.Substring(length + 1);
                    var name = tmpstr.Remove(tmpstr.Length - 4);
                    nextRB.Text = name;
                    UserNamesList.Add(name);
                    
                    nextRB.CheckedChanged += (a, b) => {
                        try
                        {
                            CurrentList = tmplist;
                            CurrentName = name;
                            figure = (Figure.Figure)Activator.CreateInstance(typ, new Object[] { CurrentName, CurrentList, CurrPen, 0, 0, 0, 0 });
                            isChanged = true;
                            isPointer = false;
                        }
                        catch (Exception ee)
                        {
                            MessageBoxException(ee.Message);
                        }
                    };
                }
            }
            catch (Exception e)
            {
                MessageBoxException(e.Message);
            }
        }

        private bool IsExistName(string name)
        {
            bool result = false;
            for (int i = 0; i < UserNamesList.Count; i++)
            {
                if (name == UserNamesList[i]) result = true;
            }
            return result;
        }

    }
}