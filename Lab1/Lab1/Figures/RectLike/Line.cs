using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public class Line : RectLike
    {
        public Line(Pen pens, int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(PictureBox pbox)
        {
            Graphics g = pbox.CreateGraphics();
            g.DrawLine(pen, new Point(X1, Y1), new Point(X2, Y2));
        }
    }
}
