using System;
using System.Collections.Generic;
using CoreComponents.Model.Charts;

namespace CoreComponents.Model
{
    public class Connection : IConnection, IIdentificable
    {
        private static int connectionId = 0;
        public int Id { get; private set; }
        public IChart InitiatorChart { get; private set; }
        public IChart TargetChart { get; private set; }
        public BindingType ConnectionType { get; private set; }

        public Connection(IChart initiatorChart, IChart targetChart,BindingType connectionType)
        {
            Id = ++connectionId;
            this.InitiatorChart = initiatorChart;
            this.TargetChart = targetChart;
            this.ConnectionType = connectionType;
        }

    }
}
