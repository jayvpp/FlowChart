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
        readonly List<IUiChart> repository;
        public FlowChartRepository()
        {
            repository = new List<IUiChart>();
        }
        public IEnumerable<IUiChart> GetCharts()
        {
            return repository;
        }

        public void Insert(IUiChart element)
        {
            IUiChart chart = repository.Find(e => e.Id == element.Id);
            if (chart != null)
                throw new InvalidOperationException();
            repository.Add(element);
        }

        public void Remove(int elementId)
        {
            IUiChart chart = repository.Find(element => element.Id == elementId);
            repository.Remove(chart);
        }

        public void Remove(IUiChart element)
        {
            IUiChart chart = repository.Find(e => e.Id == element.Id);
            repository.Remove(chart);
        }

        public void Update(IUiChart element)
        {
            throw new NotImplementedException();
        }
    }
}