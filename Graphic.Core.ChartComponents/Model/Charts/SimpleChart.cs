using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Model.Charts
{
    public class StandartChart : Chart
    {
        public StandartChart() : base()
        {
            ConnectionsIn = new List<IConnection>(MaxElement);
            ConnectionsOut = new IConnection[1];
            ChartsIn = new List<IChart>(MaxElement);
            ChartsOut = new IChart[1];
            Text = String.Format("Chart Id{0}", Id);
        }


        public override IConnection ConnectChartWith(IChart chart, BindingType bindingType)
        {
            if (bindingType != BindingType.Standart)
            {
                throw new InvalidOperationException();
            }
            IConnection connection = new Connection(this, chart, BindingType.Standart);

            ChartsOut[0] = chart;
            ConnectionsOut[0] = connection;

            chart.ChartsIn.Add(this);
            chart.ConnectionsIn.Add(connection);

            return connection;
        }
        public IConnection ConnectChartWith(IChart chart)
        {
            return ConnectChartWith(chart, BindingType.Standart);
        }

    }
}
