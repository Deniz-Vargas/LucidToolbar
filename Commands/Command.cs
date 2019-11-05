//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Application = Autodesk.Revit.ApplicationServices.Application;

//namespace LucidToolbar.Commands
//{
//    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
//    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
//    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
//    class Command
//    {

//        #region IExternalCommand Members

//        /// <summary>
//        /// Implement this method as an external command for Revit.
//        /// </summary>
//        /// <param name="commandData">An object that is passed to the external application 
//        /// which contains data related to the command, 
//        /// such as the application object and active view.</param>
//        /// <param name="message">A message that can be set by the external application 
//        /// which will be displayed if a failure or cancellation is returned by 
//        /// the external command.</param>
//        /// <param name="elements">A set of elements to which the external application 
//        /// can add elements that are to be highlighted in case of failure or cancellation.</param>
//        /// <returns>Return the status of the external command. 
//        /// A result of Succeeded means that the API external method functioned as expected. 
//        /// Cancelled can be used to signify that the user cancelled the external operation 
//        /// at some point. Failure should be returned if the application is unable to proceed with 
//        /// the operation.</returns>
//        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
//        {
//            Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Command");
//            try
//            {
//                transaction.Start();
//                //Do something here
//                GetCentralFileData();
//            }
//            catch (System.Exception e)
//            {
//                transaction.RollBack();
//                message += e.ToString();
//                return Autodesk.Revit.UI.Result.Failed;
//            }
//            finally
//            {
//                transaction.Commit();
//            }
//            return Autodesk.Revit.UI.Result.Succeeded;
//        }

//        private void GetCentralFileData()
//        {
//            //UIApplication uiapp = commandData.Application;
//            //UIDocument uidoc = uiapp.ActiveUIDocument;
//            //Application app = uiapp.Application;
//            //Document doc = uidoc.Document;

//            //Autodesk.Revit.ApplicationServices.Application app = this.Application;
//            Document localFileDocument = this.ActiveUIDocument.Document;

//            // Get an instance of the ModelPath class describing the central file
//            ModelPath modelPath = localFileDocument.GetWorksharingCentralModelPath();

//            // Get the string of the path for the central and local files 
//            string centralFilePath = ModelPathUtils.ConvertModelPathToUserVisiblePath(modelPath);
//            string localFilePath = localFileDocument.PathName;

//            // Local and central can't both be open at the same time in the same session
//            // But trying to call doc.Close() here doesn't work. It throws an InvalidOperationException
//            // when attempting to close the currently active document
//            // So before trying to close the currently open local file, first create and open a temporary document
//            Document tempDoc = app.NewProjectDocument(@"C:\ProgramData\Autodesk\RAC 2013\Templates\US Imperial\default.rte");
//            // But NewProjectDocument does not make the new document active, so the local file (which is the active document) still can't be closed

//            // Save the temporary file into the TEMP folder
//            string tempFileName = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "tempFile.rvt");
//            // Delete an existing file if there is one from a previous run of this macro
//            File.Delete(tempFileName);
//            tempDoc.SaveAs(tempFileName);
//            tempDoc.Close();

//            // Use OpenAndActivateDocument to make the temp file the active document
//            Autodesk.Revit.UI.UIApplication uiapp = new UIApplication(app);
//            uiapp.OpenAndActivateDocument(tempFileName);

//            // Now that the temp file is open and active, the local file can be closed
//            localFileDocument.Close();

//            // With the local file closed, we can now finally open the central file
//            // OpenDocumentFile opens the document into memory but does not make it visible in the Revit UI.
//            // Use OpenAndActivateDocument if you want the document to become active
//            Document centralFileDoc = app.OpenDocumentFile(centralFilePath);

//            int centralFileWallCount = new FilteredElementCollector(centralFileDoc).OfClass(typeof(Wall)).Count();

//            // Open the temp file
//            UIDocument tempfileUIDoc = uiapp.OpenAndActivateDocument(tempFileName);

//            // Close the central file
//            centralFileDoc.Close();

//            // Open the local file
//            uiapp.OpenAndActivateDocument(localFilePath);

//            // Close the temp file
//            tempfileUIDoc.Document.Close();

//            // Finally we are back to having only the local file open!
//            // Display the data about the central file that was collected when the central file was open
//            TaskDialog.Show("Central File Data", centralFileWallCount + " walls in " + centralFilePath);
//        }




//        #endregion

//    }
//}
