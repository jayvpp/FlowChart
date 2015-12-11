using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Model.Charts;

namespace CoreComponents.Model
{
    public interface ISingleConnectorChart
    {
        IConnection ConnectChartTo(IChart chart);
    }

    public interface IConditionalConnectorChart
    {
        IConnection ConnectChartToTrue(IChart chart);
        IConnection ConnectChartToFalse(IChart chart);
    }
}
