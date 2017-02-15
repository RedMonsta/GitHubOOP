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
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            pictBox = pbox;
        }
        public override void Draw()
        {
            Graphics g = pictBox.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Red, 2), new Point(X1, Y1), new Point(X2, Y2));
        }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
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
