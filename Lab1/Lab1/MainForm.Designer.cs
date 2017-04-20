namespace Lab1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.grboxFigures = new System.Windows.Forms.GroupBox();
            this.rbPointer = new System.Windows.Forms.RadioButton();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lboxFigures = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfdlgSave = new System.Windows.Forms.SaveFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ofdlgLoad = new System.Windows.Forms.OpenFileDialog();
            this.trackbarWidth = new System.Windows.Forms.TrackBar();
            this.lblWidth = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.grboxFill = new System.Windows.Forms.GroupBox();
            this.rbFillOff = new System.Windows.Forms.RadioButton();
            this.rbFillOn = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnMkUsrFig = new System.Windows.Forms.Button();
            this.btnLdUsrFig = new System.Windows.Forms.Button();
            this.btnTransform = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grboxFigures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarWidth)).BeginInit();
            this.grboxFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(169, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1253, 701);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnColor.Location = new System.Drawing.Point(784, 22);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(145, 61);
            this.btnColor.TabIndex = 10;
            this.btnColor.TabStop = false;
            this.btnColor.Text = "Choose Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.button8_Click);
            // 
            // grboxFigures
            // 
            this.grboxFigures.Controls.Add(this.rbPointer);
            this.grboxFigures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grboxFigures.Location = new System.Drawing.Point(27, 25);
            this.grboxFigures.Name = "grboxFigures";
            this.grboxFigures.Size = new System.Drawing.Size(111, 419);
            this.grboxFigures.TabIndex = 12;
            this.grboxFigures.TabStop = false;
            this.grboxFigures.Text = "Instruments";
            // 
            // rbPointer
            // 
            this.rbPointer.AutoSize = true;
            this.rbPointer.Location = new System.Drawing.Point(9, 21);
            this.rbPointer.Name = "rbPointer";
            this.rbPointer.Size = new System.Drawing.Size(71, 21);
            this.rbPointer.TabIndex = 22;
            this.rbPointer.Text = "Pointer";
            this.rbPointer.UseVisualStyleBackColor = true;
            this.rbPointer.CheckedChanged += new System.EventHandler(this.rbPointer_CheckedChanged);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(935, 25);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(143, 56);
            this.btnBackColor.TabIndex = 16;
            this.btnBackColor.TabStop = false;
            this.btnBackColor.Text = "Back Color";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(705, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 36);
            this.btnClear.TabIndex = 17;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "ClearScr";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(705, 62);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 34);
            this.btnBack.TabIndex = 18;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "StepBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lboxFigures
            // 
            this.lboxFigures.FormattingEnabled = true;
            this.lboxFigures.Location = new System.Drawing.Point(30, 572);
            this.lboxFigures.Name = "lboxFigures";
            this.lboxFigures.Size = new System.Drawing.Size(101, 277);
            this.lboxFigures.TabIndex = 20;
            this.lboxFigures.TabStop = false;
            this.lboxFigures.SelectedIndexChanged += new System.EventHandler(this.lboxFigures_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "label1";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(30, 474);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(104, 63);
            this.btnConfirm.TabIndex = 22;
            this.btnConfirm.TabStop = false;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1096, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 58);
            this.btnSave.TabIndex = 23;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sfdlgSave
            // 
            this.sfdlgSave.DefaultExt = "mpp";
            this.sfdlgSave.Filter = "MonsterPaint Pictures|*.mpp|All Files|*.**";
            this.sfdlgSave.InitialDirectory = "./SavedPictures";
            this.sfdlgSave.OverwritePrompt = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1193, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(85, 56);
            this.btnLoad.TabIndex = 24;
            this.btnLoad.TabStop = false;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ofdlgLoad
            // 
            this.ofdlgLoad.DefaultExt = "mpp";
            this.ofdlgLoad.Filter = "MonsterPaint Pictures|*.mpp|All Files|*.**";
            this.ofdlgLoad.InitialDirectory = "./SavedPictures";
            // 
            // trackbarWidth
            // 
            this.trackbarWidth.Location = new System.Drawing.Point(282, 44);
            this.trackbarWidth.Minimum = 1;
            this.trackbarWidth.Name = "trackbarWidth";
            this.trackbarWidth.Size = new System.Drawing.Size(131, 45);
            this.trackbarWidth.TabIndex = 25;
            this.trackbarWidth.Value = 2;
            this.trackbarWidth.Scroll += new System.EventHandler(this.trackbarWidth_Scroll);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWidth.Location = new System.Drawing.Point(301, 15);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(78, 24);
            this.lblWidth.TabIndex = 26;
            this.lblWidth.Text = "Width: 2";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(582, 44);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 57);
            this.btnDel.TabIndex = 27;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "Delete Figure";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // grboxFill
            // 
            this.grboxFill.Controls.Add(this.rbFillOff);
            this.grboxFill.Controls.Add(this.rbFillOn);
            this.grboxFill.Location = new System.Drawing.Point(461, 29);
            this.grboxFill.Name = "grboxFill";
            this.grboxFill.Size = new System.Drawing.Size(79, 66);
            this.grboxFill.TabIndex = 28;
            this.grboxFill.TabStop = false;
            this.grboxFill.Text = "Filling";
            // 
            // rbFillOff
            // 
            this.rbFillOff.AutoSize = true;
            this.rbFillOff.Checked = true;
            this.rbFillOff.Location = new System.Drawing.Point(6, 42);
            this.rbFillOff.Name = "rbFillOff";
            this.rbFillOff.Size = new System.Drawing.Size(60, 17);
            this.rbFillOff.TabIndex = 1;
            this.rbFillOff.TabStop = true;
            this.rbFillOff.Text = "Fill OFF";
            this.rbFillOff.UseVisualStyleBackColor = true;
            this.rbFillOff.CheckedChanged += new System.EventHandler(this.rbFillOff_CheckedChanged);
            // 
            // rbFillOn
            // 
            this.rbFillOn.AutoSize = true;
            this.rbFillOn.Location = new System.Drawing.Point(6, 19);
            this.rbFillOn.Name = "rbFillOn";
            this.rbFillOn.Size = new System.Drawing.Size(56, 17);
            this.rbFillOn.TabIndex = 0;
            this.rbFillOn.Text = "Fill ON";
            this.rbFillOn.UseVisualStyleBackColor = true;
            this.rbFillOn.CheckedChanged += new System.EventHandler(this.rbFillOn_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(997, 533);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(368, 234);
            this.richTextBox1.TabIndex = 29;
            this.richTextBox1.Text = "";
            // 
            // btnMkUsrFig
            // 
            this.btnMkUsrFig.Location = new System.Drawing.Point(1096, 68);
            this.btnMkUsrFig.Name = "btnMkUsrFig";
            this.btnMkUsrFig.Size = new System.Drawing.Size(182, 56);
            this.btnMkUsrFig.TabIndex = 30;
            this.btnMkUsrFig.Text = "MkUsrFig";
            this.btnMkUsrFig.UseVisualStyleBackColor = true;
            this.btnMkUsrFig.Click += new System.EventHandler(this.btnMkUsrFig_Click);
            // 
            // btnLdUsrFig
            // 
            this.btnLdUsrFig.Location = new System.Drawing.Point(1329, 80);
            this.btnLdUsrFig.Name = "btnLdUsrFig";
            this.btnLdUsrFig.Size = new System.Drawing.Size(77, 43);
            this.btnLdUsrFig.TabIndex = 31;
            this.btnLdUsrFig.Text = "LdUsrFig";
            this.btnLdUsrFig.UseVisualStyleBackColor = true;
            this.btnLdUsrFig.Click += new System.EventHandler(this.btnLdUsrFig_Click);
            // 
            // btnTransform
            // 
            this.btnTransform.Location = new System.Drawing.Point(926, 110);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(123, 39);
            this.btnTransform.TabIndex = 32;
            this.btnTransform.Text = "Transform";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1424, 865);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnLdUsrFig);
            this.Controls.Add(this.btnMkUsrFig);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.grboxFill);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.trackbarWidth);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lboxFigures);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.grboxFigures);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "MonsterPaint";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grboxFigures.ResumeLayout(false);
            this.grboxFigures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarWidth)).EndInit();
            this.grboxFill.ResumeLayout(false);
            this.grboxFill.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListBox lboxFigures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPointer;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfdlgSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog ofdlgLoad;
        private System.Windows.Forms.TrackBar trackbarWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.GroupBox grboxFill;
        private System.Windows.Forms.RadioButton rbFillOff;
        private System.Windows.Forms.RadioButton rbFillOn;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.GroupBox grboxFigures;
        private System.Windows.Forms.Button btnMkUsrFig;
        private System.Windows.Forms.Button btnLdUsrFig;
        private System.Windows.Forms.Button btnTransform;
    }
}

