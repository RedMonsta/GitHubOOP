using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Lab1
{
    public class Figure
    {
        public virtual void Draw(PictureBox pbox) { }
        protected Pen pen;
    }
    public class RectLike : Figure
    {
        public override void Draw(PictureBox pbox) { }
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
    }
    public class SymbolFigure : Figure
    {
        public override void Draw(PictureBox pbox) { }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int FontSize { get; set; }
    }

    static class MainUnit
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
