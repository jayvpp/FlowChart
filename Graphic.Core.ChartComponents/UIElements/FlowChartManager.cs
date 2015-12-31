using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.ObjectRepository;
using System.Drawing;
using CoreComponents.Factory;
using CoreComponents.Model.Charts;
using CoreComponents.Model;

namespace CoreComponents.UIElements
{
    /// <summary>
    /// FlowChartManager is in charge of performing the all the connection in the underling repository.
    /// Also, FlowChartManager is in charge of keep track of the process of connect Charts. This class is responsible
    /// for exposing to the client all methods that can be perform in the UI such as MouseDown,
    /// </summary>
    public class FlowChartManager
    {
        public FlowChartRepository Repository { get; }

        public ConnectionConfiguration  ConnectionConfig { get; protected set; }
        public event Action<FlowChartMouseArg> DisplayConnectMenu;
 
        public event EventHandler RepaintScreen;
        public FlowChartManager(FlowChartRepository repository)
        {
            this.Repository = repository;
            this.ConnectionConfig = new ConnectionConfiguration();
        }
  
        public void SetChatConnectionConfigurationByObject(ConnectionConfiguration connectionConfigObject)
        {
            ConnectionConfig = connectionConfigObject;
        }


        public void MouseDown(Point position)
        {
            if (!ConnectionConfig.TryingToConnect)
            {
                var chart = Repository.GetCharts().Where(c => c.PointIsInsideChart(position)).ToList();

                if (chart.Count <= 0) return;
                var obj = chart.First();
                var pos = position;
                DisplayConnectMenu?.Invoke(new FlowChartMouseArg(obj, pos));
            }
    

        }

        public bool TryToPerformConnection(Point position)
        {
            if (ConnectionConfig.TryingToConnect)
            {
                var charts = Repository.GetCharts().Where(c => c.PointIsInsideChart(position));
                var chartTarget = (charts.Any()) ? charts.First() : null;

                if (chartTarget == null)
                {
                    ConnectionConfig.Reset();
                    return false;
                }
                ConnectionConfig.ChartTo = (Chart)chartTarget;
                PerformConnection();
                RepaintScreen?.Invoke(this, null);
                return true;
            }
            return false;
        }


        public void PerformConnection()
        {
            if (ConnectionConfig.ChartFrom == null || ConnectionConfig.ChartTo == null)
            {
                throw new InvalidOperationException("Cannot connect Charts when some parameter is null");
            }
            var initiator = ConnectionConfig.ChartFrom;
            var target = ConnectionConfig.ChartTo;
            var type = ConnectionConfig.BindingType;

            initiator.ConnectChartWith(target, type);
            ResetChartConnectionInfo();

        }
        private void ResetChartConnectionInfo()
        {
            ConnectionConfig.ChartFrom = null;
            ConnectionConfig.ChartTo = null;
            ConnectionConfig.TryingToConnect = false;
        }
        public void MouseMoved(object sender, Point position)
        {
        
        }

        public void AddNewStandartChart()
        {
            var standartChart = ChartFactory.GetFactoryInstance.CreateStandartUIChart();
            standartChart.Text = "Standart " + standartChart.Id;
            Repository.Insert(standartChart);
        }
        public void AddNewConditionalChart()
        {
            var conditionalChart = ChartFactory.GetFactoryInstance.CreateConditionalUIChart();
            conditionalChart.Text = "Standart " + conditionalChart.Id;
            Repository.Insert(conditionalChart);
        }
        
    }
    public class FlowChartMouseArg : EventArgs
    {
        public IUiChart Obj { get;}
        public Point Location { get;}
        public FlowChartMouseArg(IUiChart obj, Point location)
        {
            Obj = obj;
            Location = location;
        }
    }
    public enum MouseState
    {
        Click,
        Move,
        MoveClicked
    }
}
