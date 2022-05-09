using AWConnect;
using AWProducts;
using BusinessLogic;
using DataAccessMocker;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingApp
{
    public class ScanningRegistry : Registry
    {
        public ScanningRegistry()
        {
            this.For<ISalesData>()
                .Use<InjectedHandler>();
                //.Use<Mocker>();

            this.Policies.SetAllProperties(y => y.WithAnyTypeFromNamespaceContainingType<ISalesData>());

            this.For<IBusiness>().Use<BusinessLogic.BusinessLogic>();
            this.Policies.SetAllProperties(y => y.WithAnyTypeFromNamespaceContainingType<IBusiness>());


        }
    }
}