using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class Arc : RectLike
    {
        public Arc(Pen pens, Rectangle rect, float startAngle, float sweepAngle)
        {
            X1 = rect.X;
            Y1 = rect.Y;
            X2 = rect.Width;
            Y2 = rect.Height;
            begAngle = startAngle;
            endAngle = sweepAngle - startAngle;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public Arc(Pen pens, int x1, int y1, int x2, int y2, float startAngle, float sweepAngle)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            begAngle = startAngle;
            endAngle = sweepAngle - startAngle;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public Arc(Pen pens, Rect rect, float startAngle, float sweepAngle)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
            begAngle = startAngle;
            endAngle = sweepAngle - startAngle;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawArc(pen, new Rectangle(X1, Y1, X2 - X1, Y2 - Y1), -begAngle, -endAngle);
        }
        public float begAngle { get; set; }
        public float endAngle { get; set; }
    }
}
