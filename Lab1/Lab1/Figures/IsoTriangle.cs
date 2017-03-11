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
    public class IsoTriangle : Figure, ISelectable, IEditable
    {
        public IsoTriangle(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
        }

        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, X1, Y2, X2, Y2);
            gr.DrawLine(pn, X1, Y2, (X1 + X2) / 2, Y1);
            gr.DrawLine(pn, (X1 + X2) / 2, Y1, X2, Y2);
        }

        public override void Fill(Graphics gr)
        {

        }
    }
}
