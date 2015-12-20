using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoreComponents.Model;
using CoreComponents.Model.Charts;
using System.ComponentModel;

namespace CoreComponents.UIElements
{
    public class UIStandartChart : StandartChart, IUiPrimitiveObject , IObjectVisualProperties
    {
 
        public UIVisualProperties UIVisualProperty = new UIVisualProperties();

        public event EventHandler NeedRepainting;
        [Browsable(false)]
        public IEnumerable<Point> PinIn { get; private set; }
        [Browsable(false)]
        public IEnumerable<Point> PinOut { get; private set; }
 
        public bool IsSelected { get; set; }

        public Rectangle DrawableRegion { get; set; }

        public UIVisualProperties UiVisualProperties
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
            set
            {
                Point pCenter = value;
                DrawableRegion = new Rectangle(pCenter.X - DrawableRegion.Width / 2, pCenter.Y - (DrawableRegion.Height/2), DrawableRegion.Width, DrawableRegion.Height);
            }
        }

        public virtual void CalculatePins()
        {
            CalculatePinsIn();
            CalculatePinsOut();

        }
        public UIStandartChart()
        {
            SetDefaultAppearance();
            DrawableRegion = new Rectangle(100, 100, 180, 45);
            CalculatePins();
        }
   
        private  void CalculatePinsOut()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point uniquePinOut = new Point(DrawableRegion.X +  width/2, DrawableRegion.Y + height);
            PinOut = new List<Point>() { uniquePinOut };
        }
        private void CalculatePinsIn()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point uniquePinIn = new Point(DrawableRegion.X + width / 2, DrawableRegion.Y);
            PinIn = new List<Point>() { uniquePinIn };
        }

        public virtual void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ToolBox.SetSolidBrushColor(UIVisualProperty.BackgroundColor);
            ToolBox.SetPen(BorderColor, BorderWidth);
            ToolBox.SetSolidBrushColor(BackgroundColor);

            g.DrawRectangle(ToolBox.Pen, DrawableRegion);
            g.FillRectangle(ToolBox.SolidBrush, DrawableRegion);
            ToolBox.SetSolidBrushColor(UIVisualProperty.TextColor);
            SizeF sizeFont = g.MeasureString(Text, UiVisualProperties.Font);
            g.DrawString(Text, UiVisualProperties.Font, ToolBox.SolidBrush, DrawableRegion.TextCoordenates(sizeFont));
            //DrawPins(g);
            DrawConnections(g);
        }

      
        public void SetDefaultAppearanceWithObject(UIVisualProperties uiVisualAppearance)
        {
            UIVisualProperty = uiVisualAppearance;
        }
        public virtual void SetDefaultAppearance()
        {
            UIVisualProperty.BackgroundColor = Color.Aqua;
            UIVisualProperty.Font = new Font("Arial", 12);
            UIVisualProperty.TextColor = Color.Black;
            UIVisualProperty.BorderWidth = 4;
            UIVisualProperty.BorderColor = Color.Blue;
            UIVisualProperty.BorderWidth = 4;
        }

       
        public  void ObjectFocusOn()
        {
            //UIVisualProperty.BorderColor = Color.Red;
            //UIVisualProperty.BorderWidth = 6;
        }
        public void ObjectFocusOff()
        {
            //SetDefaultAppearance();
        }
        protected void DrawPins(Graphics g)
        {
            foreach (var pin in PinOut)
            {
                g.DrawEllipse(ToolBox.Pen, new Rectangle(pin, new Size(4, 4)));
            }
            foreach (var pin in PinIn)
            {
                g.DrawEllipse(ToolBox.Pen, new Rectangle(pin, new Size(4, 4)));
            }
        }

        protected void DrawConnections(Graphics g)
        {
            foreach (var connection in GetConnectionOut)
            {
                if (connection != null)
                    DrawConnectionArrow(g, connection);
            }
        }
        private void DrawConnectionArrow(Graphics g, IConnection connection)
        {
            ToolBox.Pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            ToolBox.Pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            ToolBox.Pen.Width = 2;
            ToolBox.Pen.Color = Color.Black;
            IUiPrimitiveObject InitiatorChart = connection.InitiatorChart as IUiPrimitiveObject;
            IUiPrimitiveObject TargetChart = connection.TargetChart as IUiPrimitiveObject;

            Point pinOutPoint = InitiatorChart.PinOut.ToList()[0];
            Point pinInPoint = TargetChart.PinIn.ToList()[0];
        
            g.DrawLine(ToolBox.Pen, pinOutPoint, pinInPoint);

        }
        
        public bool PointIsInsideChart(Point point)
        {
            return DrawableRegion.Contains(point);
        }
    }
}
