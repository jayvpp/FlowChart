using System;
using System.Collections.Generic;
using CoreComponents.Model.Charts;

namespace CoreComponents.Model
{
    public class Connection : IConnection, IIdentificable
    {

        public int Id { get; private set; }
        private static int connectionId = 0;
        public IChart InitiatorChart { get; private set; }
        public IChart TargetChart { get; private set; }
        public BindingType ConnectionType { get; private set; }

        public Connection(IChart InitiatorChart, IChart TargetChart,BindingType ConnectionType)
        {
            Id = ++connectionId;
            this.InitiatorChart = InitiatorChart;
            this.TargetChart = TargetChart;
            this.ConnectionType = ConnectionType;
        }

    }
}
