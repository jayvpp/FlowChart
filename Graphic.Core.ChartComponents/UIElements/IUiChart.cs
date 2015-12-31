using System.Collections.Generic;
using System.Drawing;
using CoreComponents.Model;
using System;
namespace CoreComponents.UIElements
{
    public interface IUiChart : IIdentificable
    {

        Rectangle DrawableRegion { get; set; }
        bool IsSelected { get; set; }
        IEnumerable<Point> PinIn { get; }
        IEnumerable<Point> PinOut { get; }
        UiVisualProperties UiVisualProperties { get; set; }
        void CalculatePins();
        void Draw(Graphics g);
        bool PointIsInsideChart(Point point);
        void ObjectFocusOff();
        void ObjectFocusOn();
        Point CenterPoint { get; set; }

        //event EventHandler ObjectClicked;
        //event EventHandler ObjectMoved;
        //event EventHandler MouseEnter;
        //event EventHandler MouseLeave;
        //event EventHandler ChartAttached;
        //event EventHandler ChartDeAttached;


    }

 
}