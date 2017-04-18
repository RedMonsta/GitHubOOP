using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Rect
{
    [Serializable]
    public class Rect : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable, MyInterfaces.IFillingable
    {
        public Rect(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            isFilled = false;
            isSelected = false;
            Name = "Rectangle";
        }

        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, X1, Y1, X2, Y1);
            gr.DrawLine(pn, X2, Y1, X2, Y2);
            gr.DrawLine(pn, X2, Y2, X1, Y2);
            gr.DrawLine(pn, X1, Y2, X1, Y1);

        }

        public bool isFilled { get; set; }
        public bool isSelected { get; set; }

        public void Fill(Graphics gr)
        {
            SolidBrush br = new SolidBrush(pen.color);
            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y1);
            Point point3 = new Point(X2, Y2);
            Point point4 = new Point(X1, Y2);
            Point[] points = { point1, point2, point3, point4 };
            GraphicsPath grp = new GraphicsPath();
            grp.AddPolygon(points);
            gr.FillPath(br, grp);
        }

        public override Figure.Figure Copy()
        {
            return new Rect(new Pen(pen.color, pen.Width), X1, Y1, X2, Y2);
        }
    }
}
