using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.UIElements;
using CoreComponents.ObjectRepository;
namespace CoreComponents.Factory
{
    //singleton

    public  class ChartFactory
    {
   
        private static  ChartFactory singleton;

        private ChartFactory( )
        {
        }
        public static ChartFactory GetFactoryInstance
        {
            get
            {
                if (singleton == null)
                    singleton = new ChartFactory();
                return singleton;
            }
        }

        public  UiConditionalChart CreateConditionalUIChart()
        {
            var chart = new UiConditionalChart();
           //add to repo
            return chart;
        }

        public UiStandartChart CreateStandartUIChart()
        {
            var chart = new UiStandartChart();
            //add to repo
            return chart;
        }
        public UiConditionalChart CreateConditionalUIChart(string text)
        {
            var chart = new UiConditionalChart();
            chart.Text = text;
            //add to repo
            return chart;
        }
        public UiStandartChart CreateStandartUIChart(string text)
        {
            var chart = new UiStandartChart();
            chart.Text = text;
            //add to repo
            return chart;
        }
    }
}
