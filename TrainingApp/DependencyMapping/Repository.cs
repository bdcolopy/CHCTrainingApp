using AWProducts;
using BusinessLogic;
using StructureMap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingApp
{
    public class Repository
    {
        private ISalesData _salesProvider;
        private IBusiness _busProvider;

        [SetterProperty]
        public ISalesData SalesProvider
        {
            set { _salesProvider = value; }
        }

        [SetterProperty]
        public IBusiness BusinessProvider
        {
            set { _busProvider = value; }
        }
        
        [SetterProperty]
        public bool ShouldCache { get; set; }
    }
}