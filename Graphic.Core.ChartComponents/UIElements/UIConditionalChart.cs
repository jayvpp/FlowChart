using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using CoreComponents.Model;
using CoreComponents.Model.Charts;

namespace CoreComponents.UIElements
{
    public  class UiConditionalChart : ConditionalChart, IUiChart ,IObjectVisualProperties
    {
        public UiVisualProperties UiVisualProperty;
        public IEnumerable<Point> PinIn { get; private set; }
        public IEnumerable<Point> PinOut { get; private set; }

        public bool IsSelected { get; set; }

        public Rectangle DrawableRegion { get;  set; }

        private Point PinOutTrue => PinOut.ToList()[0];

        private Point PinOutFalse => PinOut.ToList()[1];

        public UiVisualProperties UiVisualProperties
        {
            get
            {
                return UiVisualProperty;
            }
            set
            {

                UiVisualProperty = value;
            }
        }

        public Font Font
        {
            get
            {
                return UiVisualProperties.Font;
            }

            set
            {
                UiVisualProperties.Font = value;
            }
        }


        public Color BorderColor
        {
            get
            {
                return UiVisualProperties.BorderColor;
            }

            set
            {
                UiVisualProperties.BorderColor = value;
            }
        }

        public Color TextColor
        {
            get
            {
                return UiVisualProperties.TextColor;
            }

            set
            {
                UiVisualProperties.TextColor = value;
            }
        }

        public int BorderWidth
        {
            get
            {
                return UiVisualProperties.BorderWidth;
            }

            set
            {
                UiVisualProperties.BorderWidth = value;
 
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return UiVisualProperties.BackgroundColor;
            }

            set
            {
                UiVisualProperties.BackgroundColor = value;
            }
        }

        private Point centerPoint;
        public Point CenterPoint
        {
            get
            {
                int w = DrawableRegion.Width;
                int h = DrawableRegion.Height;
                centerPoint = new Point(DrawableRegion.X + w / 2, DrawableRegion.Y + h / 2);
                return centerPoint;
            }
            set {
                Point pCenter = value;
                DrawableRegion = new Rectangle(pCenter.X - (DrawableRegion.Width / 2), pCenter.Y - (DrawableRegion.Height/2), DrawableRegion.Width, DrawableRegion.Height);
            }
        }

        public UiConditionalChart() : base()
        {
            UiVisualProperty = new UiVisualProperties();
            SetDefaultAppearance();
            DrawableRegion = new Rectangle(100, 100, 180, 50);
            CalculatePins();
        }
        public void CalculatePins()
        {
            CalculatePinIn();
            CalculatePinOut();
        }

        private void CalculatePinIn()
        {
            var width = DrawableRegion.Width;
            var height = DrawableRegion.Height;
            var pinIn = new Point(DrawableRegion.X + width / 2, DrawableRegion.Y);
            PinIn = new List<Point>() { pinIn};
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            ToolBox.Pen = new Pen(UiVisualProperty.BorderColor, UiVisualProperty.BorderWidth);
            var px = DrawableRegion.X;
            var py = DrawableRegion.Y;
            var width = DrawableRegion.Width;
            var height = DrawableRegion.Height;

            var p1 = new Point(px + width / 2, py);
            var p2 = new Point(px, py + height / 2);
            var p3 = new Point(px + width / 2, py + height);
            var p4 = new Point(px + width , py + height / 2);

           
            g.DrawLine(ToolBox.Pen, p1, p2);
            g.DrawLine(ToolBox.Pen, p2, p3);
            g.DrawLine(ToolBox.Pen, p3, p4);
            g.DrawLine(ToolBox.Pen, p4, p1);
            g.FillPolygon(ToolBox.SetSolidBrushColor(UiVisualProperties.BackgroundColor), new[] { p1, p2, p3, p4, p1 });
            var sizeFont = g.MeasureString(Text, UiVisualProperties.Font);
            g.DrawString(Text, UiVisualProperties.Font, ToolBox.SetSolidBrushColor(UiVisualProperties.TextColor), DrawableRegion.TextCoordenates(sizeFont));
            DrawConnections(g);
        }
        public  void ObjectFocusOn()
        {
            //UiVisualProperty.BorderColor = Color.Red;
            //UiVisualProperty.BorderWidth = 6;
        }

        public  void ObjectFocusOff()
        {
           // SetDefaultAppearance();
        }


        private void CalculatePinOut()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point pinOutTrue = new Point(DrawableRegion.X + width ,DrawableRegion.Y + height / 2);
            Point pinOutFalse = new Point(DrawableRegion.X, DrawableRegion.Y + height / 2);
            
            PinOut = new List<Point>() { pinOutTrue, pinOutFalse };
        }

        private void DrawConnections(Graphics g)
        {
            foreach (var connection in GetConnectionOut.Where(connection => connection != null))
            {
                DrawConnectionArrow(g, connection);
            }
        }

        private void DrawConnectionArrow(Graphics g, IConnection connection)
        {

            //ToolBox.Pen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            ToolBox.Pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            ToolBox.Pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            ToolBox.Pen.Color = Color.Black;
            
            IUiChart initiatorChart = connection.InitiatorChart as IUiChart;
            IUiChart targetChart = connection.TargetChart as IUiChart;

            Point pinOutPoint = initiatorChart.PinOut.ToList()[(int)connection.ConnectionType - 1];
            Point pinInPoint = targetChart.PinIn.ToList()[0];
       
            g.DrawLine(ToolBox.Pen, pinOutPoint, pinInPoint);

        }

        public bool PointIsInsideChart(Point point)
        {
            return DrawableRegion.Contains(point);
        }

        public void SetDefaultAppearance()
        {
            UiVisualProperty.BackgroundColor = Color.BlueViolet;
            UiVisualProperty.Font = new Font("Arial", 12);
            UiVisualProperty.TextColor = Color.Black;
            UiVisualProperty.BorderWidth = 4;
            UiVisualProperty.BorderColor = Color.Brown;
            UiVisualProperty.BorderWidth = 4;
        }
        public void SetDefaultAppearance(UiVisualProperties visualProperties)
        {
            UiVisualProperty = visualProperties;
        }
    }
}
