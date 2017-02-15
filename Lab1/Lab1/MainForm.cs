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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Line line = new Line(10, 10, 100, 100, pictureBox1);
            line.Draw();
            /*Graphics graphics = this.CreateGraphics();
            Rectangle rectangle = new Rectangle(100, 100, 200, 200);
            graphics.DrawEllipse(Pens.Black, rectangle);
            rectangle.Width = 100;
            graphics.DrawRectangle(Pens.Red, rectangle);*/

            
        }
    }
}
