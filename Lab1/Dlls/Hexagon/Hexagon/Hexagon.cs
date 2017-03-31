using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Hexagon
{
    [Serializable]
    public class Hexagon : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable, MyInterfaces.IFillingable
    {
        public Hexagon(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            isFilled = false;
            isSelected = false;
            Name = "Hexagon";
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

        public void Fill(Graphics gr)
        {
            SolidBrush br = new SolidBrush(pen.color);
            Point point1 = new Point((X1 + X2) / 2, Y1);
            Point point2 = new Point(X2, Y1 + (Y2 - Y1) / 3);
            Point point3 = new Point(X2, Y1 + (Y2 - Y1) / 3 * 2);
            Point point4 = new Point((X1 + X2) / 2, Y2);
            Point point5 = new Point(X1, Y1 + (Y2 - Y1) / 3 * 2);
            Point point6 = new Point(X1, Y1 + (Y2 - Y1) / 3);
            Point[] points = { point1, point2, point3, point4, point5, point6 };
            GraphicsPath grp = new GraphicsPath();
            grp.AddPolygon(points);
            gr.FillPath(br, grp);
        }

        public bool isFilled { get; set; }
        public bool isSelected { get; set; }
    }
}
