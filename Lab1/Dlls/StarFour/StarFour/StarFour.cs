using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StarFour
{
    [Serializable]
    public class StarFour : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable, MyInterfaces.IFillingable
    {
        public StarFour(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            isFilled = false;
            isSelected = false;
            Name = "StarFour";
        }

        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, X1 + (X2 - X1) / 2, Y1, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 3);
            gr.DrawLine(pn, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 3, X2, Y1 + (Y2 - Y1) / 2);
            gr.DrawLine(pn, X2, Y1 + (Y2 - Y1) / 2, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 5);
            gr.DrawLine(pn, X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 5, X1 + (X2 - X1) / 2, Y2);
            gr.DrawLine(pn, X1 + (X2 - X1) / 2, Y2, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 5);
            gr.DrawLine(pn, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 5, X1, Y1 + (Y2 - Y1) / 2);
            gr.DrawLine(pn, X1, Y1 + (Y2 - Y1) / 2, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 3);
            gr.DrawLine(pn, X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 3, X1 + (X2 - X1) / 2, Y1);

        }

        public void Fill(Graphics gr)
        {
            SolidBrush br = new SolidBrush(pen.color);
            Point point1 = new Point(X1 + (X2 - X1) / 2, Y1);
            Point point2 = new Point(X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 3);
            Point point3 = new Point(X2, Y1 + (Y2 - Y1) / 2);
            Point point4 = new Point(X1 + (X2 - X1) / 8 * 5, Y1 + (Y2 - Y1) / 8 * 5);
            Point point5 = new Point(X1 + (X2 - X1) / 2, Y2);
            Point point6 = new Point(X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 5);
            Point point7 = new Point(X1, Y1 + (Y2 - Y1) / 2);
            Point point8 = new Point(X1 + (X2 - X1) / 8 * 3, Y1 + (Y2 - Y1) / 8 * 3);
            Point[] points = { point1, point2, point3, point4, point5, point6, point7, point8 };
            GraphicsPath grp = new GraphicsPath();
            grp.AddPolygon(points);
            gr.FillPath(br, grp);
        }

        public override Figure.Figure Copy()
        {
            var sfour = new StarFour(new Pen(pen.color, pen.Width), X1, Y1, X2, Y2);
            sfour.isFilled = isFilled;
            return sfour;
        }

        public bool isFilled { get; set; }
        public bool isSelected { get; set; }
    }
}
