using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public class FiguresList
    {
        public FiguresList()
        {
            Size = 0;
           // ChoosenIndex = 0;
        }
        public void DrawAll(PictureBox pbox)
        {
            for (int i = 0; i < Size; i++)
                Figures[i].Draw(pbox);
        }
        public Figure this[int index]
        {
            get { return Figures[index]; }
            set { Figures[index] = value; if (index >= Size)Size++; }
        }
        private Figure[] Figures = new Figure[100];
        public int Size { get; set; }
        //public int ChoosenIndex { get; set; }
    }
}
