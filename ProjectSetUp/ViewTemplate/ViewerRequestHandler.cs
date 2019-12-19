using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LucidToolbar.ProjectSetUp.ViewTemplate.AllViewsForm;

namespace LucidToolbar
{
    public class ViewerRequestHandler : IExternalEventHandler
    {
        private Request m_request = new Request();
        public Request Request
        {
            get { return m_request; }
        }

        public String GetName()
        {
            return "R2019 External Event Sample";
        }
        public void Execute(UIApplication uiapp)
        {
            try
            {
                switch (Request.Take())
                {
                    case RequestId.None:
                        {
                            return;  
                        }


                    default:
                        {
                            // some kind of a warning here should
                            // notify us about an unexpected request 
                            break;
                        }
                }
            }
            finally
            {
                ExternalApplication.thisApp.WakeFormUp();
            }

            return;
        }
    }
}
