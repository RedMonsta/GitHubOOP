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
        public virtual void Draw(PictureBox pbox) { }
    }

    public class RectLike : Figure
    {
        public override void Draw(PictureBox pbox) { }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
    }

    public class SymbolFigure : Figure
    {
        public override void Draw(PictureBox pbox) { }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int FontSize { get; set; }
    }

    public class Line : RectLike
    {
        public Line (int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Red, 2), new Point(X1, Y1), new Point(X2, Y2));
        }
    }

    public class Ellipce : RectLike
    {
        public Ellipce(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public Ellipce(Rect rect)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawEllipse(new Pen(Brushes.Green, 2), new Rectangle(X1, Y1, X2 - X1, Y2 - Y1));
        }
    }

    public class Rect : RectLike
    {
        public Rect(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public override void Draw(PictureBox pbox)
        {  
            Graphics g = pbox.CreateGraphics();
            g.DrawRectangle(new Pen(Brushes.Blue, 2), new Rectangle(X1, Y1, X2 - X1, Y2 - Y1));
        }
    }

    public class Arc : RectLike
    {
        public Arc(Rectangle rect, float startAngle, float sweepAngle)
        {
            X1 = rect.X;
            Y1 = rect.Y;
            X2 = rect.Width;
            Y2 = rect.Height;
            begAngle = startAngle;
            endAngle = sweepAngle - startAngle;
        }
        public Arc(int x1, int y1, int x2, int y2, float startAngle, float sweepAngle)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            begAngle = startAngle;
            endAngle = sweepAngle - startAngle;
        }
        public Arc(Rect rect, float startAngle, float sweepAngle)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
            begAngle = startAngle;
            endAngle = sweepAngle - startAngle;
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawArc(new Pen(Brushes.Yellow, 2), new Rectangle(X1, Y1, X2 - X1, Y2 - Y1), -begAngle, -endAngle);
            //g.DrawRectangle(new Pen(Brushes.Yellow, 2), new Rectangle(X1, Y1, X2, Y2));
        }
        public float begAngle { get; set; }
        public float endAngle { get; set; }
    }

    public class RoundRect : RectLike
    {
        public RoundRect(int x1, int y1, int x2, int y2, int radius)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Radius = radius;
        }
        public RoundRect(Rect rect, int radius)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
            Radius = radius;
        }
        public override void Draw(PictureBox pbox)
        {

            Graphics g = pbox.CreateGraphics();
            var pen = new Pen(Brushes.Yellow, 2);
            g.DrawLine(pen, X1 + Radius, Y1, X2 - Radius, Y1);
            g.DrawLine(pen, X2, Y1 + Radius, X2, Y2 - Radius);
            g.DrawLine(pen, X1 + Radius, Y2, X2 - Radius, Y2);
            g.DrawLine(pen, X1, Y1 + Radius, X1, Y2 - Radius);
            var arc1 = new Arc(X1, Y1, X1 + 2 * Radius, Y1 + 2 * Radius, 89, 181);
            var arc2 = new Arc(X2 - 2 * Radius, Y1, X2, Y1 + 2 * Radius, -1, 91);
            var arc3 = new Arc(X2 - 2 * Radius, Y2 - 2 * Radius, X2, Y2, 269, 361);
            var arc4 = new Arc(X1, Y2 - 2 * Radius, X1 + 2 * Radius, Y2, 179, 271);
            arc1.Draw(pbox);
            arc2.Draw(pbox);
            arc3.Draw(pbox);
            arc4.Draw(pbox);
        }
        public int Radius { get; set; }
    }

    public class Hexagon : RectLike
    {
        public Hexagon(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public Hexagon(Rect rect)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
        }
        public override void Draw(PictureBox pbox)
        {

            Graphics g = pbox.CreateGraphics();
            var pen = new Pen(Brushes.Orange, 2);
            g.DrawLine(pen, (X1 + X2) / 2, Y1, X2, Y1 + (Y2 - Y1) / 3);
            g.DrawLine(pen, X2, Y1 + (Y2 - Y1) / 3, X2, Y1 + (Y2 - Y1) / 3 * 2);
            g.DrawLine(pen, X2, Y1 + (Y2 - Y1) / 3 * 2, (X1 + X2) / 2, Y2);
            g.DrawLine(pen, (X1 + X2) / 2, Y2, X1, Y1 + (Y2 - Y1) / 3 * 2);
            g.DrawLine(pen, X1, Y1 + (Y2 - Y1) / 3 * 2, X1, Y1 + (Y2 - Y1) / 3);
            g.DrawLine(pen, X1, Y1 + (Y2 - Y1) / 3 , (X1 + X2) / 2, Y1);
        }
    }

    public class LetterA : SymbolFigure
    {
        public LetterA(int x1, int y1, int size)
        {
            X1 = x1;
            Y1 = y1;
            FontSize = size;
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            var pen = new Pen(Brushes.Yellow, 2);
            g.DrawLine(pen, X1 + FontSize * 3 / 2, Y1, X1 + FontSize * 3, Y1 + FontSize * 4);
            g.DrawLine(pen, X1 + FontSize * 3 / 2, Y1, X1, Y1 + FontSize * 4);
            g.DrawLine(pen, X1 + 2 + (FontSize * 3 / 2 / 8 * 3), Y1 + (FontSize * 4 / 8 * 5), X1 + 2 + (FontSize * 3 / 2 / 8 * 5) + FontSize * 3 / 2, Y1 + (FontSize * 4 / 8 * 5));
        }
        
    }

    public class FiguresList<Figure>
    {
        public FiguresList()
        {
            Size = 0;
        }
        public Figure this[int index]
        {
            get { return Figures[index]; }
            set { Figures[index] = value; Size++; }
        }
        private Figure[] Figures = new Figure[100];
        public int Size { get; set; }
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
