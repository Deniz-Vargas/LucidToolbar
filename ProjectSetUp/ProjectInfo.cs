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
    public class ProjectInfo 
    {
        // Store the reference of the application in revit
        UIApplication m_revit;

        //Create a list to hold all elements relating to site elements           
        IList<Element> m_siteElements = new List<Element>();
        IList<Element> m_surveyElements = new List<Element>();

        //Create an elementcatagoryfilter to filter all built in catogory with project basepoint
        
        

        
        


        /// <summary>
        /// This class get all the project information such as survey points, project base points and linked worksets 
        /// </summary>
        /// <param name="commandData"></param>
        public ProjectInfo(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            GetProjectBasepoints();
            GetSurvryPoints();
            FillInformation();
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
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();
            //foreach (Element ele in m_surveyElements)
            //{
            //    Parameter paramX = ele.ParametersMap.get_Item("E/W");
            //    String x1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
            //    String X = paramX.AsValueString();
            //    NS_SP = paramX.AsValueString();

            //    Parameter paramY = ele.ParametersMap.get_Item("N/S");
            //    String y1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
            //    String Y = paramY.AsValueString();
            //    EW_SP = paramY.AsValueString();

            //    Parameter Elevation = ele.ParametersMap.get_Item("Elev");
            //    String Ele = Elevation.AsValueString();
            //    Elev_SP = Elevation.AsValueString();

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
    }
}
