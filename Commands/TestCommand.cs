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
    [Transaction(TransactionMode.Manual)]
    class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //1: Set Survey point values
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            //Create an elementcatagoryfilter to filter all built in catogory with project basepoint
            ElementCategoryFilter siteCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //Create a list to hold all elements relating to site elements           
            IList<Element> siteElements = collector.WherePasses(siteCategoryfilter).ToElements();
            //Filtering through all elements relating to site elements 
            foreach (Element ele in siteElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                String x1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
                String X = paramX.AsValueString();

                Parameter paramY = ele.ParametersMap.get_Item("N/S");
                String y1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
                String Y = paramY.AsValueString();

                Parameter paramElev = ele.ParametersMap.get_Item("Elev");
                String Elev = paramElev.AsValueString();

                //Parameter paramWorkset = ele.ParametersMap.get_Item("");
                //XYZ projectBasePoint = new XYZ(X, Y, Elev);

                TaskDialog.Show("Revit", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}",X,Y,Elev));
            }
            

            //ProjectLocation projectLocation = uidoc.Document.ActiveProjectLocation;
            //var origin = XYZ.Zero;

            //ProjectPosition projectPosition = projectLocation.GetProjectPosition(origin);

            //projectPosition.NorthSouth;
            //projectPosition.EastWest = < double value >;
            //projectPosition.Elevation = < double value >; ;
            //projectLocation.SetProjectPosition(origin, projectPosition);

            ////2: Move survey point wrt Project base coordinate
            //var locations = collector.OfClass(typeof(BasePoint)).ToElements();

            //foreach (var locationPoint in locations)
            //{
            //    BasePoint basePoint = locationPoint as BasePoint;
            //    if (basePoint.IsShared)
            //    {
            //        basePoint.Pinned = false;
            //        basePoint.Location.Move(new XYZ(0, 1, 0));
            //    }
            //}
            //HACK: This bit worked
            //StringBuilder sb = new StringBuilder();

            //IEnumerable<BasePoint> points = new FilteredElementCollector(doc)
            //    .OfClass(typeof(BasePoint))
            //    .Cast<BasePoint>();
            //foreach (BasePoint bp in points)
            //{
            //    string name = bp.IsShared ? "surveypoint" : "project basepoint";
            //    BoundingBoxXYZ bb = bp.get_BoundingBox(null);
            //    XYZ pos = bb.Min;
            //    sb.AppendLine(string.Format("{0} :  {1}", name, pos));
            //}
            //TaskDialog.Show("debug", sb.ToString());
            //HACK: THIS bit worked 

            //FilteredElementCollector locations = new FilteredElementCollector(doc).OfClass(typeof(BasePoint));



            //StringBuilder sb = new StringBuilder();
            //IEnumerable<BasePoint> locations = new FilteredElementCollector(doc)
            //.OfClass(typeof(BasePoint))
            //.Cast<BasePoint>();
            //foreach (BasePoint bp in locations)
            //{
            //    string name = bp.IsShared ? "surveypoint" : "project basepoint";
            //    ParameterSet ps =  ;
            //    XYZ pos = ps;
            //    sb.AppendLine(string.Format("{0} : {1}", name, pos));
            //}
            //Element element = 

            //Parameter bp = GetEW(element);


            //string name = locations.IsShared ? "surveypoint" : "project basepoint";
            //BoundingBoxXYZ bb = bp.get_BoundingBox(null);
            //XYZ pos = bb.Min;
            //sb.AppendLine(string.Format("{0} :  {1}", name, pos));

            //.OfType<BasePoint>()
            //.ToList()
            //.Where(locations => locations.Name == "E/W");

            //TaskDialog.Show("debug", bp.ToString());
            //foreach (var locationPoint in locations)
            //{
            //    BasePoint basePoint = locationPoint as BasePoint;
            //    if (basePoint.IsShared == true)
            //    {
            //        //this is the survey point

            //        Location svLoc = basePoint.Location;
            //        Double bpew = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
            //        Double bpns = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
            //        Double bpel = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsValueString();
            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendLine(string.Format("Basepoint Eastwest is : {0}, Basepoint NorthSouth is : {1}", bpew, bpns));
            //        TaskDialog.Show("debug", sb.ToString());
            //    }

            //}

            return Result.Succeeded;
        }
        
    }
}
