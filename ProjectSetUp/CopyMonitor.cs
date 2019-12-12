using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using Autodesk.Revit.UI.Selection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LucidToolbar
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    class CopyMonitor : IExternalCommand
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

        #region IExternalCommand Members
        //Create a list to hold all elements relating to site elements           
        IList<Element> m_levelElements = new List<Element>();
        IList<Element> m_gridElements = new List<Element>();
        IList<ElementId> m_levelIds = new List<ElementId>();
        IList<ElementId> m_gridIds = new List<ElementId>();
        public static string targetWorkset { get; set; }
        public static WorksetId activeId { get; set; }
        

        // Store the reference of the application in revit
        UIApplication m_revit;
        #endregion

        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            //Get Document
            Document doc = uidoc.Document;
            UIApplication uiapp = commandData.Application;
            Selection sel = uidoc.Selection;

            Reference r = sel.PickObject(
            ObjectType.Element,
            new LinkSelectionFilter(),
            "Please pick an import instance");
            
            //Get Linked Document
            RevitLinkInstance rvtlink = doc.GetElement(r)
              as RevitLinkInstance;

            if (rvtlink == null)
            {
                return Result.Failed;
            }

            // For this example, just focus on 
            // the levels and grids 

            var models = new FilteredElementCollector(rvtlink.GetLinkDocument());

            Transform t = rvtlink.GetTotalTransform();

            m_revit = commandData.Application;

            //Create Filtered Element Collector             
            FilteredElementCollector levelCollector = new FilteredElementCollector(rvtlink.GetLinkDocument());
            FilteredElementCollector gridCollector = new FilteredElementCollector(rvtlink.GetLinkDocument());
            
            //Create Filter
            ElementCategoryFilter levelCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_Levels);
            ElementCategoryFilter gridCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_Grids);

            //Apply Filter 
            IList<Element> m_levelElements = levelCollector.WherePasses(levelCategoryfilter).WhereElementIsNotElementType().ToElements();
            IList<Element> m_gridElements = gridCollector.WherePasses(gridCategoryfilter).WhereElementIsNotElementType().ToElements();


            IList<ElementId> m_levelIds = levelCollector.WherePasses(levelCategoryfilter).WhereElementIsNotElementType().ToElementIds().ToList();
            IList<ElementId> m_gridIds = gridCollector.WherePasses(gridCategoryfilter).WhereElementIsNotElementType().ToElementIds().ToList();
            
            //Display levels and grids count
            //TaskDialog.Show("Levels and Grids", string.Format("{0} Levels found and {1} Grids were found", m_levelElements.Count, m_gridElements.Count));

            try
            {
                using (Transaction trans = new Transaction(doc, "Create Sheet"))
                {
                    trans.Start();
                    targetWorkset = "_Levels and Grids";
                    SetWorkset(commandData);
                    ElementTransformUtils.CopyElements(rvtlink.GetLinkDocument(), m_levelIds, doc ,t, new CopyPasteOptions());
                    ElementTransformUtils.CopyElements(rvtlink.GetLinkDocument(), m_gridIds, doc, t, new CopyPasteOptions());
                    PinElements(commandData);

                    TaskDialog.Show("Copied", string.Format("{0} Levels and {1} Grids were copied", m_levelElements.Count, m_gridElements.Count));
                    trans.Commit();
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }

        }
        
        public void PinElements(ExternalCommandData commandData)
        {
            //active model list of grids and levels
            IList<Element> a_Elements = new List<Element>();
            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            //Get Document
            Document doc = uidoc.Document;
            FilteredElementCollector ElementCollector = new FilteredElementCollector(doc);

            List<BuiltInCategory> builtInCats = new List<BuiltInCategory>();
            builtInCats.Add(BuiltInCategory.OST_Levels);
            builtInCats.Add(BuiltInCategory.OST_Grids);

            ElementMulticategoryFilter levelNGridCategoryfilter = new ElementMulticategoryFilter(builtInCats);

            a_Elements = ElementCollector.WherePasses(levelNGridCategoryfilter).WhereElementIsNotElementType().ToElements(); 

            foreach (Element ele in a_Elements)
            {
                ele.Pinned = true;
            }

        }
        void GetElementParameterInformation(Document document, Element element)
        {
            // Format the prompt information string
            String prompt = "Show parameters in selected Element:";

            StringBuilder st = new StringBuilder();
            // iterate element's parameters
            foreach (Parameter para in element.Parameters)
            {
                st.AppendLine(GetParameterInformation(para, document));
            }

            // Give the user some information
            TaskDialog.Show("Revit", prompt);
        }

        String GetParameterInformation(Parameter para, Document document)
        {
            string defName = para.Definition.Name + @"\t";
            // Use different method to get parameter data according to the storage type
            switch (para.StorageType)
            {
                case StorageType.Double:
                    //covert the number into Metric
                    defName += " : " + para.AsValueString();
                    break;
                case StorageType.ElementId:
                    //find out the name of the element
                    Autodesk.Revit.DB.ElementId id = para.AsElementId();
                    if (id.IntegerValue >= 0)
                    {
                        defName += " : " + document.GetElement(id).Name;
                    }
                    else
                    {
                        defName += " : " + id.IntegerValue.ToString();
                    }
                    break;
                case StorageType.Integer:
                    if (ParameterType.YesNo == para.Definition.ParameterType)
                    {
                        if (para.AsInteger() == 0)
                        {
                            defName += " : " + "False";
                        }
                        else
                        {
                            defName += " : " + "True";
                        }
                    }
                    else
                    {
                        defName += " : " + para.AsInteger().ToString();
                    }
                    break;
                case StorageType.String:
                    defName += " : " + para.AsString();
                    break;
                default:
                    defName = "Unexposed parameter.";
                    break;
            }

            return defName;
        }
        private void SetWorkset(ExternalCommandData commandData)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            //Get Document
            Document doc = uidoc.Document;
            UIApplication uiapp = commandData.Application;
            ///Actural code in use
         
            // Enumerating worksets in a document and getting basic information for each
            FilteredWorksetCollector collector = new FilteredWorksetCollector(uiapp.ActiveUIDocument.Document);
            // find all user worksets
            collector.OfKind(WorksetKind.UserWorkset);
            IList<Workset> worksets = collector.ToWorksets();

            //set active worksetid 

            //WorksetId worksetId = worksetTable.GetActiveWorksetId();
            // Find the workset with the Id
            //Workset workset = worksetTable.GetWorkset(worksetId);
            foreach (Workset workset in worksets)
            {
                //check if there is a workset with the same name as selected in combobox
                if (workset.Name == CopyMonitor.targetWorkset)
                {
                    activeId = workset.Id;
                    uiapp.ActiveUIDocument.Document.GetWorksetTable().SetActiveWorksetId(activeId);
                }
                else
                {

                }
            }
            //TaskDialog.Show("The current active workset is: ", workset.Name.ToString());
            //Set the active workset to the targetworkset selected from the combobox

            //TaskDialog.Show("The current selected workset is: ", targetWorkset);
                

        }
    }
}