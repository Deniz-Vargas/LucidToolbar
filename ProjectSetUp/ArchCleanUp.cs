using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LucidToolbar
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class ArchCleanUp : IExternalCommand
    {

        #region IExternalCommand Members

        /// <summary>
        /// Implement this method as an external command for Revit.
        /// </summary>
        /// <param name="commandData">An object that is passed to the external application 
        /// which contains data related to the command, 
        /// such as the application object and active view.</param>
        /// <param name="message">A message that can be set by the external application 
        /// which will be displayed if a failure or cancellation is returned by 
        /// the external command.</param>
        /// <param name="elements">A set of elements to which the external application 
        /// can add elements that are to be highlighted in case of failure or cancellation.</param>
        /// <returns>Return the status of the external command. 
        /// A result of Succeeded means that the API external method functioned as expected. 
        /// Cancelled can be used to signify that the user cancelled the external operation 
        /// at some point. Failure should be returned if the application is unable to proceed with 
        /// the operation.</returns>
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Command");

            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;

            //Find the Arch clean up template's id 
            IEnumerable<View> viewTemp = new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => v.Name.Equals("Architectural Cleanup"));
            View template = viewTemp.FirstOrDefault();
            ElementId templateId = template.Id;


            List<View> views = new List<View>();
            List<ViewSheet> viewSheets = new List<ViewSheet>();

            FilteredElementCollector coll= new FilteredElementCollector(doc);
            coll.OfClass(typeof(View));

            foreach (Element e in coll)
            {
                if (e is View)
                {
                    View view = e as View;
                    if (!view.IsTemplate)
                        views.Add(view);
                }
                else if (e is ViewSheet)
                {
                    viewSheets.Add(e as ViewSheet);
                }
            }



            try
            {
                transaction.Start();
                //Do something here
                //foreach (View v in views)
                //{
                //    v.ViewTemplateId = templateId;
                //}
                TaskDialog.Show("Views",string.Format("There are {0} views and {1} viewsheets in this model",views.Count(), viewSheets.Count()));
                
                //doc.ActiveView.ViewTemplateId = templateId;


            }
            catch (System.Exception e)
            {
                transaction.RollBack();
                message += e.ToString();
                return Autodesk.Revit.UI.Result.Failed;
            }
            finally
            {
                transaction.Commit();
            }
            return Autodesk.Revit.UI.Result.Succeeded;
        }

        #endregion

    }
}
