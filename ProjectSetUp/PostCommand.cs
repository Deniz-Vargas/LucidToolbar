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
    class PostCommand: IExternalCommand
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
            //Open Type property
            //RevitCommandId id = RevitCommandId.LookupPostableCommandId(PostableCommand.TypeProperties);
            RevitCommandId FPid = RevitCommandId.LookupPostableCommandId(PostableCommand.FloorPlan);
            //RevitCommandId Tempid = RevitCommandId.LookupPostableCommandId(PostableCommand.ApplyTemplatePropertiesToCurrentView);

            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;
            var collector = new FilteredElementCollector(doc);
            var linkedInstance = collector.OfClass(typeof(RevitLinkInstance)).FirstOrDefault();



            IEnumerable<View> views = new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => v.Name.Equals("Architectural Cleanup"));
            View template = views.FirstOrDefault();
            ElementId templateId = template.Id;




            try
            {
                transaction.Start();
                //Do something here
                //uidoc.Selection.SetElementIds(new[] { wallType.Id });
                
                //TaskDialog.Show("Congrats",string.Format("The {0} template id is:{1}",template.Name,templateId.ToString()));
                commandData.Application.PostCommand(FPid);
                //commandData.Application.PostCommand(Tempid);

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
