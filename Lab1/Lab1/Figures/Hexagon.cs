﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class Hexagon : Figure
    {
        public Hexagon(Pen pens, int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public Hexagon(Pen pens, Rect rect)
        {
            X1 = rect.X1;
            Y1 = rect.Y1;
            X2 = rect.X2;
            Y2 = rect.Y2;
            pen = new Pen(pens.Brush, pens.Width);
        }
        public override void Draw(Graphics gr)
        {
            gr.DrawLine(pen, (X1 + X2) / 2, Y1, X2, Y1 + (Y2 - Y1) / 3);
            gr.DrawLine(pen, X2, Y1 + (Y2 - Y1) / 3, X2, Y1 + (Y2 - Y1) / 3 * 2);
            gr.DrawLine(pen, X2, Y1 + (Y2 - Y1) / 3 * 2, (X1 + X2) / 2, Y2);
            gr.DrawLine(pen, (X1 + X2) / 2, Y2, X1, Y1 + (Y2 - Y1) / 3 * 2);
            gr.DrawLine(pen, X1, Y1 + (Y2 - Y1) / 3 * 2, X1, Y1 + (Y2 - Y1) / 3);
            gr.DrawLine(pen, X1, Y1 + (Y2 - Y1) / 3, (X1 + X2) / 2, Y1);
        }
    }
}
