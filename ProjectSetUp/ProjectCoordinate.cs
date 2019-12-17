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
    class ProjectCoordinate : IExternalCommand
    {
        #region Formatting
        const double _inch_to_mm = 25.4;
        const double _foot_to_mm = 12 * _inch_to_mm;

        /// <summary>
        /// Return a string for a real number
        /// formatted to two decimal places.
        /// </summary>
        public static string RealString(double a)
        {
            return a.ToString("0.0##");
        }

        /// <summary>
        /// Return a string for an XYZ point
        /// or vector with its coordinates
        /// formatted to two decimal places.
        /// </summary>
        public static string PointString(XYZ p)
        {
            return string.Format("({0},{1},{2})",
              RealString(p.X),
              RealString(p.Y),
              RealString(p.Z));
        }

        /// <summary>
        /// Return a string for an XYZ point
        /// or vector with its coordinates
        /// converted from feet to millimetres
        /// and formatted to two decimal places.
        /// </summary>
        public static string PointStringMm(XYZ p)
        {
            return string.Format("({0},{1},{2})",
              RealString(p.X * _foot_to_mm),
              RealString(p.Y * _foot_to_mm),
              RealString(p.Z * _foot_to_mm));
        }
        #endregion // Formatting

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

        #region ProjectPoints
        public static string NS_PBP { get; internal set; }
        public static string EW_PBP { get; internal set; }
        public static string Elev_PBP { get; internal set; }
        public static string Ang_PBP { get; internal set; }
        public static bool survryPointisPinned { get; internal set; }
        public static ElementId surveyPointId { get; internal set; }
        #endregion

        #region IExternalCommand Members

        //Create a list to hold all elements relating to site elements           
        IList<Element> m_siteElements = new List<Element>();
        IList<Element> m_surveyElements = new List<Element>();

       
        // Store the reference of the application in revit
        UIApplication m_revit;
        #endregion

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

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            
            Reference r = sel.PickObject(
            ObjectType.Element,
            new LinkSelectionFilter(),
            "Please pick an import instance");

            //Revit linkinstance
            RevitLinkInstance rvtlink = doc.GetElement(r)
              as RevitLinkInstance;

            //Revit Instance ID
            ElementId instanceId = doc.GetElement(r).Id as ElementId;
            
            //Revit project room bounding property
            RevitLinkType type = doc.GetElement(rvtlink.GetTypeId()) as RevitLinkType;
            Parameter param = type.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING);

            if (rvtlink == null)
            {
                return Result.Failed;
            }

            // For this example, just focus on 
            // the blue and red 

            var models = new FilteredElementCollector(rvtlink.GetLinkDocument());

            Transform t = rvtlink.GetTotalTransform();

            m_revit = commandData.Application;
            FilteredElementCollector basepointCollector = new FilteredElementCollector(rvtlink.GetLinkDocument());
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(rvtlink.GetLinkDocument());
            FilteredElementCollector linkedelementCollector = new FilteredElementCollector(rvtlink.GetLinkDocument());

            ElementCategoryFilter BasepointCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            //ElementParameterFilter RoomboundingFilter = new ElementParameterFilter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING);

            m_siteElements = basepointCollector.WherePasses(BasepointCategoryfilter).ToList<Element>();
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();

            Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Command");
            
            foreach (Element ele in m_siteElements)
            {
                TestCommand.EW_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble();
                TestCommand.NS_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble();
                TestCommand.Elev_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsDouble();
                TestCommand.Ang_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();

                //TaskDialog.Show("Linked Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", X, Y, Ele));
            }
            foreach (Element ele in m_surveyElements)
            {   
                
                TestCommand.EW_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble();
                TestCommand.NS_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble();
                TestCommand.Elev_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsDouble();
                //TestCommand.Ang_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();
            }


            try
            {
                transaction.Start();
                ///HACK DO THINGS Here
                //
                
                if (CheckIfPinned(commandData))
                {
                    TaskDialog.Show("Survey Point", "Survey point is clipped" + Environment.NewLine
                            + " Please unclip to proceed");
                    //SelSurveyPoint(commandData);
                    ICollection<ElementId> selectedElementIds = commandData
                        .Application.ActiveUIDocument.Selection.GetElementIds();
                    ElementId surveyPointId = new ElementId(BuiltInCategory.OST_SharedBasePoint);
                    selectedElementIds.Add(surveyPointId);
                    commandData.Application.ActiveUIDocument.Selection.SetElementIds(selectedElementIds);

                }
                else
                {
                    doc.AcquireCoordinates(instanceId);
                    SetBasePoint(commandData);
                    SetSurveyPoint(commandData);
                    param.Set(1);
                    rvtlink.Pinned = true;
                }
                
            }
            catch (System.Exception e)
            {
                transaction.RollBack();
                message += e.ToString();
                return Autodesk.Revit.UI.Result.Failed;
            }
            finally
            {
                //GetSurveyPoint(commandData);
                //RoomBounding(rvtlink);
                
                
                //TaskDialog.Show("Roombounding", rvtlink.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING).AsValueString());
                transaction.Commit();
            }
            //TaskDialog.Show("Project Setup: Transfer Coordinates", string.Format("Project Basepoint is set to E / W: {0}. W/S: {1}: Angle to true North is {2}", TestCommand.EW_PBP, TestCommand.NS_PBP, TestCommand.Ang_PBP));
            //TaskDialog.Show("Project Setup: Transfer Coordinates", string.Format("Project Survey point is set to E / W: {0}. W/S: {1}: Elevation is {2}", TestCommand.EW_SP, TestCommand.NS_SP, TestCommand.Elev_SP));

            return Autodesk.Revit.UI.Result.Succeeded;
        }
        public void GetSurveyPoint(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();
            // Transformation from linked file to host

            //Transform t = rvtlink.GetTotalTransform();

            foreach (Element ele in m_surveyElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                String x1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
                String X = paramX.AsValueString();
                //TestCommand.NS_SP = paramX.AsValueString();

                Parameter paramY = ele.ParametersMap.get_Item("N/S");
                String y1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
                String Y = paramY.AsValueString();
                //TestCommand.EW_SP = paramY.AsValueString();

                Parameter Elevation = ele.ParametersMap.get_Item("Elev");
                String Ele = Elevation.AsValueString();
                //TestCommand.Elev_SP = Elevation.AsValueString();

                //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
                //String Ang = Angle.AsValueString();
                //Ang_SP = Angle.AsValueString();

                TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", X, Y, Ele));
            }
        }
        public void GetSurveyPoint_2(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector locations = new FilteredElementCollector(m_revit.ActiveUIDocument.Document).OfClass(typeof(BasePoint));
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);
            //m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();

            foreach (var locationPoint in locations)
            {
                BasePoint basePoint = locationPoint as BasePoint;
                if (basePoint.IsShared == true)
                {
                    //this is the survey point

                    Location svLoc = basePoint.Location;
                    EW_PBP = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsString();
                    NS_PBP = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsString();
                    Elev_PBP = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsString();
                    Ang_PBP = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsString();
                }

                //TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}: Angle2North is {3}", EW_PBP, NS_PBP, Elev_PBP, Ang_PBP));
            }
        }
        public void SetBasePoint(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector basepointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter BaseCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);
            m_siteElements = basepointCollector.WherePasses(BaseCategoryfilter).ToList<Element>();

            foreach (Element ele in m_siteElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).Set(TestCommand.EW_PBP);
                    
                Parameter paramY = ele.ParametersMap.get_Item("N/S");
                ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).Set(TestCommand.NS_PBP);

                Parameter Elevation = ele.ParametersMap.get_Item("Elev");
            }
           
        }
        public void SetSurveyPoint(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();
            // Transformation from linked file to host
            
            foreach (Element ele in m_surveyElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                Parameter paramY = ele.ParametersMap.get_Item("N/S");

                ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).Set(TestCommand.NS_SP);
                ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).Set(TestCommand.EW_SP);

                // TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Ang is {2}", TestCommand.EW_SP, TestCommand.NS_SP, TestCommand.Ang_PBP));
            }

        }
        public void RoomBounding (ExternalCommandData commandData, RevitLinkInstance revitLink)
        {
            BuiltInParameter roombounding = BuiltInParameter.WALL_ATTR_ROOM_BOUNDING;
            Parameter parameter = revitLink.get_Parameter(roombounding);
            //revitLink.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING).AsValueString());
            //roombounding.SetValueString("YES");
            revitLink.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING).SetValueString("YES");
           
        }
        public bool CheckIfPinned(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();

            foreach (Element ele in m_surveyElements)
            {
                if (ele.ParametersMap.get_Item("E/W").IsReadOnly)
                {
                    //
                    return true;
                    
                }
            }
            return false;

        }

        public void SelSurveyPoint(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            Selection sel = uidoc.Selection;
            List<ElementId> selId = new List<ElementId>();
            ElementId surveyPointId = new ElementId(BuiltInCategory.OST_SharedBasePoint);
            selId.Add(surveyPointId);
            //List<ElementId> none = new List<ElementId>();
            //sel.SetElementIds(none);
            sel.SetElementIds(selId);
        }
    }
}
