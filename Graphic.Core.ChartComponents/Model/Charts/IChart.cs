using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Model.Charts
{

    public interface IChart : IIdentificable
    {
        string Text { get; set; }
        int GetChartsOutCount { get; }
        int GetChartsInCount { get; }
        IEnumerable<IChart> GetChartElementsIn { get; }
        IEnumerable<IChart> GetChartElementsOut { get; }
        IEnumerable<IConnection> GetConnectionsIn { get; }
        IEnumerable<IConnection> GetConnectionOut { get; }
        List<IConnection> ConnectionsIn { get; }
        IConnection[] ConnectionsOut { get; }
        IChart[] ChartsOut { get; }
        List<IChart> ChartsIn { get; }
        IConnection ConnectChartWith(IChart chart, BindingType bindingType);

    }


    public enum ChartType
    {
        Standart,
        Conditional
    }
}