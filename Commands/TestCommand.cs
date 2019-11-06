using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using System.IO;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Autodesk.Revit.ApplicationServices.Application;
using Autodesk.Revit.Attributes;

namespace LucidToolbar
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class TestCommand : IExternalCommand
    {
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
        public static string NS_PBP { get; internal set; }
        public static string EW_PBP { get; internal set; }
        public static string Elev_PBP { get; internal set; }
        public static string Ang_PBP { get; internal set; }

        public static string NS_SP { get; internal set; }
        public static string EW_SP { get; internal set; }
        public static string Elev_SP { get; internal set; }
        public static string Ang_SP { get; internal set; }

        public static string filePath { get; internal set; }
        public IList<Workset> worksets = null;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                ExternalApplication.thisApp.ShowForm(commandData.Application);

                //Create a transaction
                //Transaction documentTransaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Document");
                //documentTransaction.Start();

                // Create a new instance of class RoomsData
                //ProjectInfo data = new ProjectInfo(commandData);
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                // If there are something wrong, give error information and return failed
                message = ex.Message;
                return Result.Failed;
            }
        }

        private static void ChangeWorkset(string name, Document doc)
        {
            using (Transaction t = new Transaction(doc))
            {   
                //Workset workset = this.worksetComboBox.SelectedItem as Workset

                t.Start("Change Workset");

                //WorksetTable worksetTable = doc.GetWorksetTable();
                //WorksetId worksetId = worksetTable.GetActiveWorksetId();
                //Workset workset = worksetTable.GetWorkset(worksetId);
                //TaskDialog.Show(workset.Name.ToString(), workset.Id.ToString());
                //Workset.Create(doc, name);
                t.Commit();
            }
        }
        public Workset CreateWorkset(Document document)
        {
            Workset newWorkset = null;
            // Worksets can only be created in a document with worksharing enabled
            if (document.IsWorkshared)
            {
                string worksetName = "New Workset";
                // Workset name must not be in use by another workset
                if (WorksetTable.IsWorksetNameUnique(document, worksetName))
                {
                    using (Transaction worksetTransaction = new Transaction(document, "Set preview view id"))
                    {
                        worksetTransaction.Start();
                        newWorkset = Workset.Create(document, worksetName);
                        worksetTransaction.Commit();
                    }
                }
            }

            return newWorkset;
        }
        public void GetWorksetsInfo(Document doc)
        {
            String message = String.Empty;
            // Enumerating worksets in a document and getting basic information for each
            FilteredWorksetCollector collector = new FilteredWorksetCollector(doc);

            // find all user worksets
            collector.OfKind(WorksetKind.UserWorkset);
            worksets = collector.ToWorksets();

            // get information for each workset
            int count = 10; // show info for 3 worksets only
            foreach (Workset workset in worksets)
            {
                message += "Workset : " + workset.Name.ToString();
                message += "\nUnique Id : " + workset.UniqueId;
                //message += "\nOwner : " + workset.Owner;
                //message += "\nKind : " + workset.Kind;
                //message += "\nIs default : " + workset.IsDefaultWorkset;
                //message += "\nIs editable : " + workset.IsEditable;
                //message += "\nIs open : " + workset.IsOpen;
                //message += "\nIs visible by default : " + workset.IsVisibleByDefault;

                TaskDialog.Show("GetWorksetsInfo", message);

                if (0 == --count)
                    break;
            }
        }
        public Workset GetActiveWorkset(Document doc)
        {
            // Get the workset table from the document
            WorksetTable worksetTable = doc.GetWorksetTable();
            // Get the Id of the active workset
            WorksetId activeId = worksetTable.GetActiveWorksetId();
            // Find the workset with that Id
            Workset workset = worksetTable.GetWorkset(activeId);
            return workset;
        }

        public  class FakeWorksets
        {
            public string Name { get; set; }
            public IList<FakeWorksets> worksets { get; set; }
            public FakeWorksets(string _name, List<FakeWorksets> FakeWorksets)
            {
                FakeWorksets = new List<FakeWorksets>();
                Name = _name;
            }

            public FakeWorksets(string v)
            {
            }
        }
    }
}
