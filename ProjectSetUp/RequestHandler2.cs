using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System.Collections.ObjectModel;
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
    public class RequestHandler2 
    {
        // Store the reference of the application in revit
        UIApplication m_revit;

        //Create a list to hold all elements relating to site elements           
        IList<Element> m_siteElements = new List<Element>();
        IList<Element> m_surveyElements = new List<Element>();

        //Store all worksets which are in this model to a list
        List<String> m_worksets = new List<String>();
        public List<Workset> worksets = new List<Workset>();

        //Create an elementcatagoryfilter to filter all built in catogory with project basepoint

        /// <summary>
        /// This class get all the project information such as survey points, project base points and linked worksets 
        /// </summary>
        /// <param name="commandData"></param>
        public RequestHandler2(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            //GetProjectBasepoints();
            //GetSurvryPoints();
            //FillInformation();
            //GetWorksets();
        }
        public ReadOnlyCollection<String> Worksets
        {
            get
            {
                return new ReadOnlyCollection<String>(m_worksets);
            }
        }
        private void FillInformation()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the survry points in the current document
        /// </summary>
        private void GetSurvryPoints()
        {
            //FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            //ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            //m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();
            //foreach (Element ele in m_surveyElements)
            //{
            //    Parameter paramX = ele.ParametersMap.get_Item("E/W");
            //    String x1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
            //    String X = paramX.AsValueString();
            //    TestCommand.NS_SP = paramX.AsValueString();

            //    Parameter paramY = ele.ParametersMap.get_Item("N/S");
            //    String y1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
            //    String Y = paramY.AsValueString();
            //    TestCommand.EW_SP = paramY.AsValueString();

            //    Parameter Elevation = ele.ParametersMap.get_Item("Elev");
            //    String Ele = Elevation.AsValueString();
            //    TestCommand.Elev_SP = Elevation.AsValueString();

            //    //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
            //    //String Ang = Angle.AsValueString();
            //    //Ang_SP = Angle.AsValueString();

            //    //TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", X, Y, Ele));
            //}
        }
        /// <summary>
        /// Get all the Project base points in the current document
        /// </summary>
        private void GetProjectBasepoints()
        {
            FilteredElementCollector basepointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter siteCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);
            m_siteElements = basepointCollector.WherePasses(siteCategoryfilter).ToList<Element>();
            //foreach (Element ele in m_siteElements)
            //{
            //    Parameter paramX = ele.ParametersMap.get_Item("E/W");
            //    String x1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
            //    String X = paramX.AsValueString();
            //    NS_PBP = paramX.AsValueString();

            //    Parameter paramY = ele.ParametersMap.get_Item("N/S");
            //    String y1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
            //    String Y = paramY.AsValueString();
            //    EW_PBP = paramY.AsValueString();

            //    Parameter Elevation = ele.ParametersMap.get_Item("Elev");
            //    Elev_PBP = Elevation.AsValueString();

            //    Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
            //    String Ang = Angle.AsValueString();
            //    Ang_PBP = Angle.AsValueString();
            //    //TaskDialog.Show("Revit Model Project Basepoint", string.Format("E/W is {0}: W/S is {1}: Angle to true North is {2}",X,Y,Ang));
            //}
        }

        private void GetWorksets()
        {
            Document document = m_revit.ActiveUIDocument.Document;
            // Enumerating worksets in a document and getting basic information for each
            FilteredWorksetCollector collector = new FilteredWorksetCollector(document);
            // find all user worksets
            collector.OfKind(WorksetKind.UserWorkset);
            worksets = collector.ToList();
            
            foreach (Workset workset in worksets)
            {
                m_worksets.Add(workset.Name);
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

        public class FakeWorksets
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
