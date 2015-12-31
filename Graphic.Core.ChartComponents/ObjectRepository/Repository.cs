using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Model;
using CoreComponents.Model.Charts;
using CoreComponents.UIElements;

namespace CoreComponents.ObjectRepository
{
    public class FlowChartRepository  
    {
        readonly List<IUiPrimitiveObject> repository;
        public FlowChartRepository()
        {
            repository = new List<IUiPrimitiveObject>();
        }
        public IEnumerable<IUiPrimitiveObject> GetCharts()
        {
            return repository;
        }

        public void Insert(IUiPrimitiveObject element)
        {
            IUiPrimitiveObject chart = repository.Find(e => e.Id == element.Id);
            if (chart != null)
                throw new InvalidOperationException();
            repository.Add(element);
        }

        public void Remove(int elementId)
        {
            IUiPrimitiveObject chart = repository.Find(element => element.Id == elementId);
            repository.Remove(chart);
        }

        public void Remove(IUiPrimitiveObject element)
        {
            IUiPrimitiveObject chart = repository.Find(e => e.Id == element.Id);
            repository.Remove(chart);
        }

        public void Update(IUiPrimitiveObject element)
        {
            throw new NotImplementedException();
        }
    }
}