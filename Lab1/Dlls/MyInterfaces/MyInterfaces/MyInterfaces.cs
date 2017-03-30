using System.Windows.Forms;
using System.Drawing;

namespace MyInterfaces
{
    public interface IEditable
    {
        void Edit(int pos, MouseEventArgs e);
    }

    public interface IFillingable
    {
        void Fill(Graphics gr);
        bool isFilled { get; set; }
    }

    public interface ISelectable
    {
        bool isSelected { get; set; }
        void SelectFigure(Graphics gr);
    }
}
