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
        List<IUIPrimitiveObject> repository;
        public FlowChartRepository()
        {
            repository = new List<IUIPrimitiveObject>();
        }
        public IEnumerable<IUIPrimitiveObject> GetCharts()
        {
            return repository;
        }

        public void Insert(IUIPrimitiveObject Element)
        {
            IUIPrimitiveObject chart = repository.Find(element => element.Id == Element.Id);
            if (chart != null)
                throw new InvalidOperationException();
            repository.Add(Element);
        }

        public void Remove(int ElementId)
        {
            IUIPrimitiveObject chart = repository.Find(element => element.Id == ElementId);
            repository.Remove(chart);
        }

        public void Remove(IUIPrimitiveObject Element)
        {
            IUIPrimitiveObject chart = repository.Find(element => element.Id == Element.Id);
            repository.Remove(chart);
        }

        public void Update(IUIPrimitiveObject Element)
        {
            throw new NotImplementedException();
        }
    }
}