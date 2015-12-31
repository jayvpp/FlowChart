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

        public  UIConditionalChart CreateConditionalUIChart()
        {
            var chart = new UIConditionalChart();
           //add to repo
            return chart;
        }

        public   UIStandartChart CreateStandartUIChart()
        {
            var chart = new UIStandartChart();
            //add to repo
            return chart;
        }
        public UIConditionalChart CreateConditionalUIChart(string text)
        {
            var chart = new UIConditionalChart();
            chart.Text = text;
            //add to repo
            return chart;
        }
        public UIStandartChart CreateStandartUIChart(string text)
        {
            var chart = new UIStandartChart();
            chart.Text = text;
            //add to repo
            return chart;
        }
    }
}
