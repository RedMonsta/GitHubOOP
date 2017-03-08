using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    [Serializable]
    public abstract class Figure : ISelectable, IEditable
    {
        //public virtual void Draw(PictureBox pbox) { }
        public Figure(Pen pens, int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            //pen = new Pen(pens.Brush, pens.Width);
            isSelectable = true;
            isEditable = true;

            isSelected = false;

            //position = -1;
            //pen = (Pen)pens.Clone();
            //pen.brush = pens.Brush;
            pen.color = pens.Color;
            pen.Width = pens.Width;
            Direction = 0;
        }

        public void GetPen(Pen pn)
        {
            //pen.Brush = pn.Brush;
            //pen = (Pen)pn.Clone();
            //pen.brush = pn.Brush;
            pen.color = pn.Color;
            pen.Width = pn.Width;
        }

        public abstract void Draw(Graphics gr); 

        public void Check()
        {
            /*int sx1 = X1, sx2 = X2, sy1 = Y1, sy2 = Y2;
            int tempx = Math.Min(X1, X2);
            int tempy = Math.Min(Y1, Y2);            
            X2 = Math.Max(X1, X2);
            Y2 = Math.Max(Y1, Y2);
            X1 = tempx;
            Y1 = tempy;
            if (X1 == sx1 && Y1 == sy1) chgpt = 0;
            if (X1 == sx1 && Y1 == sy1) chgpt = 0;
            if (X1 == sx1 && Y1 == sy1) chgpt = 0;
            if (X1 == sx1 && Y1 == sy1) chgpt = 0;*/

            if (X1 < X2 && Y1 < Y2) Direction = 0; //non - SE
            if (X1 > X2 && Y1 < Y2) Direction = 1; //vert - SW
            if (X1 > X2 && Y1 > Y2) Direction = 2; //vert-hor - NW
            if (X1 < X2 && Y1 > Y2) Direction = 3; //hor - NE
        }

        public void SelectFigure(Graphics gr)
        {
            gr.Clear(Color.Transparent);
            this.isSelected = true;
            var pens = new Pen(Brushes.Gray, 1);
            pens.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            gr.DrawLine(pens, X1, Y1, X2, Y1);
            gr.DrawLine(pens, X2, Y1, X2, Y2);
            gr.DrawLine(pens, X2, Y2, X1, Y2);
            gr.DrawLine(pens, X1, Y2, X1, Y1);
            pens.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            gr.DrawEllipse(pens, X1 - 3, Y1 - 3, 6, 6);
            gr.DrawEllipse(pens, X1 - 3, Y2 - 3, 6, 6);
            gr.DrawEllipse(pens, X2 - 3, Y1 - 3, 6, 6);
            gr.DrawEllipse(pens, X2 - 3, Y2 - 3, 6, 6);
            gr.DrawEllipse(pens, (X1 + X2) / 2 - 3, Y1 - 3, 6, 6);
            gr.DrawEllipse(pens, (X1 + X2) / 2 - 3, Y2 - 3, 6, 6);
            gr.DrawEllipse(pens, X1 - 3, (Y1 + Y2) / 2 - 3, 6, 6);
            gr.DrawEllipse(pens, X2 - 3, (Y1 + Y2) / 2 - 3, 6, 6);
            gr.DrawEllipse(pens, (X1 + X2) / 2 - 4, (Y1 + Y2) / 2 - 4, 8, 8);
            gr.DrawLine(pens, (X1 + X2) / 2 - 3, (Y1 + Y2) / 2 - 3, (X1 + X2) / 2 + 3, (Y1 + Y2) / 2 + 3);
            gr.DrawLine(pens, (X1 + X2) / 2 - 3, (Y1 + Y2) / 2 + 3, (X1 + X2) / 2 + 3, (Y1 + Y2) / 2 - 3);
        }

        public void Edit(int pos, MouseEventArgs e)
        {
            
            switch (pos)
                 {
                case 1:     //Top-Left
                     {
                         X1 = e.X;
                         Y1 = e.Y;
                         break;
                     }
                case 2:     //Top-Mid
                    {
                        Y1 = e.Y;
                        break;
                    }
                case 3:     //Top-Right
                    {
                        X2 = e.X;
                        Y1 = e.Y;
                        break;
                    }
                case 4:     //Mid-Right
                    {
                        X2 = e.X;
                        break;
                    }
                case 5:     //Bot-Right
                    {
                        X2 = e.X;
                        Y2 = e.Y;
                        break;
                    }
                case 6:     //Bot-Mid
                    {
                        Y2 = e.Y;
                        break;
                    }
                case 7:     //Bot-Left
                    {
                        X1 = e.X;
                        Y2 = e.Y;
                        break;
                    }
                case 8:     //Mid-Left
                    {
                        X1 = e.X;
                        break;
                    }
                case 0:     //Mid-Mid
                    {
                        Replace(e);
                        break;
                    }

                 default: { break; } 
             }
        }

        public void ChangeColor(Pen pens)
        {
            //pen = (Pen)pens.Clone();
            //pen.brush = pens.Brush;
            pen.color = pens.Color;
            pen.Width = pens.Width;
        }

        //public Pen pen;
        //private Color pencolor = new Color; pen.Color;
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public Mypen pen;
        public int Direction { get; set; }

        //private int position { get; set; }
        public bool isSelectable { get; set; }
        public bool isSelected { get; set; }
        public bool isEditable { get; set; }

        [Serializable]
        public struct Mypen
        {
            public Color color;
            //public Brush brush;
            public float Width;
        }

        private void Replace(MouseEventArgs e)
        {
            int sX = (X1 + X2) / 2 - X1;
            int sY = (Y1 + Y2) / 2 - Y1;
            X1 = e.X - sX;
            X2 = e.X + sX;
            Y1 = e.Y - sY;
            Y2 = e.Y + sY;
        }
        
    }
}
