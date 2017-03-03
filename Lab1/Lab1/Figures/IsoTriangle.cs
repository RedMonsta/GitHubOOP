using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class IsoTriangle : Figure
    {
        public IsoTriangle(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawLine(pen, X1, Y2, X2, Y2);
            gr.DrawLine(pen, X1, Y2, (X1 + X2) / 2, Y1);
            gr.DrawLine(pen, (X1 + X2) / 2, Y1, X2, Y2);
        }
    }
}
