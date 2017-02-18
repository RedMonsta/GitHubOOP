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
            this.btnDraw = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.grboxFigures = new System.Windows.Forms.GroupBox();
            this.rbStarFour = new System.Windows.Forms.RadioButton();
            this.rbHexagon = new System.Windows.Forms.RadioButton();
            this.rbRoundRect = new System.Windows.Forms.RadioButton();
            this.rbIsoTriangle = new System.Windows.Forms.RadioButton();
            this.rbEllipce = new System.Windows.Forms.RadioButton();
            this.rbRect = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grboxFigures.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDraw.Location = new System.Drawing.Point(24, 28);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(110, 85);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "Draw All";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(162, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(912, 584);
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
            this.btnColor.Location = new System.Drawing.Point(11, 440);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(145, 61);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "Choose Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.button8_Click);
            // 
            // grboxFigures
            // 
            this.grboxFigures.Controls.Add(this.rbStarFour);
            this.grboxFigures.Controls.Add(this.rbHexagon);
            this.grboxFigures.Controls.Add(this.rbRoundRect);
            this.grboxFigures.Controls.Add(this.rbIsoTriangle);
            this.grboxFigures.Controls.Add(this.rbEllipce);
            this.grboxFigures.Controls.Add(this.rbRect);
            this.grboxFigures.Controls.Add(this.rbLine);
            this.grboxFigures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grboxFigures.Location = new System.Drawing.Point(24, 136);
            this.grboxFigures.Name = "grboxFigures";
            this.grboxFigures.Size = new System.Drawing.Size(111, 219);
            this.grboxFigures.TabIndex = 12;
            this.grboxFigures.TabStop = false;
            this.grboxFigures.Text = "Figures";
            // 
            // rbStarFour
            // 
            this.rbStarFour.AutoSize = true;
            this.rbStarFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbStarFour.Location = new System.Drawing.Point(9, 179);
            this.rbStarFour.Name = "rbStarFour";
            this.rbStarFour.Size = new System.Drawing.Size(81, 21);
            this.rbStarFour.TabIndex = 6;
            this.rbStarFour.Text = "StarFour";
            this.rbStarFour.UseVisualStyleBackColor = true;
            this.rbStarFour.CheckedChanged += new System.EventHandler(this.rbSymbolA_CheckedChanged);
            // 
            // rbHexagon
            // 
            this.rbHexagon.AutoSize = true;
            this.rbHexagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbHexagon.Location = new System.Drawing.Point(9, 152);
            this.rbHexagon.Name = "rbHexagon";
            this.rbHexagon.Size = new System.Drawing.Size(82, 21);
            this.rbHexagon.TabIndex = 5;
            this.rbHexagon.Text = "Hexagon";
            this.rbHexagon.UseVisualStyleBackColor = true;
            this.rbHexagon.CheckedChanged += new System.EventHandler(this.rbHexagon_CheckedChanged);
            // 
            // rbRoundRect
            // 
            this.rbRoundRect.AutoSize = true;
            this.rbRoundRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbRoundRect.Location = new System.Drawing.Point(9, 125);
            this.rbRoundRect.Name = "rbRoundRect";
            this.rbRoundRect.Size = new System.Drawing.Size(97, 21);
            this.rbRoundRect.TabIndex = 4;
            this.rbRoundRect.Text = "RoundRect";
            this.rbRoundRect.UseVisualStyleBackColor = true;
            this.rbRoundRect.CheckedChanged += new System.EventHandler(this.rbRoundRect_CheckedChanged);
            // 
            // rbIsoTriangle
            // 
            this.rbIsoTriangle.AutoSize = true;
            this.rbIsoTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbIsoTriangle.Location = new System.Drawing.Point(9, 98);
            this.rbIsoTriangle.Name = "rbIsoTriangle";
            this.rbIsoTriangle.Size = new System.Drawing.Size(96, 21);
            this.rbIsoTriangle.TabIndex = 3;
            this.rbIsoTriangle.Text = "IsoTriangle";
            this.rbIsoTriangle.UseVisualStyleBackColor = true;
            this.rbIsoTriangle.CheckedChanged += new System.EventHandler(this.rbArc_CheckedChanged);
            // 
            // rbEllipce
            // 
            this.rbEllipce.AutoSize = true;
            this.rbEllipce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbEllipce.Location = new System.Drawing.Point(9, 71);
            this.rbEllipce.Name = "rbEllipce";
            this.rbEllipce.Size = new System.Drawing.Size(67, 21);
            this.rbEllipce.TabIndex = 2;
            this.rbEllipce.Text = "Ellipce";
            this.rbEllipce.UseVisualStyleBackColor = true;
            this.rbEllipce.CheckedChanged += new System.EventHandler(this.rbEllipce_CheckedChanged);
            // 
            // rbRect
            // 
            this.rbRect.AutoSize = true;
            this.rbRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbRect.Location = new System.Drawing.Point(9, 44);
            this.rbRect.Name = "rbRect";
            this.rbRect.Size = new System.Drawing.Size(90, 21);
            this.rbRect.TabIndex = 1;
            this.rbRect.Text = "Rectangle";
            this.rbRect.UseVisualStyleBackColor = true;
            this.rbRect.CheckedChanged += new System.EventHandler(this.rbRect_CheckedChanged);
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Checked = true;
            this.rbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbLine.Location = new System.Drawing.Point(9, 19);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(53, 21);
            this.rbLine.TabIndex = 0;
            this.rbLine.TabStop = true;
            this.rbLine.Text = "Line";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.Click += new System.EventHandler(this.rbLine_Click);
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(12, 518);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(143, 56);
            this.btnBackColor.TabIndex = 16;
            this.btnBackColor.Text = "Back Color";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(11, 383);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 36);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "ClearScr";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(81, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(73, 34);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "StepBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1074, 587);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.grboxFigures);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDraw);
            this.Name = "MainForm";
            this.Text = "MonsterPaint";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grboxFigures.ResumeLayout(false);
            this.grboxFigures.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.GroupBox grboxFigures;
        private System.Windows.Forms.RadioButton rbStarFour;
        private System.Windows.Forms.RadioButton rbHexagon;
        private System.Windows.Forms.RadioButton rbRoundRect;
        private System.Windows.Forms.RadioButton rbIsoTriangle;
        private System.Windows.Forms.RadioButton rbEllipce;
        private System.Windows.Forms.RadioButton rbRect;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
    }
}

