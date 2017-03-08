using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    [Serializable]
    public class Hexagon : Figure
    {
        public Hexagon(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
        }
        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, (X1 + X2) / 2, Y1, X2, Y1 + (Y2 - Y1) / 3);
            gr.DrawLine(pn, X2, Y1 + (Y2 - Y1) / 3, X2, Y1 + (Y2 - Y1) / 3 * 2);
            gr.DrawLine(pn, X2, Y1 + (Y2 - Y1) / 3 * 2, (X1 + X2) / 2, Y2);
            gr.DrawLine(pn, (X1 + X2) / 2, Y2, X1, Y1 + (Y2 - Y1) / 3 * 2);
            gr.DrawLine(pn, X1, Y1 + (Y2 - Y1) / 3 * 2, X1, Y1 + (Y2 - Y1) / 3);
            gr.DrawLine(pn, X1, Y1 + (Y2 - Y1) / 3, (X1 + X2) / 2, Y1);
        }
    }
}
