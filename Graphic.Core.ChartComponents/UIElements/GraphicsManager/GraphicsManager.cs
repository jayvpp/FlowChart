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
        public event EventHandler<IUiPrimitiveObject> ChartWasSelected;
        public event EventHandler RepaintScreen;

        public IEnumerable<IUiPrimitiveObject> UiObjects { get; set; }

        private IUiPrimitiveObject currentChartSelected = null;
        private bool isMouseDown = false;
        //private Point pointInsideChart;
        public GraphicsManager(Graphics graphicsHandler)
        {
            this.GraphicsHandler = graphicsHandler;
        }
        public GraphicsManager()
        {

        }
        public void DrawAllObjects()
        {
            foreach (var obj in UiObjects)
            {
                obj.Draw(GraphicsHandler);
            }
        }

        public IUiPrimitiveObject PointInInsideChart(Point point)
        {
            return UiObjects.FirstOrDefault(chart => chart.PointIsInsideChart(point));
        }

   
        public void MouseDown(Point positionOfTheMouse)
        {
            isMouseDown = true;
            foreach (var chart in UiObjects)
            {
                if (chart.PointIsInsideChart(positionOfTheMouse)) {
                    currentChartSelected = chart;
                    currentChartSelected.IsSelected = true;
                    currentChartSelected.ObjectFocusOn();
                    //pointInsideChart = positionOfTheMouse;
                    ChartWasSelected?.Invoke(this, currentChartSelected);
                }
            }
        }
        public void MouseMove(Point newMousePosition)
        { 
            if (isMouseDown && currentChartSelected != null)
            {
                currentChartSelected.CenterPoint = newMousePosition;
                currentChartSelected.CalculatePins();
                if (RepaintScreen == null)
                {
                    throw new InvalidProgramException("RepaintScreen event need an event handler");
                }
                RepaintScreen(this, null);
            }

        }
        public void MouseClickUp()
        {
            isMouseDown = false;
            if (currentChartSelected != null)
            {
                currentChartSelected.ObjectFocusOff();
                currentChartSelected.IsSelected = false;
            }
            currentChartSelected = null;
        }

    }

}
