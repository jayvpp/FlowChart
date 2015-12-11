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

        public abstract IConnection ConnectChartWith(IChart chart, BindingType bindingType);
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
                if (text != value)
                {
                    text = value;
                    if (ChartTextChanged != null)
                    {
                        ChartTextChanged(this, value);
                    }
                }
            }
        }
        [Browsable(false)]
        public int GetChartsOutCount
        {
            get
            {
                return ChartsOut.Length;
            }
        }
        [Browsable(false)]
        public int GetChartsInCount
        {
            get
            {
                return ChartsIn.Count;
            }
        }
        [Browsable(false)]
        public IEnumerable<IChart> GetChartElementsIn
        {
            get
            {
                return ChartsIn;
            }
        }
        [Browsable(false)]
        public IEnumerable<IChart> GetChartElementsOut
        {
            get
            {
                return ChartsOut;
            }
        }
        [Browsable(false)]
        public IEnumerable<IConnection> GetConnectionsIn
        {
            get
            {
                return ConnectionsIn;
            }
        }
        [Browsable(false)]
        public IEnumerable<IConnection> GetConnectionOut
        {
            get
            {
                return ConnectionsOut;
            }
        }

    
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Chart theObj = obj as Chart;
            if (theObj == null) return false;
            else return Equals(theObj as Chart);
        }
        public bool Equals(Chart other)
        {
            if (other == null) return false;
            return this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public class EndChart
    {

    }

    public class BeginChart
    {

    }
}