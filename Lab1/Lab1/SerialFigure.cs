using System;
using System.Drawing;

namespace Lab1
{
    [Serializable]
    public class SerialFigure
    {
        public int X1 { get;  }
        public int X2 { get; }
        public int Y1 { get; }
        public int Y2 { get; }

        public Color penColor { get; }
        public float penWidth { get; }

        public string Name { get; }
        public int Direction { get; }

        public bool isFilled { get; }
        public bool isUserFigure { get; }

        public string figtype { get; }
        public long Hash { get; }

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
            if (fig is UserFigure) Hash = ((UserFigure)fig).SourceFigures.CalculateHash();
            else Hash = 0;
        }
    }
}
