using System;
using System.Drawing;

namespace Lab1
{
    [Serializable]
    public class SerialFigure
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public Color penColor { get; set; }
        public float penWidth { get; set; }

        public string Name { get; set; }
        public int Direction { get; set; }

        public bool isFilled { get; set; }
        public bool isUserFigure { get; set; }

        public string figtype { get; set; }

        public SerialFigure(Figure.Figure fig)
        {
            X1 = fig.X1;
            X2 = fig.X2;
            Y1 = fig.Y1;
            Y2 = fig.Y2;
            penColor = fig.pen.color;
            penWidth = fig.pen.Width;
            Name = fig.GetName();
            Direction = fig.Direction;
            if (fig is MyInterfaces.IFillingable) isFilled = ((MyInterfaces.IFillingable)fig).isFilled;
            figtype = fig.GetType().ToString();
            isUserFigure = fig.isUserFigure;
        }
    }
}
