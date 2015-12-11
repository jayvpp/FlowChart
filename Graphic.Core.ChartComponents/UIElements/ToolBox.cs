using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace CoreComponents.UIElements
{
    public static class ToolBox
    {
        public static Pen Pen = new Pen(Color.Black, 2);
        public static SolidBrush SolidBrush = new SolidBrush(Color.Black);
        public static Pen SetPenColor(Color color)
        {
            Pen.Color = color;
            return Pen;
        }
        public static Pen SetPenWidth(int width)
        {
            Pen.Width = width;
            return Pen;
        }
        public static Pen SetPen(Color color, int width)
        {
            Pen.Color = color;
            Pen.Width = width;
            return Pen;
        }

        public static SolidBrush SetSolidBrushColor(Color color)
        {
            SolidBrush.Color = color;
            return SolidBrush;
        }

    }
}
