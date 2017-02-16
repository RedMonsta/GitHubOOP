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
            var FigList = new FiguresList<Figure>();
            FigList[0] = new Line(0, 0, 200, 10);
            FigList[1] = new Rect(400, 200, 700, 300);
            FigList[2] = new Ellipce(20, 20, 130, 170);
            FigList[3] = new Arc(100, 100, 200, 200, 30, 150);

            for (int i = 0; i < FigList.Size; i++)
            FigList[i].Draw(pictureBox1);


            //var line = new Line(0, 0, 200, 10);
            //line.Draw(pictureBox1);

            //var rectangle = new Rect(400, 200, 700, 300);
            //rectangle.Draw(pictureBox1);

            //var ellipce = new Ellipce(20, 20, 130, 170);
            //ellipce.Draw(pictureBox1);

            //var arc = new Arc(100, 100, 200, 200, 30, 150);
            //arc.Draw(pictureBox1);

            var rorec = new RoundRect(420, 220, 680, 280, 25);
            rorec.Draw(pictureBox1);

            var hex = new Hexagon(500, 100, 600, 400);
            hex.Draw(pictureBox1);

            var rect = new Rect(0, 400, 60, 480);
            rect.Draw(pictureBox1);
            var leta = new LetterA(0, 400, 20);
            leta.Draw(pictureBox1);
        }
    }
}
