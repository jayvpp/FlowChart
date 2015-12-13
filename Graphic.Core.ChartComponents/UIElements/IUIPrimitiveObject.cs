using System.Collections.Generic;
using System.Drawing;
using CoreComponents.Model;
using System;
namespace CoreComponents.UIElements
{
    public interface IUIPrimitiveObject : IIdentificable
    {

        Rectangle DrawableRegion { get; set; }
        bool IsSelected { get; set; }
        IEnumerable<Point> PinIn { get; }
        IEnumerable<Point> PinOut { get; }
        UIVisualProperties UIVisualProperties { get; set; }
        void CalculatePins();
        void Draw(Graphics g);
        bool PointIsInsideChart(Point point);
        void ObjectFocusOff();
        void ObjectFocusOn();
        Point CenterPoint { get; set; }
     
          
    }

 
}