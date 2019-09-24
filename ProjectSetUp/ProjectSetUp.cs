using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using Autodesk.Revit.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LucidToolbar
{

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    class ProjectInfo : IExternalCommand
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
        public virtual Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Edit Project Information");
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            RevitCommandId id = RevitCommandId.LookupPostableCommandId(PostableCommand.ProjectInformation);

            //try
            //{
            //    using (Transaction trans = new Transaction(doc, "Open Form"))
            //    {
            //        trans.Start();
            //        MyRevitCommands.UserControl1 userControl = new MyRevitCommands.UserControl1();
            //        Window win = new Window();
            //        win.Content = userControl;
            //        win.Show();
            //        //win.Content = form;
            //        win.Show();
            //        //TaskDialog.Show("ModelessForm","You have opened up a ModelessForm");



            //        trans.Commit();
            //    }


            //    return Result.Succeeded;
            //}
            //catch (Exception e)
            //{
            //    message = e.Message;
            //    return Result.Failed;
            //}

            try
            {
                ExternalApplication.thisApp.ShowForm(commandData.Application);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

        }

        #endregion

    }
}
