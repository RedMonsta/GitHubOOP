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
            this.btnLine = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnEllipce = new System.Windows.Forms.Button();
            this.btnArc = new System.Windows.Forms.Button();
            this.btnRoundRect = new System.Windows.Forms.Button();
            this.btnHexagon = new System.Windows.Forms.Button();
            this.btnLetA = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pictureBox1.Location = new System.Drawing.Point(165, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(909, 607);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLine
            // 
            this.btnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLine.Location = new System.Drawing.Point(38, 151);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(81, 23);
            this.btnLine.TabIndex = 3;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRect
            // 
            this.btnRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRect.Location = new System.Drawing.Point(38, 180);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(81, 24);
            this.btnRect.TabIndex = 4;
            this.btnRect.Text = "Rect";
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnEllipce
            // 
            this.btnEllipce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEllipce.Location = new System.Drawing.Point(38, 210);
            this.btnEllipce.Name = "btnEllipce";
            this.btnEllipce.Size = new System.Drawing.Size(81, 23);
            this.btnEllipce.TabIndex = 5;
            this.btnEllipce.Text = "Ellipce";
            this.btnEllipce.UseVisualStyleBackColor = true;
            this.btnEllipce.Click += new System.EventHandler(this.btnEllipce_Click);
            // 
            // btnArc
            // 
            this.btnArc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArc.Location = new System.Drawing.Point(38, 239);
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(81, 23);
            this.btnArc.TabIndex = 6;
            this.btnArc.Text = "Arc";
            this.btnArc.UseVisualStyleBackColor = true;
            this.btnArc.Click += new System.EventHandler(this.btnArc_Click);
            // 
            // btnRoundRect
            // 
            this.btnRoundRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRoundRect.Location = new System.Drawing.Point(39, 268);
            this.btnRoundRect.Name = "btnRoundRect";
            this.btnRoundRect.Size = new System.Drawing.Size(80, 24);
            this.btnRoundRect.TabIndex = 7;
            this.btnRoundRect.Text = "RoundRect";
            this.btnRoundRect.UseVisualStyleBackColor = true;
            this.btnRoundRect.Click += new System.EventHandler(this.btnRoundRect_Click);
            // 
            // btnHexagon
            // 
            this.btnHexagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHexagon.Location = new System.Drawing.Point(38, 298);
            this.btnHexagon.Name = "btnHexagon";
            this.btnHexagon.Size = new System.Drawing.Size(81, 25);
            this.btnHexagon.TabIndex = 8;
            this.btnHexagon.Text = "Hexagon";
            this.btnHexagon.UseVisualStyleBackColor = true;
            this.btnHexagon.Click += new System.EventHandler(this.btnHexagon_Click);
            // 
            // btnLetA
            // 
            this.btnLetA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLetA.Location = new System.Drawing.Point(38, 329);
            this.btnLetA.Name = "btnLetA";
            this.btnLetA.Size = new System.Drawing.Size(81, 26);
            this.btnLetA.TabIndex = 9;
            this.btnLetA.Text = "Symbol \"A\"";
            this.btnLetA.UseVisualStyleBackColor = true;
            this.btnLetA.Click += new System.EventHandler(this.btnLetA_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnColor.Location = new System.Drawing.Point(12, 478);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(135, 65);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "Choose Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.button8_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1074, 607);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnLetA);
            this.Controls.Add(this.btnHexagon);
            this.Controls.Add(this.btnRoundRect);
            this.Controls.Add(this.btnArc);
            this.Controls.Add(this.btnEllipce);
            this.Controls.Add(this.btnRect);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDraw);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnEllipce;
        private System.Windows.Forms.Button btnArc;
        private System.Windows.Forms.Button btnRoundRect;
        private System.Windows.Forms.Button btnHexagon;
        private System.Windows.Forms.Button btnLetA;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

