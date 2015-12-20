using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Model;
using System.ComponentModel;

namespace CoreComponents.Model.Charts
{
    public abstract class Chart : IIdentificable, IChart
    {
        public event EventHandler<string> ChartTextChanged;
        public const int MaxElement = 100;
        private string text;
        public int Id { get; private set; }
        private static int ChartId = 0;
        [Browsable(false)]
        public List<IConnection> ConnectionsIn { get; protected set; }
        [Browsable(false)]
        public IConnection[] ConnectionsOut { get; protected set; }
        [Browsable(false)]
        public IChart[] ChartsOut { get; protected set; }
        [Browsable(false)]
        public List<IChart> ChartsIn { get; protected set; }

        public  abstract IConnection ConnectChartWith(IChart chart, BindingType bindingType);
    

        protected Chart()
        {
            this.Id = ++ChartId;
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text == value) return;
                text = value;
                ChartTextChanged?.Invoke(this, value);
            }
        }
        [Browsable(false)]
        public int GetChartsOutCount => ChartsOut.Length;

        [Browsable(false)]
        public int GetChartsInCount => ChartsIn.Count;

        [Browsable(false)]
        public IEnumerable<IChart> GetChartElementsIn => ChartsIn;

        [Browsable(false)]
        public IEnumerable<IChart> GetChartElementsOut => ChartsOut;

        [Browsable(false)]
        public IEnumerable<IConnection> GetConnectionsIn => ConnectionsIn;

        [Browsable(false)]
        public IEnumerable<IConnection> GetConnectionOut => ConnectionsOut;


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Chart theObj = obj as Chart;
            if (theObj == null) return false;
            else return Equals(other: (Chart) theObj);
        }
        public bool Equals(Chart other)
        {
            return this.Id == other?.Id;
        }
        public override int GetHashCode()
        {
            // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
            return base.GetHashCode();
        }

    }
    public class ConnectionConfiguration
    {
        public Chart ChartFrom { get; set; }
        public Chart ChartTo { get; set; }
        public bool TryingToConnect { get; set; }
        public BindingType BindingType { get; set; }
        public ConnectionConfiguration(Chart from,Chart to, BindingType bindingType)
        {
            this.ChartFrom = from;
            this.ChartTo = to;
            this.BindingType = bindingType;
            this.TryingToConnect = false;
        }
        public ConnectionConfiguration()
        {

        }
        public void Reset()
        {
            ChartFrom = null;
            ChartTo = null;
            TryingToConnect = false;
        }
    }

    public class EndChart
    {

    }

    public class BeginChart
    {

    }
}