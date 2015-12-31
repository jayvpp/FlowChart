﻿using System;
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
    public class UiStandartChart : StandartChart, IUiPrimitiveObject , IObjectVisualProperties
    {
        private UiVisualProperties UIVisualProperty = new UiVisualProperties();
        private Point centerPoint;

        public UiStandartChart()
        {
            SetDefaultAppearance();
            DrawableRegion = new Rectangle(100, 100, 180, 45);
            CalculatePins();
        }

        [Browsable(false)]
        public IEnumerable<Point> PinIn { get; private set; }
        [Browsable(false)]
        public IEnumerable<Point> PinOut { get; private set; }
 
        public bool IsSelected { get; set; }

        public Rectangle DrawableRegion { get; set; }
 
        public Font Font
        {
            get
            {
                return UIVisualProperty.Font;
            }

            set
            {
                UIVisualProperty.Font = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return UIVisualProperty.BorderColor;
            }

            set
            {
                UIVisualProperty.BorderColor = value;
            }
        }

        public Color TextColor
        {
            get
            {
                return UIVisualProperty.TextColor;
            }

            set
            {
                UIVisualProperty.TextColor = value;
            }
        }

        public int BorderWidth
        {
            get
            {
                return UIVisualProperty.BorderWidth;
            }

            set
            {
                UIVisualProperty.BorderWidth = value;
 
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return UIVisualProperty.BackgroundColor;
            }

            set
            {
                UIVisualProperty.BackgroundColor = value;
            }
        }
        public virtual void SetDefaultAppearance()
        {
            BackgroundColor = Color.Aqua;
            Font = new Font("Arial", 12);
            TextColor = Color.Black;
            BorderWidth = 4;
            BorderColor = Color.Blue;
            BorderWidth = 4;
        }

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

        private void CalculatePinsIn()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point uniquePinIn = new Point(DrawableRegion.X + width / 2, DrawableRegion.Y);
            PinIn = new List<Point>() { uniquePinIn };
        }
        private  void CalculatePinsOut()
        {
            int width = DrawableRegion.Width;
            int height = DrawableRegion.Height;

            Point uniquePinOut = new Point(DrawableRegion.X +  width/2, DrawableRegion.Y + height);
            PinOut = new List<Point>() { uniquePinOut };
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
            SizeF sizeFont = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, ToolBox.SolidBrush, DrawableRegion.TextCoordenates(sizeFont));
            //DrawPins(g);
            DrawConnections(g);
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
        public bool PointIsInsideChart(Point point)
        {
            return DrawableRegion.Contains(point);
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
        //protected void DrawPins(Graphics g)
        //{
        //    foreach (var pin in PinOut)
        //    {
        //        g.DrawEllipse(ToolBox.Pen, new Rectangle(pin, new Size(4, 4)));
        //    }
        //    foreach (var pin in PinIn)
        //    {
        //        g.DrawEllipse(ToolBox.Pen, new Rectangle(pin, new Size(4, 4)));
        //    }
        //}

    }
}
