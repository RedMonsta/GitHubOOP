using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public class Line : Figure
    {
        public Line(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawLine(pen, new Point(X1, Y1), new Point(X2, Y2));
        }
    }
}
