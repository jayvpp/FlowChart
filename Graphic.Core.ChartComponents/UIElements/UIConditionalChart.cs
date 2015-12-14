using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using CoreComponents.Model;
using CoreComponents.Model.Charts;

namespace CoreComponents.UIElements
{
    public class UIConditionalChart : ConditionalChart, IUIPrimitiveObject ,IObjectVisualProperties
    {
        public UIVisualProperties UIVisualProperty;



        public IEnumerable<Point> PinIn { get; private set; }
        public IEnumerable<Point> PinOut { get; private set; }

        public bool IsSelected { get; set; }

        public Rectangle DrawableRegion { get;  set; }
        protected Point PinOutTrue
        {
            get
            {
                return PinOut.ToList()[0];
            }
        }
        protected Point PinOutFalse
        {
            get
            {
                return PinOut.ToList()[1];
            }
        }

        public UIVisualProperties UIVisualProperties
        {
            get
            {
                return UIVisualProperty;
            }
            set
            {

                UIVisualProperty = value;
            }
        }

        public Font Font
        {
            get
            {
                return UIVisualProperties.Font;
            }

            set
            {
                UIVisualProperties.Font = value;
            }
        }


        public Color BorderColor
        {
            get
            {
                return UIVisualProperties.BorderColor;
            }

            set
            {
                UIVisualProperties.BorderColor = value;
            }
        }

        public Color TextColor
        {
            get
            {
                return UIVisualProperties.TextColor;
            }

            set
            {
                UIVisualProperties.TextColor = value;
            }
        }

        public int BorderWidth
        {
            get
            {
                return UIVisualProperties.BorderWidth;
            }

            set
            {
                UIVisualProperties.BorderWidth = value;
 
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return UIVisualProperties.BackgroundColor;
            }

            set
            {
                UIVisualProperties.BackgroundColor = value;
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

        public UIConditionalChart() : base()
        {
            UIVisualProperty = new UIVisualProperties();
            SetDefaultAppearance();
            DrawableRegion = new Rectangle(100, 100, 180, 50);
            CalculatePins();
        }
        public virtual void CalculatePins()
        {
            CalculatePinIn();
            CalculatePinOut();
        }

        private void CalculatePinIn()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;
            Point pinIn = new Point(DrawableRegion.X + width / 2, DrawableRegion.Y);
            PinIn = new List<Point>() { pinIn};
        }

        public virtual void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            ToolBox.Pen = new Pen(UIVisualProperty.BorderColor, UIVisualProperty.BorderWidth);
            int px = DrawableRegion.X;
            int py = DrawableRegion.Y;
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point p1 = new Point(px + width / 2, py);
            Point p2 = new Point(px, py + height / 2);
            Point p3 = new Point(px + width / 2, py + height);
            Point p4 = new Point(px + width , py + height / 2);

           
            g.DrawLine(ToolBox.Pen, p1, p2);
            g.DrawLine(ToolBox.Pen, p2, p3);
            g.DrawLine(ToolBox.Pen, p3, p4);
            g.DrawLine(ToolBox.Pen, p4, p1);
            g.FillPolygon(ToolBox.SetSolidBrushColor(UIVisualProperties.BackgroundColor), new[] { p1, p2, p3, p4, p1 });
            SizeF sizeFont = g.MeasureString(Text, UIVisualProperties.Font);
            g.DrawString(Text, UIVisualProperties.Font, ToolBox.SetSolidBrushColor(UIVisualProperties.TextColor), DrawableRegion.TextCoordenates(sizeFont));
            DrawConnections(g);
        }
        public  void ObjectFocusOn()
        {
            //UIVisualProperty.BorderColor = Color.Red;
            //UIVisualProperty.BorderWidth = 6;
        }

        public  void ObjectFocusOff()
        {
           // SetDefaultAppearance();
        }


        protected void CalculatePinOut()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point pinOutTrue = new Point(DrawableRegion.X + width ,DrawableRegion.Y + height / 2);
            Point pinOutFalse = new Point(DrawableRegion.X, DrawableRegion.Y + height / 2);
            
            PinOut = new List<Point>() { pinOutTrue, pinOutFalse };
        }

        protected virtual void DrawConnections(Graphics g)
        {
            foreach (var connection in GetConnectionOut)
            {
                if (connection != null)
                    DrawConnectionArrow(g, connection);
            }
        }

        private void DrawConnectionArrow(Graphics g, IConnection connection)
        {

            //ToolBox.Pen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            ToolBox.Pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            ToolBox.Pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            ToolBox.Pen.Color = Color.Black;

            IUIPrimitiveObject InitiatorChart = connection.InitiatorChart as IUIPrimitiveObject;
            IUIPrimitiveObject TargetChart = connection.TargetChart as IUIPrimitiveObject;

            Point pinOutPoint = InitiatorChart.PinOut.ToList()[(int)connection.ConnectionType - 1];
            Point pinInPoint = TargetChart.PinIn.ToList()[0];

            g.DrawLine(ToolBox.Pen, pinOutPoint, pinInPoint);

        }

        public bool PointIsInsideChart(Point point)
        {
            return DrawableRegion.Contains(point);
        }

        public virtual void SetDefaultAppearance()
        {
            UIVisualProperty.BackgroundColor = Color.BlueViolet;
            UIVisualProperty.Font = new Font("Arial", 12);
            UIVisualProperty.TextColor = Color.Black;
            UIVisualProperty.BorderWidth = 4;
            UIVisualProperty.BorderColor = Color.Brown;
            UIVisualProperty.BorderWidth = 4;
        }
        public virtual void SetDefaultAppearance(UIVisualProperties visualProperties)
        {
            UIVisualProperty = visualProperties;
        }
    }
}
