using System.Drawing;

namespace Lab1
{
    interface IFillingable
    {
        void Fill(Graphics gr);
        bool isFilled { get; set; }
    }
}
