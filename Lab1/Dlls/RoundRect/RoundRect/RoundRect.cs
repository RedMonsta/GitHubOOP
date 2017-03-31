using System;
using System.Drawing;

namespace RoundRect
{
    [Serializable]
    public class RoundRect : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable
    {
        public RoundRect(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            Radius = 20;
            isSelected = false;
            Name = "RoundRect";
        }

        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            if (Math.Abs(X1 - X2) < 15 || Math.Abs(Y1 - Y2) < 15) Radius = 3;
            if ((Math.Abs(X1 - X2) < 25 || Math.Abs(Y1 - Y2) < 25) && Math.Abs(X1 - X2) > 15 && Math.Abs(Y1 - Y2) > 15) Radius = 7;
            if ((Math.Abs(X1 - X2) < 40 || Math.Abs(Y1 - Y2) < 40) && Math.Abs(X1 - X2) > 25 && Math.Abs(Y1 - Y2) > 25) Radius = 10;
            if (Math.Abs(X1 - X2) > 40 && Math.Abs(Y1 - Y2) > 40) Radius = 20;
            if (X1 < X2 & Y1 < Y2)
            {
                gr.DrawArc(pn, X1, Y1, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawArc(pn, X2 - 2 * Radius, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawArc(pn, X2 - 2 * Radius, Y1, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawArc(pn, X1, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawLine(pn, X1 + Radius, Y1, X2 - Radius, Y1);
                gr.DrawLine(pn, X2, Y1 + Radius, X2, Y2 - Radius);
                gr.DrawLine(pn, X1 + Radius, Y2, X2 - Radius, Y2);
                gr.DrawLine(pn, X1, Y1 + Radius, X1, Y2 - Radius);
            }
            if (X1 < X2 & Y1 > Y2)
            {
                gr.DrawArc(pn, X1, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawArc(pn, X2 - 2 * Radius, Y2, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawArc(pn, X2 - 2 * Radius, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawArc(pn, X1, Y2, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawLine(pn, X1 + Radius, Y1, X2 - Radius, Y1);
                gr.DrawLine(pn, X2, Y1 - Radius, X2, Y2 + Radius);
                gr.DrawLine(pn, X1 + Radius, Y2, X2 - Radius, Y2);
                gr.DrawLine(pn, X1, Y1 - Radius, X1, Y2 + Radius);
            }
            if (X1 > X2 & Y1 > Y2)
            {
                gr.DrawArc(pn, X1 - 2 * Radius, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawArc(pn, X2, Y2, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawArc(pn, X2, Y1 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawArc(pn, X1 - 2 * Radius, Y2, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawLine(pn, X1 - Radius, Y1, X2 + Radius, Y1);
                gr.DrawLine(pn, X2, Y1 - Radius, X2, Y2 + Radius);
                gr.DrawLine(pn, X1 - Radius, Y2, X2 + Radius, Y2);
                gr.DrawLine(pn, X1, Y1 - Radius, X1, Y2 + Radius);
            }
            if (X1 > X2 & Y1 < Y2)
            {
                gr.DrawArc(pn, X1 - 2 * Radius, Y1, 2 * Radius, 2 * Radius, 269, 92);
                gr.DrawArc(pn, X2, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, 89, 92);
                gr.DrawArc(pn, X2, Y1, 2 * Radius, 2 * Radius, 179, 92);
                gr.DrawArc(pn, X1 - 2 * Radius, Y2 - 2 * Radius, 2 * Radius, 2 * Radius, -1, 92);
                gr.DrawLine(pn, X1 - Radius, Y1, X2 + Radius, Y1);
                gr.DrawLine(pn, X2, Y1 + Radius, X2, Y2 - Radius);
                gr.DrawLine(pn, X1 - Radius, Y2, X2 + Radius, Y2);
                gr.DrawLine(pn, X1, Y1 + Radius, X1, Y2 - Radius);
            }
        }

        public int Radius { get; set; }
        public bool isSelected { get; set; }

    }
}
