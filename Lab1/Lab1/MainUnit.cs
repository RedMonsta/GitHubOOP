using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class Figure
    {
        public virtual void Draw() { }
    } 

    public class Line : Figure
    {
        public Line (int x1, int y1, int x2, int y2, PictureBox pbox)
        {
            coordX1 = x1;
            coordY1 = y1;
            coordX2 = x2;
            coordY2 = y2;
            pictBox = pbox;
        }
        public override void Draw()
        {
            Graphics g = pictBox.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Red, 2), new Point(X1, Y1), new Point(X2, Y2));
        }
        public int X1 { get { return coordX1; } set { setX1(value); } }
        private void setX1(int value) { coordX1 = value; }
        public int Y1 { get { return coordY1; } set { setY1(value); } }
        private void setY1(int value) { coordY1 = value; }
        public int X2 { get { return coordX2; } set { setX2(value); } }
        private void setX2(int value) { coordX2 = value; }
        public int Y2 { get { return coordY2; } set { setY2(value); } }
        private void setY2(int value) { coordY2 = value; }
        private int coordX1;
        private int coordY1;
        private int coordX2;
        private int coordY2;
        private PictureBox pictBox;

    }


    static class MainUnit
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
