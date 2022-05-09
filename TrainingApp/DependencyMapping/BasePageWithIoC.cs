using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TrainingApp
{
    public class BasePageWithIoC : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            IoC.BuildUp(this);
        }
    }
}