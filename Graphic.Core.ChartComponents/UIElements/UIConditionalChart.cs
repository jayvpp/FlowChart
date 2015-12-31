using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using CoreComponents.Model;
using CoreComponents.Model.Charts;

namespace CoreComponents.UIElements
{
    public class UiConditionalChart : ConditionalChart, IUiPrimitiveObject, IObjectVisualProperties
    {
        private UiVisualProperties UIVisualProperty  = new UiVisualProperties();
        private Point centerPoint;

        public UiConditionalChart()
        {

            SetDefaultAppearance();
            DrawableRegion = new Rectangle(100, 100, 180, 50);
            CalculatePins();
        }

        public IEnumerable<Point> PinIn { get; private set; }
        public IEnumerable<Point> PinOut { get; private set; }
        public bool IsSelected { get; set; }

        public Rectangle DrawableRegion { get; set; }
        protected Point PinOutTrue
        {
            get { return PinOut.ToList()[0]; }
        }

        protected Point PinOutFalse
        {
            get { return PinOut.ToList()[1]; }
        }

        public Font Font
        {
            get { return UIVisualProperty.Font; }

            set { UIVisualProperty.Font = value; }
        }


        public Color BorderColor
        {
            get { return UIVisualProperty.BorderColor; }

            set { UIVisualProperty.BorderColor = value; }
        }

        public Color TextColor
        {
            get { return UIVisualProperty.TextColor; }

            set { UIVisualProperty.TextColor = value; }
        }

        public int BorderWidth
        {
            get { return UIVisualProperty.BorderWidth; }

            set { UIVisualProperty.BorderWidth = value; }
        }

        public Color BackgroundColor
        {
            get { return UIVisualProperty.BackgroundColor; }

            set { UIVisualProperty.BackgroundColor = value; }
        }

        public virtual void SetDefaultAppearance()
        {
            BackgroundColor = Color.BlueViolet;
            Font = new Font("Arial", 12);
            TextColor = Color.Black;
            BorderWidth = 4;
            BorderColor = Color.Brown;
            BorderWidth = 4;
        }

        public Point CenterPoint
        {
            get
            {
                var w = DrawableRegion.Width;
                var h = DrawableRegion.Height;
                centerPoint = new Point(DrawableRegion.X + w/2, DrawableRegion.Y + h/2);
                return centerPoint;
            }
            set
            {
                var pCenter = value;
                DrawableRegion = new Rectangle(pCenter.X - DrawableRegion.Width/2, pCenter.Y - DrawableRegion.Height/2,
                    DrawableRegion.Width, DrawableRegion.Height);
            }
        }

        public virtual void CalculatePins()
        {
            CalculatePinIn();
            CalculatePinOut();
        }
        private void CalculatePinIn()
        {
            var width = DrawableRegion.Width;
            var height = DrawableRegion.Height;
            var pinIn = new Point(DrawableRegion.X + width / 2, DrawableRegion.Y);
            PinIn = new List<Point> { pinIn };
        }


        private void CalculatePinOut()
        {
            var width = DrawableRegion.Width;
            var height = DrawableRegion.Height;

            var pinOutTrue = new Point(DrawableRegion.X + width, DrawableRegion.Y + height / 2);
            var pinOutFalse = new Point(DrawableRegion.X, DrawableRegion.Y + height / 2);

            PinOut = new List<Point> { pinOutTrue, pinOutFalse };
        }
 
        public virtual void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            ToolBox.Pen = new Pen(BorderColor,BorderWidth);
            var px = DrawableRegion.X;
            var py = DrawableRegion.Y;
            var width = DrawableRegion.Width;
            var height = DrawableRegion.Height;

            var p1 = new Point(px + width/2, py);
            var p2 = new Point(px, py + height/2);
            var p3 = new Point(px + width/2, py + height);
            var p4 = new Point(px + width, py + height/2);


            g.DrawLine(ToolBox.Pen, p1, p2);
            g.DrawLine(ToolBox.Pen, p2, p3);
            g.DrawLine(ToolBox.Pen, p3, p4);
            g.DrawLine(ToolBox.Pen, p4, p1);
            g.FillPolygon(ToolBox.SetSolidBrushColor(BackgroundColor), new[] {p1, p2, p3, p4, p1});
            var sizeFont = g.MeasureString(Text,Font);
            g.DrawString(Text,Font, ToolBox.SetSolidBrushColor(TextColor),
                DrawableRegion.TextCoordenates(sizeFont));
            DrawConnections(g);
        }

        public void ObjectFocusOn()
        {
            //UIVisualProperty.BorderColor = Color.Red;
            //UIVisualProperty.BorderWidth = 6;
        }

        public void ObjectFocusOff()
        {
            // SetDefaultAppearance();
        }

        public bool PointIsInsideChart(Point point)
        {
            return DrawableRegion.Contains(point);
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
            ToolBox.Pen.StartCap = LineCap.RoundAnchor;
            ToolBox.Pen.EndCap = LineCap.ArrowAnchor;
            ToolBox.Pen.Color = Color.Black;

            var InitiatorChart = connection.InitiatorChart as IUiPrimitiveObject;
            var TargetChart = connection.TargetChart as IUiPrimitiveObject;

            var pinOutPoint = InitiatorChart.PinOut.ToList()[(int) connection.ConnectionType - 1];
            var pinInPoint = TargetChart.PinIn.ToList()[0];

            g.DrawLine(ToolBox.Pen, pinOutPoint, pinInPoint);
        }

      
    }
}