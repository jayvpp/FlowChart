using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Model.Charts;

namespace CoreComponents.Model
{
    public interface IConnection : IIdentificable
    {
        IChart InitiatorChart { get; }
        IChart TargetChart { get; }
        BindingType ConnectionType { get; }
    }
    public enum BindingType
    {
        Standart,
        ToTrue,
        ToFalse
    }
}
