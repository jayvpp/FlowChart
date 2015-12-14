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
        static Random r = new Random(50);
        GraphicsManager GraphicsManager;
        FlowChartRepository Repository;
        ConnectionConfiguration ChartConnectionInfo = new ConnectionConfiguration();
  
        List<IUIPrimitiveObject> listOfObjects = new List<IUIPrimitiveObject>();
       
   
        public bool mouseDown = false;
        public Form1()
        {
            GraphicsManager = new GraphicsManager();
            Repository = new FlowChartRepository();
            GraphicsManager.ChartWasSelected += GraphicsManager_ChangePropertyGrid;
            GraphicsManager.RepaintScreen += GraphicsManager_RepaintScreen;
            InitializeComponent();
       
        }

        private void GraphicsManager_RepaintScreen(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            Point pointInClient = pictureBox1.PointToScreen(e.CenterPoint);
  
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                AddingChartsMenu.Show(pictureBox1, e.Location);
            }
            else
            {
                IUIPrimitiveObject chartWasClicked = GraphicsManager.PointInInsideChart(e.Location);
                ChartConnectionInfo.chartFrom = chartWasClicked as Chart;
                if (chartWasClicked != null)
                {
                    if (chartWasClicked is UIStandartChart) {
                        ChartConnectionMenu.Show(pictureBox1, e.Location);
                    }
                    if (chartWasClicked is UIConditionalChart) {
                        ConditionalConnectionMenu.Show(pictureBox1, e.Location);
                    }
                }
          
            }

            GraphicsManager.MouseClickUp();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            GraphicsManager.MouseMove(new Point() { X = e.X, Y = e.Y });
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ChartConnectionInfo.tryingToConnect)
            {
                Chart chart = GraphicsManager.PointInInsideChart(new Point(e.X, e.Y)) as Chart;
                ChartConnectionInfo.chartTo = chart;
                if (ChartConnectionInfo.chartTo != null)
                {
                    if(ChartConnectionInfo.chartFrom is UIStandartChart)
                    {
                        ChartConnectionInfo.chartFrom.ConnectChartWith(chart, ChartConnectionInfo.bindingType);
                    }
                    if (ChartConnectionInfo.chartFrom is UIConditionalChart)
                    {
                        ChartConnectionInfo.chartFrom.ConnectChartWith(chart, ChartConnectionInfo.bindingType);
                    }

                    ChartConnectionInfo.Reset();
                    pictureBox1.Invalidate();
                }
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                Point mouseCursor = new Point(e.X, e.Y);
                GraphicsManager.MouseDown(mouseCursor);
            }
        }



        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pictureBox1.Invalidate();
        }

   
    
        private void op2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var standartChart = ChartFactory.GetFactoryInstance.CreateStandartUIChart();

            standartChart.Text = "Standart " + standartChart.Id;
            Repository.Insert(standartChart);
            pictureBox1.Invalidate();

        }

        private void op1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var decitionChart = ChartFactory.GetFactoryInstance.CreateConditionalUIChart();

            decitionChart.Text = "Decition " + decitionChart.Id;
            Repository.Insert(decitionChart);
            pictureBox1.Invalidate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChartConnectionInfo.tryingToConnect = true;
            ChartConnectionInfo.bindingType = BindingType.Standart;
        }

        private void ChartConnectionMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ConditionalConnectionMenu_Opening(object sender, CancelEventArgs e)
        {
       
        }

        private void connectTrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartConnectionInfo.tryingToConnect = true;
            ChartConnectionInfo.bindingType = BindingType.ToTrue;
        }

        private void connectFalseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartConnectionInfo.tryingToConnect = true;
            ChartConnectionInfo.bindingType = BindingType.ToFalse;
        }
    }

}
