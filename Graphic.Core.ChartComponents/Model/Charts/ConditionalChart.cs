using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Model.Charts
{
    public class ConditionalChart : Chart, IConditionalConnectorChart
    {
        public IConnection ConnectChartToFalse(IChart chart)
        {
            throw new NotImplementedException();
        }

        public IConnection ConnectChartToTrue(IChart chart)
        {
            throw new NotImplementedException();
        }

        public ConditionalChart()
            : base()
        {
            ConnectionsIn = new IConnection[MaxInOutElements];
            ConnectionsOut = new IConnection[2];
            ChartsOut = new IChart[2];
            ChartsIn = new IChart[MaxInOutElements];
        }
    }
}
