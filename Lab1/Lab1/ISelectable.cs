using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    public interface ISelectable
    {
        bool isSelectable { get; set; }
        void SelectFigure(Graphics gr);
        bool isSelected { get; set; }
    }
}
