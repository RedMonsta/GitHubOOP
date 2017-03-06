using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public interface IEditable
    {
        bool isEditable { get; set; }
        void Edit(MouseEventArgs e);
    }
}
