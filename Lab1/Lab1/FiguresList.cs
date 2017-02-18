using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab1
{
    public class FiguresList
    {
        public FiguresList()
        {
            Size = 0;
        }
        public void DrawAll(Graphics gr)
        {
            for (int i = 0; i < Size; i++)
                Figures[i].Draw(gr);
        }
        public Figure this[int index]
        {
            get { return Figures[index]; }
            set { Figures[index] = value; if (index >= Size)Size++; }
        }
        private Figure[] Figures = new Figure[100];
        public int Size { get; set; }
    }

    public class DynamicFigList
    {
        public DynamicFigList()
        {
            Size = 0;
        }
        public Figure this[int index]
        {
            get { return Figures[index]; }
            set { Figures[index] = value; if (index >= Size) Size++; }
        }
        private Figure[] Figures = new Figure[100];
        public int Size { get; set; }
    }
}
