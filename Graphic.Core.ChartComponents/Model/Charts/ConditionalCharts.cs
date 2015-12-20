using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Model.Charts
{
    public class ConditionalChart : Chart
    {
     
        public ConditionalChart() : base()
        {
            ConnectionsIn = new List<IConnection>(MaxElement);
            ConnectionsOut = new IConnection[2];
            ChartsIn = new List<IChart>(MaxElement);
            ChartsOut = new IChart[2];   //0 True, 1 False
        }

        public override IConnection ConnectChartWith(IChart chart, BindingType bindingType)
        {
            if (bindingType == BindingType.Standart) throw new InvalidOperationException();
            IConnection connection = new Connection(this, chart, bindingType);
            if (bindingType == BindingType.ToTrue)
            {
                ChartsOut[0] = chart;
                ConnectionsOut[0] = connection;
            }
            else
            {
                ChartsOut[1] = chart;
                ConnectionsOut[1] = connection;
            }
            chart.ChartsIn.Add(this);
            chart.ConnectionsIn.Add(connection);
            return connection;
        }

        public virtual IConnection ConnectChartToTrue(IChart chart)
        {
            return ConnectChartWith(chart, BindingType.ToTrue);
        }
        public virtual IConnection ConnectChartToFalse(IChart chart)
        {
            return ConnectChartWith(chart, BindingType.ToFalse);
        }
    }
}
