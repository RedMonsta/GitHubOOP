using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class RoundRect : RectLike
    {
        public RoundRect(Pen pens, int x1, int y1, int x2, int y2, int radius)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Radius = radius;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public RoundRect(Pen pens, Rect rect, int radius)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
            Radius = radius;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(PictureBox pbox)
        {

            Graphics g = pbox.CreateGraphics();
            g.DrawLine(pen, X1 + Radius, Y1, X2 - Radius, Y1);
            g.DrawLine(pen, X2, Y1 + Radius, X2, Y2 - Radius);
            g.DrawLine(pen, X1 + Radius, Y2, X2 - Radius, Y2);
            g.DrawLine(pen, X1, Y1 + Radius, X1, Y2 - Radius);
            var arc1 = new Arc(pen, X1, Y1, X1 + 2 * Radius, Y1 + 2 * Radius, 89, 181);
            var arc2 = new Arc(pen, X2 - 2 * Radius, Y1, X2, Y1 + 2 * Radius, -1, 91);
            var arc3 = new Arc(pen, X2 - 2 * Radius, Y2 - 2 * Radius, X2, Y2, 269, 361);
            var arc4 = new Arc(pen, X1, Y2 - 2 * Radius, X1 + 2 * Radius, Y2, 179, 271);
            arc1.Draw(pbox);
            arc2.Draw(pbox);
            arc3.Draw(pbox);
            arc4.Draw(pbox);
        }
        public override void Draw(Graphics gr)
        {
            gr.DrawLine(pen, X1 + Radius, Y1, X2 - Radius, Y1);
            gr.DrawLine(pen, X2, Y1 + Radius, X2, Y2 - Radius);
            gr.DrawLine(pen, X1 + Radius, Y2, X2 - Radius, Y2);
            gr.DrawLine(pen, X1, Y1 + Radius, X1, Y2 - Radius);
            var arc1 = new Arc(pen, X1, Y1, X1 + 2 * Radius, Y1 + 2 * Radius, 89, 181);
            var arc2 = new Arc(pen, X2 - 2 * Radius, Y1, X2, Y1 + 2 * Radius, -1, 91);
            var arc3 = new Arc(pen, X2 - 2 * Radius, Y2 - 2 * Radius, X2, Y2, 269, 361);
            var arc4 = new Arc(pen, X1, Y2 - 2 * Radius, X1 + 2 * Radius, Y2, 179, 271);
            arc1.Draw(gr);
            arc2.Draw(gr);
            arc3.Draw(gr);
            arc4.Draw(gr);
        }
        public int Radius { get; set; }
    }
}
