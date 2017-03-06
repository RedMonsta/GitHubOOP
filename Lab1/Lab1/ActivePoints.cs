using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public class ActivePoints
    {
        private struct Point
        {
            public int X;
            public int Y;
        }

        private Point[] Arr = new Point[9];

        public ActivePoints(Figure fig)
        {
            Arr[1].X = fig.X1; Arr[1].Y = fig.Y1;
            Arr[2].X = (fig.X1 + fig.X2) / 2; Arr[2].Y = fig.Y1;
            Arr[3].X = fig.X2; Arr[3].Y = fig.Y1;
            Arr[4].X = fig.X2; Arr[4].Y = (fig.Y1 + fig.Y2) / 2;
            Arr[5].X = fig.X2; Arr[5].Y = fig.Y2;
            Arr[6].X = (fig.X1 + fig.X2) / 2; Arr[6].Y = fig.Y2;
            Arr[7].X = fig.X1; Arr[7].Y = fig.Y2;
            Arr[8].X = fig.X1; Arr[8].Y = (fig.Y1 + fig.Y2) / 2;
            Arr[0].X = (fig.X1 + fig.X2) / 2; Arr[0].Y = (fig.Y1 + fig.Y2) / 2;
        }

        private Cursor[] Curs = new Cursor[] { Cursors.SizeAll, Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE,
                                               Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE, Cursors.Default };

        public Cursor ChangeCursor(MouseEventArgs e)
        {
            int S = 10;
            for (int i = 0; i < 9; i++)
            {
                if (e.X < Arr[i].X + S && e.X > Arr[i].X - S && e.Y < Arr[i].Y + S && e.Y > Arr[i].Y - S) return Curs[i];
            }
            return Curs[9];
        }

        public int GetCursorAPoint(MouseEventArgs e)
        {
            int S = 10;
            for (int i = 0; i < 9; i++)
            {
                if (e.X < Arr[i].X + S && e.X > Arr[i].X - S && e.Y < Arr[i].Y + S && e.Y > Arr[i].Y - S) return i;
            }
            return -1;
        }

    }
}