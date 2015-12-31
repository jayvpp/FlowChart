using System;
using System.Drawing;
using System.ComponentModel;

namespace CoreComponents.UIElements
{

  
    [DefaultPropertyAttribute("UIVisualProperty")]
    public class UiVisualProperties
    {
        public Font Font { get; set; }
 
        public Color BorderColor { get; set; }
        public Color TextColor { get; set; }
        public int BorderWidth { get; set; }
        public Color BackgroundColor { get; set; }
       
    }
    public interface IObjectVisualProperties
    {
        Font Font { get; set; }
 

        Color BorderColor { get; set; }
        Color TextColor { get; set; }
        int BorderWidth { get; set; }
        Color BackgroundColor { get; set; }
    }
    public static class Helpers
    {
        public static PointF TextCoordenates(this Rectangle rec,SizeF size)
          
        {

            int height = rec.Height;
            int width = rec.Width;

            return new PointF(rec.X + (width - size.Width) / 2, rec.Y + (height - size.Height) / 2);
        }
        public static Point TransforCoordenates(this Rectangle rect,Point initialpoint,Point destinationpoint)
        {
            int h = initialpoint.Y - rect.Height;
            int w = initialpoint.X - rect.Width;
            return new Point(destinationpoint.X - h, destinationpoint.Y - w);
        }
    }

  
}
