using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoreComponents.UIElements;
using System.Diagnostics;

namespace CoreComponents.UIElements.GraphicsManager
{
    public class GraphicsManager
    {
        public Graphics GraphicsHandler { get; set; }
        public event EventHandler<IUIPrimitiveObject> ChartWasSelected;
        public event EventHandler RepaintScreen;

        public IEnumerable<IUIPrimitiveObject> UIObjects { get; set; }

        private IUIPrimitiveObject CurrentChartSelected = null;

        private bool IsMouseDown = false;

        public GraphicsManager(Graphics graphicsHandler)
        {
            this.GraphicsHandler = graphicsHandler;
        }
        public GraphicsManager()
        {

        }
        public void DrawAllObjects()
        {
            foreach (var obj in UIObjects)
            {
                obj.Draw(GraphicsHandler);
            }
        }


        Point pointInsideChart;
        public void MouseDown(Point positionOfTheMouse)
        {
            IsMouseDown = true;
            foreach (var chart in UIObjects)
            {
                if (chart.PointIsInsideChart(positionOfTheMouse)) {
                    CurrentChartSelected = chart;
                    CurrentChartSelected.IsSelected = true;
                    CurrentChartSelected.ObjectFocusOn();
                    pointInsideChart = positionOfTheMouse;
                    ChartWasSelected(this, CurrentChartSelected);
                }
            }
        }
        public void MouseMove(Point newMousePosition)
        { 
            if (IsMouseDown && CurrentChartSelected != null)
            {
                CurrentChartSelected.CenterPoint = newMousePosition;
                CurrentChartSelected.CalculatePins();
                if (RepaintScreen == null)
                {
                    throw new InvalidProgramException("RepaintScreen event need an event handler");
                }
                RepaintScreen(this, null);
            }

        }

        public void MouseClickUp()
        {
            IsMouseDown = false;
            if (CurrentChartSelected != null)
            {
                CurrentChartSelected.ObjectFocusOff();
                CurrentChartSelected.IsSelected = false;
            }
            CurrentChartSelected = null;
        }

    }

}
