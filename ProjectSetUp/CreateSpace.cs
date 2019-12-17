using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
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
    class CreateSpace : IExternalCommand
    {
        ExternalCommandData m_commandData;
        List<Level> m_levels;
        SpaceManager m_spaceManager;
        Level m_currentLevel;
        Phase m_defaultPhase;
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
        ////public CreateSpace (ExternalCommandData commandData)
        ////{
        ////    m_commandData = commandData;
        ////    m_levels = new List<Level>();
        ////    Initialize();
        ////    m_currentLevel = m_levels[0];
        ////    Parameter para = commandData.Application.ActiveUIDocument.Document.ActiveView.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.VIEW_PHASE);
        ////    Autodesk.Revit.DB.ElementId phaseId = para.AsElementId();
        ////    m_defaultPhase = commandData.Application.ActiveUIDocument.Document.GetElement(phaseId) as Phase;
        ////}

        private void Initialize()
        {
            Document activeDoc = m_commandData.Application.ActiveUIDocument.Document;
            FilteredElementIterator levelsIterator = (new FilteredElementCollector(activeDoc)).OfClass(typeof(Level)).GetElementIterator();
        }
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            //UIApplication uiapp = commandData.Application;
            //UIDocument uidoc = uiapp.ActiveUIDocument;
            //Document doc = uidoc.Document;
            //Selection sel = uidoc.Selection;
            RevitCommandId id = RevitCommandId.LookupPostableCommandId(PostableCommand.Space);
            Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Command");


            //m_commandData = commandData;
            //m_levels = new List<Level>();
            //Initialize();
            ////m_currentLevel = m_levels[0];
            //Parameter para = commandData.Application.ActiveUIDocument.Document.ActiveView.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.VIEW_PHASE);
            //Autodesk.Revit.DB.ElementId phaseId = para.AsElementId();
            //m_defaultPhase = commandData.Application.ActiveUIDocument.Document.GetElement(phaseId) as Phase;

            try
            {
                transaction.Start();
                //Do something here
                //CreateSpaces(commandData);
                //Place spaces automatically
                               
                //Tag all space tags

                //pin all space tags

                //repeat for all spacetags

                //Select Space Naming and check names and numbers aswell as all levels 
                commandData.Application.PostCommand(id);
                //TaskDialog.Show("Congrats","You Have Successfully opened a command");


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
        public void CreateSpaces(ExternalCommandData commandData)
        {
            if (m_defaultPhase == null)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", "The phase of the active view is null, you can't create spaces in a null phase");
                return;
            }

            try
            {
                if (m_commandData.Application.ActiveUIDocument.Document.ActiveView.ViewType == Autodesk.Revit.DB.ViewType.FloorPlan)
                {
                    m_spaceManager.CreateSpaces(m_currentLevel, m_defaultPhase);
                }
                else
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Revit", "You can not create spaces in this plan view");
                }
            }
            catch (Exception ex)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", ex.Message);
            }

        }
        #endregion

    }
}
