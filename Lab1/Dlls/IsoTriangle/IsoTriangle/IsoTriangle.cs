using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace IsoTriangle
{
    [Serializable]
    public class IsoTriangle : Figure.Figure, MyInterfaces.ISelectable, MyInterfaces.IEditable, MyInterfaces.IFillingable
    {
        public IsoTriangle(Pen pens, int x1, int y1, int x2, int y2) : base(pens, x1, y1, x2, y2)
        {
            isFilled = false;
            isSelected = false;
            Name = "IsoTriangle";
        }

        public override void Draw(Graphics gr)
        {
            var pn = new Pen(pen.color, pen.Width);
            gr.DrawLine(pn, X1, Y2, X2, Y2);
            gr.DrawLine(pn, X1, Y2, (X1 + X2) / 2, Y1);
            gr.DrawLine(pn, (X1 + X2) / 2, Y1, X2, Y2);
        }

        public void Fill(Graphics gr)
        {
            SolidBrush br = new SolidBrush(pen.color);
            Point point1 = new Point(X1, Y2);
            Point point2 = new Point(X2, Y2);
            Point point3 = new Point((X1 + X2) / 2, Y1);
            Point[] points = { point1, point2, point3 };
            GraphicsPath grp = new GraphicsPath();
            grp.AddPolygon(points);
            gr.FillPath(br, grp);
        }

        public override Figure.Figure Copy()
        {
            var isot = new IsoTriangle(new Pen(pen.color, pen.Width), X1, Y1, X2, Y2);
            isot.isFilled = isFilled;
            return isot;
        }

        public bool isFilled { get; set; }
        public bool isSelected { get; set; }
    }
}
