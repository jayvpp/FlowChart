using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Model;
using CoreComponents.Model.Charts;

namespace CoreComponents.ObjectRepository
{
    public interface IRepository<T> : IEnumerable<T>
    {
        void Insert(T Element);
        void Update(T Element);
        void Remove(T Element);
        void Remove(int ElementId);
    }


    public interface IFlowChartRepository : IRepository<Chart> { } 
}
