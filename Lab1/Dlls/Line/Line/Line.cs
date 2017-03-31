using System;
using System.Drawing;

namespace Line
{
    [Serializable]
    public class Line : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable
    {
        public Line(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            isSelected = false;
            Name = "Line";
        }

        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, new Point(X1, Y1), new Point(X2, Y2));
        }

        public bool isSelected { get; set; }
    }
}
