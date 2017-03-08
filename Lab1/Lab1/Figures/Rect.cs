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
    public class Rect : Figure
    {
        public Rect(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
        }

        public override void Draw(Graphics gr)
        {
            
            /*X1 = Math.Min(X1, X2);
            Y1 = Math.Min(Y1, Y2);
            X2 = Math.Max(X1, X2);
            Y2 = Math.Max(Y1, Y2);*/
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, X1, Y1, X2, Y1);
            gr.DrawLine(pn, X2, Y1, X2, Y2);
            gr.DrawLine(pn, X2, Y2, X1, Y2);
            gr.DrawLine(pn, X1, Y2, X1, Y1);

            /*gr.DrawLine(pen, Math.Min(X1, X2), Math.Min(Y1, Y2), Math.Max(X1, X2), Math.Min(Y1, Y2));
            gr.DrawLine(pen, Math.Max(X1, X2), Math.Min(Y1, Y2), Math.Max(X1, X2), Math.Max(Y1, Y2));
            gr.DrawLine(pen, Math.Max(X1, X2), Math.Max(Y1, Y2), Math.Min(X1, X2), Math.Max(Y1, Y2));
            gr.DrawLine(pen, Math.Min(X1, X2), Math.Max(Y1, Y2), Math.Min(X1, X2), Math.Min(Y1, Y2));*/
        }
    }
}
