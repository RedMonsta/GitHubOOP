using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class RoundRect : Figure
    {
        public RoundRect(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            Radius = 20;
        }
        public override void Draw(Graphics gr)
        {
            if (Math.Abs(X1 - X2) < 15 || Math.Abs(Y1 - Y2) < 15) Radius = 5;
            if ((Math.Abs(X1 - X2) < 25 || Math.Abs(Y1 - Y2) < 25) && Math.Abs(X1 - X2) > 15 && Math.Abs(Y1 - Y2) > 15) Radius = 7;
            if ((Math.Abs(X1 - X2) < 40 || Math.Abs(Y1 - Y2) < 40) && Math.Abs(X1 - X2) > 25 && Math.Abs(Y1 - Y2) > 25) Radius = 10;
            if (Math.Abs(X1 - X2) > 40 && Math.Abs(Y1 - Y2) > 40) Radius = 20;
            if (X1 < X2 & Y1 < Y2)
            {
                gr.DrawArc(pen, X1, Y1, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawArc(pen, X2 - 2 * Radius, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawArc(pen, X2 - 2 * Radius, Y1, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawArc(pen, X1, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawLine(pen, X1 + Radius, Y1, X2 - Radius, Y1);
                gr.DrawLine(pen, X2, Y1 + Radius, X2, Y2 - Radius);
                gr.DrawLine(pen, X1 + Radius, Y2, X2 - Radius, Y2);
                gr.DrawLine(pen, X1, Y1 + Radius, X1, Y2 - Radius);
            }
            if (X1 < X2 & Y1 > Y2)
            {
                gr.DrawArc(pen, X1, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawArc(pen, X2 - 2 * Radius, Y2, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawArc(pen, X2 - 2 * Radius, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawArc(pen, X1, Y2, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawLine(pen, X1 + Radius, Y1, X2 - Radius, Y1);
                gr.DrawLine(pen, X2, Y1 - Radius, X2, Y2 + Radius);
                gr.DrawLine(pen, X1 + Radius, Y2, X2 - Radius, Y2);
                gr.DrawLine(pen, X1, Y1 - Radius, X1, Y2 + Radius);
            }
            if (X1 > X2 & Y1 > Y2)
            {
                gr.DrawArc(pen, X1 - 2 * Radius, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawArc(pen, X2, Y2, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawArc(pen, X2, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawArc(pen, X1 - 2 * Radius, Y2, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawLine(pen, X1 - Radius, Y1, X2 + Radius, Y1);
                gr.DrawLine(pen, X2, Y1 - Radius, X2, Y2 + Radius);
                gr.DrawLine(pen, X1 - Radius, Y2, X2 + Radius, Y2);
                gr.DrawLine(pen, X1, Y1 - Radius, X1, Y2 + Radius);
            }
            if (X1 > X2 & Y1 < Y2)
            {
                gr.DrawArc(pen, X1 - 2 * Radius, Y1, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawArc(pen, X2, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawArc(pen, X2, Y1, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawArc(pen, X1 - 2 * Radius, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawLine(pen, X1 - Radius, Y1, X2 + Radius, Y1);
                gr.DrawLine(pen, X2, Y1 + Radius, X2, Y2 - Radius);
                gr.DrawLine(pen, X1 - Radius, Y2, X2 + Radius, Y2);
                gr.DrawLine(pen, X1, Y1 + Radius, X1, Y2 - Radius);
            }
        }
        public int Radius { get; set; }
    }
}
