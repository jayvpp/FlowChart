using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoreComponents.UIElements;

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

        public void MouseDown(Point positionOfTheMouse)
        {

            IUIPrimitiveObject previousChart = CurrentChartSelected;
            foreach (var item in UIObjects)
            {
                if (item.PointIsInsideChart(positionOfTheMouse))
                {
                    CurrentChartSelected = item;
                    CurrentChartSelected.IsSelected = true;
                    CurrentChartSelected.ObjectFocusOn();
                    break;
                }
            }
            if (!IsMouseDown)
                if (previousChart != CurrentChartSelected)
                {
                    if (CurrentChartSelected != null & ChartWasSelected != null)
                        ChartWasSelected(this, CurrentChartSelected);
                }
            IsMouseDown = true;
        }
        public void MouseMove(Point newMousePosition)
        {
            if (IsMouseDown && CurrentChartSelected != null)
            {
                Rectangle newRectangle = new Rectangle(newMousePosition.X, newMousePosition.Y,
                                                       CurrentChartSelected.DrawableRegion.Width,
                                                       CurrentChartSelected.DrawableRegion.Height);
                CurrentChartSelected.DrawableRegion = newRectangle;
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
        }

      

    }
}
