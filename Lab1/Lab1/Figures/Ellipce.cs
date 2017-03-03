using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class Ellipce : Figure
    {
        public Ellipce(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawEllipse(pen, new Rectangle(X1, Y1, X2 - X1, Y2 - Y1));
        }
    }
}
