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
                return e is RevitLinkType;
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
            //Selection sel = uidoc.Selection;

            //Reference r = sel.PickObject(
            //ObjectType.Element,
            //new LinkSelectionFilter(),
            //"Please pick an import instance");

            RevitLinkType rvtlink = doc.GetElement(doc) as RevitLinkType;

            if (rvtlink == null)
            {
                return Result.Failed;
            }

            string rb = rvtlink.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING).AsValueString();

            TaskDialog.Show("Result", rb);
            
            return Result.Succeeded;
        }

        #endregion

    }
}
