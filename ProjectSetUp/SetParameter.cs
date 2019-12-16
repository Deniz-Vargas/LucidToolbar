using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LucidToolbar
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class SetParameter : IExternalCommand
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
        /// 

        #region LinkSelectionFilter
        public class LinkSelectionFilter : ISelectionFilter
        {
            public bool AllowElement(Element e)
            {
                return e is RevitLinkInstance;
            }

            public bool AllowReference(Reference r, XYZ p)
            {
                throw new NotImplementedException();
            }
        }
        #endregion // LinkSelectionFilter

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            Reference r = sel.PickObject(
                       ObjectType.Element,
                       new LinkSelectionFilter(),
                       "Please pick an import instance");

            RevitLinkInstance rvtlink = doc.GetElement(r)
              as RevitLinkInstance;

            ElementId instanceId = doc.GetElement(r).Id as ElementId;

            if (rvtlink == null)
            {
                return Result.Failed;
            }

            RevitLinkType type = doc.GetElement(rvtlink.GetTypeId()) as RevitLinkType;

            //var models = new FilteredElementCollector(rvtlink.GetLinkDocument());

            //Transform t = rvtlink.GetTotalTransform();
            string rb = type.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING).AsValueString();

            Parameter param = type.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING);

            //TaskDialog.Show("Result", rb);

            TaskDialog.Show("Parameter Values", string.Format("Parameter storage type {0} and value {1}",
                param.StorageType.ToString(),
                param.AsValueString()));

            using (Transaction trans = new Transaction(doc, "Set Parameter"))
            {
                trans.Start();

                //Set room bounding from NO to YES (0 to 1)
                param.Set(1);
                doc.AcquireCoordinates(instanceId);

                trans.Commit();
            }
            TaskDialog.Show("Parameter Values", string.Format("Parameter storage type {0} and value {1}",
            param.StorageType.ToString(),
            param.AsValueString()));

            return Result.Succeeded;
        }

        #endregion

    }
}
