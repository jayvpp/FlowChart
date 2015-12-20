using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreComponents.Model;
using CoreComponents.Model.Charts;
using CoreComponents.UIElements;
using CoreComponents.UIElements.GraphicsManager;
using CoreComponents.Factory;
using CoreComponents.ObjectRepository;

namespace ChartFlowUI
{
    public partial class Form1 : Form
    {
        readonly GraphicsManager GraphicsManager;
        readonly FlowChartRepository Repository;

        readonly FlowChartManager FlowChartManager;

  
        public Form1()
        {
            InitializeComponent();
            GraphicsManager = new GraphicsManager();
            Repository = new FlowChartRepository();

            FlowChartManager = new FlowChartManager(Repository);
            FlowChartManager.DisplayConnectMenu += FlowChatManager_DisplayConnectMenu;
            FlowChartManager.RepaintScreen+= GraphicsManager_RepaintScreen;
            

            GraphicsManager.ChartWasSelected += GraphicsManager_ChangePropertyGrid;
            GraphicsManager.RepaintScreen += GraphicsManager_RepaintScreen;
            GraphicsManager.UIObjects = Repository.GetCharts();
        }

        private void FlowChatManager_DisplayConnectMenu(FlowChartMouseArg arg)
        {
            if (arg.Obj is UIStandartChart)
            {
                //fix this to update the property from the FlowChatManager
                //FlowChartManager.SetConnectionInfoFrom(arg.Obj as Chart);
                FlowChartManager.ConnectionConfig.ChartFrom = (Chart) arg.Obj;
                StandartConnectionMenu.Show(pictureBox1, arg.Location);
            }
            if (arg.Obj is UIConditionalChart)
            {
                //same fix here.
                //FlowChartManager.SetConnectionInfoTo(arg.Obj as Chart); 
                FlowChartManager.ConnectionConfig.ChartFrom = (Chart) arg.Obj;
                ConditionalConnectionMenu.Show(pictureBox1, arg.Location);
            }
        }

        private void GraphicsManager_RepaintScreen(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsManager.GraphicsHandler = e.Graphics;
            GraphicsManager.UIObjects = Repository.GetCharts();
            GraphicsManager.DrawAllObjects();
        }

        private void GraphicsManager_ChangePropertyGrid(object sender, IUIPrimitiveObject e)
        {
            propertyGrid1.SelectedObject = e;
            //Point pointInClient = pictureBox1.PointToScreen(e.CenterPoint);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            GraphicsManager.MouseClickUp();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            GraphicsManager.MouseMove(new Point() { X = e.X, Y = e.Y });
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var mouseCursor = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                FlowChartManager.MouseDown(e.Location);
            }

            if (e.Button == MouseButtons.Left)
            {
                var connectionSucced = FlowChartManager.TryToPerformConnection(e.Location);
                if (!connectionSucced)
                {
                    GraphicsManager.MouseDown(mouseCursor);
                }
            }
            //if (FlowChartManager.ConnectionConfig.TryingToConnect)
            //{
            //    IUIPrimitiveObject chartTarget = GraphicsManager.PointInInsideChart(e.Location);

            //    if (chartTarget != null)
            //    {
            //        FlowChartManager.ConnectionConfig.ChartTo = chartTarget as Chart;

            //        FlowChartManager.PerformConnection();
            //        pictureBox1.Refresh();
            //        return;
            //    }
            //}
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pictureBox1.Invalidate();
        }
    

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.SetConnection(BindingType.Standart);
        }

        private void connectTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetConnection(BindingType.ToTrue);
        }

        private void connectFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetConnection(BindingType.ToFalse);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FlowChartManager.AddNewConditionalChart();
            pictureBox1.Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FlowChartManager.AddNewStandartChart();
            pictureBox1.Invalidate();
        }

        private void connectToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetConnection(BindingType.Standart);
        }

        private  void SetConnection(BindingType bindingType)
        {
            FlowChartManager.ConnectionConfig.TryingToConnect = true;
            FlowChartManager.ConnectionConfig.BindingType = bindingType;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
