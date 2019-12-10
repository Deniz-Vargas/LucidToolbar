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

            RevitLinkInstance rvtlink = doc.GetElement(r)
              as RevitLinkInstance;

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


            ElementCategoryFilter BasepointCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);


            m_siteElements = basepointCollector.WherePasses(BasepointCategoryfilter).ToList<Element>();
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();

            Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Command");
            try
            {
                transaction.Start();
                //Do something here
                //TaskDialog.Show("Revit Model Survey Point", "Test ");
                //GetSurveyPoint_2(commandData);
                //GetSurveyPoint(commandData);

                foreach (Element ele in m_siteElements)
                {
                    Parameter paramX = ele.ParametersMap.get_Item("E/W");
                    TestCommand.EW_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble();
                    String X = paramX.AsValueString();
                    

                    Parameter paramY = ele.ParametersMap.get_Item("N/S");
                    TestCommand.NS_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble();
                    String Y = paramY.AsValueString();
                    

                    Parameter Elevation = ele.ParametersMap.get_Item("Elev");
                    TestCommand.Elev_PBP = ele.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsDouble();
                    String Ele = Elevation.AsValueString();

                    //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
                    //String Ang = Angle.AsValueString();
                    //Ang_SP = Angle.AsValueString();

                    //TaskDialog.Show("Linked Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", X, Y, Ele));
                }
                foreach (Element ele in m_surveyElements)
                {
                    Parameter paramX = ele.ParametersMap.get_Item("E/W");
                    TestCommand.EW_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble();
                    String X = paramX.AsValueString();


                    Parameter paramY = ele.ParametersMap.get_Item("N/S");
                    TestCommand.NS_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble();
                    String Y = paramY.AsValueString();


                    Parameter Elevation = ele.ParametersMap.get_Item("Elev");
                    TestCommand.Elev_SP = ele.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsDouble();
                    String Ele = Elevation.AsValueString();

                    //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
                    //String Ang = Angle.AsValueString();
                    //Ang_SP = Angle.AsValueString();

                    //TaskDialog.Show("Linked Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", X, Y, Ele));
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
                //SetSurveyPoint(commandData);
                GetSurveyPoint(commandData);
                SetBasePoint(commandData);
                transaction.Commit();
            }
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
            // Transformation from linked file to host

            //Transform t = rvtlink.GetTotalTransform();
            //BasePoint bp;


            //bp.GetParameters(BuiltInParameter.)
            foreach (Element ele in m_siteElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).Set(TestCommand.EW_PBP);
                //String X = paramX.AsValueString();
                //TestCommand.NS_SP = paramX.AsValueString();

                Parameter paramY = ele.ParametersMap.get_Item("N/S");
                ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).Set(TestCommand.NS_PBP);
                //String Y = paramY.AsValueString();
                //TestCommand.EW_SP = paramY.AsValueString();

                Parameter Elevation = ele.ParametersMap.get_Item("Elev");

                //TestCommand.Elev_SP = Elevation.AsValueString();

                //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
                //String Ang = Angle.AsValueString();
                //Ang_SP = Angle.AsValueString();

                TaskDialog.Show("Project Setup: Transfer Coordinates", "Shared Project Basepoint Reconciled"); 
                //TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", TestCommand.EW_SP, TestCommand.NS_SP,""));
            }
        }
        public void SetSurveyPoint(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();
            // Transformation from linked file to host

            //Transform t = rvtlink.GetTotalTransform();
            //BasePoint bp;


            //bp.GetParameters(BuiltInParameter.)
            foreach (Element ele in m_surveyElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).Set(TestCommand.EW_SP);
                //String X = paramX.AsValueString();
                //TestCommand.NS_SP = paramX.AsValueString();

                Parameter paramY = ele.ParametersMap.get_Item("N/S");
                ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).Set(TestCommand.NS_SP);
                //String Y = paramY.AsValueString();
                //TestCommand.EW_SP = paramY.AsValueString();

                Parameter Elevation = ele.ParametersMap.get_Item("Elev");

                //TestCommand.Elev_SP = Elevation.AsValueString();

                //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
                //String Ang = Angle.AsValueString();
                //Ang_SP = Angle.AsValueString();

                TaskDialog.Show("Project Setup: Transfer Coordinates", "Survey Basepoint Reconciled");
                //TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", TestCommand.EW_SP, TestCommand.NS_SP,""));
            }
        }
    }
}
