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
            this.btnMkUsrFig = new System.Windows.Forms.Button();
            this.btnTransform = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnButtonsColor = new System.Windows.Forms.Button();
            this.btnWindowColor = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tboxHeight = new System.Windows.Forms.TextBox();
            this.tboxWidth = new System.Windows.Forms.TextBox();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.colorDialog4 = new System.Windows.Forms.ColorDialog();
            this.btnCancelSettings = new System.Windows.Forms.Button();
            this.lbllWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grboxFigures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarWidth)).BeginInit();
            this.grboxFill.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(169, 136);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(1500, 800);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(300, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 200);
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
            this.btnColor.Location = new System.Drawing.Point(651, 21);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(145, 56);
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
            this.grboxFigures.Size = new System.Drawing.Size(111, 444);
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
            this.btnBackColor.Location = new System.Drawing.Point(653, 83);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(143, 47);
            this.btnBackColor.TabIndex = 16;
            this.btnBackColor.TabStop = false;
            this.btnBackColor.Text = "Back Color";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(248, 89);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 34);
            this.btnClear.TabIndex = 17;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "ClearScr";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(169, 89);
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
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(30, 485);
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
            this.btnSave.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSave.Location = new System.Drawing.Point(846, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 71);
            this.btnSave.TabIndex = 23;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
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
            this.btnLoad.Location = new System.Drawing.Point(969, 21);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(103, 69);
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
            this.trackbarWidth.Location = new System.Drawing.Point(484, 68);
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
            this.lblWidth.Location = new System.Drawing.Point(480, 35);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(78, 24);
            this.lblWidth.TabIndex = 26;
            this.lblWidth.Text = "Width: 2";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(169, 31);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(152, 36);
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
            this.grboxFill.Location = new System.Drawing.Point(373, 31);
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
            // btnMkUsrFig
            // 
            this.btnMkUsrFig.Location = new System.Drawing.Point(1089, 21);
            this.btnMkUsrFig.Name = "btnMkUsrFig";
            this.btnMkUsrFig.Size = new System.Drawing.Size(103, 69);
            this.btnMkUsrFig.TabIndex = 30;
            this.btnMkUsrFig.Text = "MkUsrFig";
            this.btnMkUsrFig.UseVisualStyleBackColor = true;
            this.btnMkUsrFig.Click += new System.EventHandler(this.btnMkUsrFig_Click);
            // 
            // btnTransform
            // 
            this.btnTransform.Location = new System.Drawing.Point(1210, 21);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(102, 69);
            this.btnTransform.TabIndex = 32;
            this.btnTransform.Text = "Transform";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(1333, 21);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(103, 69);
            this.btnSettings.TabIndex = 34;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.SystemColors.Menu;
            this.pnlSettings.Controls.Add(this.lblSettings);
            this.pnlSettings.Controls.Add(this.lblHeight);
            this.pnlSettings.Controls.Add(this.lbllWidth);
            this.pnlSettings.Controls.Add(this.btnCancelSettings);
            this.pnlSettings.Controls.Add(this.btnButtonsColor);
            this.pnlSettings.Controls.Add(this.btnWindowColor);
            this.pnlSettings.Controls.Add(this.btnSaveSettings);
            this.pnlSettings.Controls.Add(this.tboxHeight);
            this.pnlSettings.Controls.Add(this.tboxWidth);
            this.pnlSettings.Location = new System.Drawing.Point(419, 207);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(603, 244);
            this.pnlSettings.TabIndex = 35;
            // 
            // btnButtonsColor
            // 
            this.btnButtonsColor.Location = new System.Drawing.Point(461, 51);
            this.btnButtonsColor.Name = "btnButtonsColor";
            this.btnButtonsColor.Size = new System.Drawing.Size(101, 79);
            this.btnButtonsColor.TabIndex = 4;
            this.btnButtonsColor.Text = "button2";
            this.btnButtonsColor.UseVisualStyleBackColor = true;
            this.btnButtonsColor.Click += new System.EventHandler(this.btnButtonsColor_Click);
            // 
            // btnWindowColor
            // 
            this.btnWindowColor.Location = new System.Drawing.Point(291, 51);
            this.btnWindowColor.Name = "btnWindowColor";
            this.btnWindowColor.Size = new System.Drawing.Size(117, 79);
            this.btnWindowColor.TabIndex = 3;
            this.btnWindowColor.Text = "button1";
            this.btnWindowColor.UseVisualStyleBackColor = true;
            this.btnWindowColor.Click += new System.EventHandler(this.btnWindowColor_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(60, 174);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(182, 42);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Apply";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // tboxHeight
            // 
            this.tboxHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxHeight.Location = new System.Drawing.Point(98, 101);
            this.tboxHeight.MaxLength = 3;
            this.tboxHeight.Name = "tboxHeight";
            this.tboxHeight.Size = new System.Drawing.Size(144, 29);
            this.tboxHeight.TabIndex = 1;
            this.tboxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxHeight_KeyPress);
            // 
            // tboxWidth
            // 
            this.tboxWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tboxWidth.Location = new System.Drawing.Point(98, 51);
            this.tboxWidth.MaxLength = 4;
            this.tboxWidth.Name = "tboxWidth";
            this.tboxWidth.Size = new System.Drawing.Size(144, 29);
            this.tboxWidth.TabIndex = 0;
            this.tboxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxWidth_KeyPress);
            // 
            // colorDialog3
            // 
            this.colorDialog3.Color = System.Drawing.SystemColors.ActiveCaption;
            this.colorDialog3.SolidColorOnly = true;
            // 
            // btnCancelSettings
            // 
            this.btnCancelSettings.Location = new System.Drawing.Point(362, 174);
            this.btnCancelSettings.Name = "btnCancelSettings";
            this.btnCancelSettings.Size = new System.Drawing.Size(174, 42);
            this.btnCancelSettings.TabIndex = 5;
            this.btnCancelSettings.Text = "Cancel";
            this.btnCancelSettings.UseVisualStyleBackColor = true;
            this.btnCancelSettings.Click += new System.EventHandler(this.btnCancelSettings_Click);
            // 
            // lbllWidth
            // 
            this.lbllWidth.AutoSize = true;
            this.lbllWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbllWidth.Location = new System.Drawing.Point(21, 51);
            this.lbllWidth.Name = "lbllWidth";
            this.lbllWidth.Size = new System.Drawing.Size(63, 24);
            this.lbllWidth.TabIndex = 6;
            this.lbllWidth.Text = "Width:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeight.Location = new System.Drawing.Point(21, 101);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(70, 24);
            this.lblHeight.TabIndex = 7;
            this.lblHeight.Text = "Height:";
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSettings.Location = new System.Drawing.Point(247, 10);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(100, 29);
            this.lblSettings.TabIndex = 8;
            this.lblSettings.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1684, 961);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnTransform);
            this.Controls.Add(this.btnMkUsrFig);
            this.Controls.Add(this.grboxFill);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.trackbarWidth);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lboxFigures);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.grboxFigures);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonsterPaint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grboxFigures.ResumeLayout(false);
            this.grboxFigures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarWidth)).EndInit();
            this.grboxFill.ResumeLayout(false);
            this.grboxFill.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
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
        public System.Windows.Forms.GroupBox grboxFigures;
        private System.Windows.Forms.Button btnMkUsrFig;
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TextBox tboxHeight;
        private System.Windows.Forms.TextBox tboxWidth;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ColorDialog colorDialog4;
        private System.Windows.Forms.Button btnButtonsColor;
        private System.Windows.Forms.Button btnWindowColor;
        private System.Windows.Forms.Button btnCancelSettings;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lbllWidth;
    }
}

