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
        // Store the reference of the application in revit
        UIApplication m_revit;

        //Create a list to hold all elements relating to site elements           
        IList<Element> m_siteElements = new List<Element>();
        IList<Element> m_surveyElements = new List<Element>();
        public void run()
        {
            //ModelessForm1 = new ModelessForm1();

        }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            RevitStartInfo.RevitApp = commandData.Application.Application;
            RevitStartInfo.RevitDoc = commandData.Application.ActiveUIDocument.Document;
            RevitStartInfo.RevitProduct = commandData.Application.Application.Product;

            Transaction documentTransaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Document");

            try
            {
                documentTransaction.Start();
                //get current project information
                Autodesk.Revit.DB.ProjectInfo pi = commandData.Application.ActiveUIDocument.Document.ProjectInformation;
                // show main form
                using (ModelessForm1 pif = new ModelessForm1(new ProjectInfoWrapper(pi)))

                //ProjectInfo data = new ProjectInfo(commandData);
                ExternalApplication.thisApp.ShowForm(commandData.Application);
                //ProjectInfo(commandData);
                documentTransaction.Commit();
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                // If there are something wrong, give error information and return failed
                documentTransaction.RollBack();
                message = ex.Message;
                return Result.Failed;
            }


        }
        public void ProjectInfo(ExternalCommandData commandData)
        {
            m_revit = commandData.Application;
            FilteredElementCollector surveypointCollector = new FilteredElementCollector(m_revit.ActiveUIDocument.Document);
            ElementCategoryFilter SurveyCategoryfilter = new ElementCategoryFilter(BuiltInCategory.OST_SharedBasePoint);
            m_surveyElements = surveypointCollector.WherePasses(SurveyCategoryfilter).ToList<Element>();
            foreach (Element ele in m_surveyElements)
            {
                Parameter paramX = ele.ParametersMap.get_Item("E/W");
                String x1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsValueString();
                String X = paramX.AsValueString();
                TestCommand.NS_SP = paramX.AsValueString();

                Parameter paramY = ele.ParametersMap.get_Item("N/S");
                String y1 = ele.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsValueString();
                String Y = paramY.AsValueString();
                TestCommand.EW_SP = paramY.AsValueString();

                Parameter Elevation = ele.ParametersMap.get_Item("Elev");
                String Ele = Elevation.AsValueString();
                TestCommand.Elev_SP = Elevation.AsValueString();

                //Parameter Angle = ele.ParametersMap.get_Item("Angle to True North");
                //String Ang = Angle.AsValueString();
                //Ang_SP = Angle.AsValueString();

                //TaskDialog.Show("Revit Model Survey Point", string.Format("E/W is {0}: W/S is {1}: Elevation is {2}", X, Y, Ele));
            }

        }


    }
    public static class RevitStartInfo
    {
        #region Fields
        /// <summary>
        /// Current Revit application
        /// </summary>
        public static Application RevitApp;

        /// <summary>
        /// Active Revit document
        /// </summary>
        public static Document RevitDoc;

        /// <summary>
        /// Current Revit Product
        /// </summary>
        public static ProductType RevitProduct;

        /// <summary>
        /// Time Zone Array
        /// </summary>
        public static string[] TimeZones;

        /// <summary>
        /// BuildingType and its display string map.
        /// </summary>
        public static Dictionary<object, string> BuildingTypeMap;

        /// <summary>
        /// ServiceType and its display string map.
        /// </summary>
        public static Dictionary<object, string> ServiceTypeMap;

        /// <summary>
        /// ExportComplexity and its display string map.
        /// </summary>
        public static Dictionary<object, string> ExportComplexityMap;

        /// <summary>
        /// HVACLoadLoadsReportType and its display string map.
        /// </summary>
        public static Dictionary<object, string> HVACLoadLoadsReportTypeMap;

        /// <summary>
        /// HVACLoadConstructionClass and its display string map.
        /// </summary>
        public static Dictionary<object, string> HVACLoadConstructionClassMap;

        /// <summary>
        /// Initialize some static members
        /// </summary>
        static RevitStartInfo()
        {
            #region TimeZones
            TimeZones = new string[]{
            "(GMT-12:00) International Date Line West",
            "(GMT-11:00) Midway Island, Samoa",
            "(GMT-10:00) Hawaii",
            "(GMT-09:00) Alaska",
            "(GMT-08:00) Pacific Time (US/Canada)",
            "(GMT-08:00) Tijuana, Baja California",
            "(GMT-07:00) Arizona",
            "(GMT-07:00) Chihuahua, La Paz, Mazatlan - New",
            "(GMT-07:00) Chihuahua, La Paz, Mazatlan - Old",
            "(GMT-07:00) Mountain Time (US/Canada)",
            "(GMT-06:00) Central America",
            "(GMT-06:00) Central Time (US/Canada)",
            "(GMT-06:00) Guadalajara, Mexico City, Monterrey - New",
            "(GMT-06:00) Guadalajara, Mexico City, Monterrey - Old",
            "(GMT-06:00) Saskatchewan",
            "(GMT-05:00) Bogota, Lima, Quito, Rio Branco",
            "(GMT-05:00) Eastern Time (US/Canada)",
            "(GMT-05:00) Indiana (East)",
            "(GMT-04:00) Atlantic Time (Canada)",
            "(GMT-04:00) Caracas, La Paz",
            "(GMT-04:00) Santiago",
            "(GMT-03:30) Newfoundland",
            "(GMT-03:00) Brazilia",
            "(GMT-03:00) Buanos Aires, Georgetown",
            "(GMT-03:00) Greenland",
            "(GMT-03:00) Montevideo",
            "(GMT-02:00) Mid-Atlantic",
            "(GMT-01:00) Azores",
            "(GMT-01:00) Cape Verde Is.",
            "(GMT) Casablanca, Monrovia,Reykjavik",
            "(GMT) Greenwich Time: Dublin, Edinburgh, Lisbon, London",
            "(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna",
            "(GMT+01:00) Belgrade, Brastislava, Budapest, Ljubljana, Prague",
            "(GMT+01:00) Brussels, Copenhagen, Madrid, Paris",
            "(GMT+01:00) Sarajevo, Skopje, Sofija, Vilnus, Warsaw, Zagreb",
            "(GMT+01:00) West Central Africa",
            "(GMT+02:00) Amman",
            "(GMT+02:00) Athens, Bucharest, Istanbul",
            "(GMT+02:00) Beirut",
            "(GMT+02:00) Cairo",
            "(GMT+02:00) Harare, Pretoria",
            "(GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius",
            "(GMT+02:00) Jerusalem",
            "(GMT+02:00) Minsk",
            "(GMT+02:00) Windhoek",
            "(GMT+03:00) Baghdad",
            "(GMT+03:00) Kuwait, Riyadh",
            "(GMT+03:00) Moscow, St. Petersburg, Volgograd",
            "(GMT+03:00) Nairobi",
            "(GMT+03:00) Tbilisi",
            "(GMT+03:00) Tehran",
            "(GMT+04:00) Abu Dhabi, Muscat",
            "(GMT+04:00) Baku",
            "(GMT+04:00) Yerevan",
            "(GMT+04:30) Kabul",
            "(GMT+05:00) Ekaterinburg",
            "(GMT+05:00) Islamabad, Karachi, Tashkent",
            "(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi",
            "(GMT+05:30) Sri Jayawardenepura",
            "(GMT+05:45) Kathmandu ",
            "(GMT+06:00) Almaty, Novosibirsk",
            "(GMT+06:00) Astana, Dhaka",
            "(GMT+06:30) Yangon (Rangoon)",
            "(GMT+07:00) Bangkok, Hanoi, Jakarta ",
            "(GMT+07:00) Krasnoyarsk ",
            "(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi ",
            "(GMT+08:00) Irkutsk, Ulaan Bataar ",
            "(GMT+08:00) Kuala Lumpur, Singapore ",
            "(GMT+08:00) Perth",
            "(GMT+08:00) Taipei",
            "(GMT+09:00) Osaka, Sapporo, Tokyo",
            "(GMT+09:00) Seoul",
            "(GMT+09:00) Yakutsk",
            "(GMT+09:30) Adelaide",
            "(GMT+09:30) Darwin",
            "(GMT+10:00) Brisbane",
            "(GMT+10:00) Canberra, Melbourne, Sydney",
            "(GMT+10:00) Guam, Port Moresby",
            "(GMT+10:00) Hobart",
            "(GMT+10:00) Vladivostok",
            "(GMT+11:00) Magadan, Solomon Is., New Caledonia ",
            "(GMT+12:00) Aukland, Wellington ",
            "(GMT+12:00) Fiji, Kamchatka, Marshall Is.",
            "(GMT+13:00) Nubu'alofa" };
            #endregion


        }
        
        #endregion

        #region Methods
        public static Element GetElement(ElementId elementId)
        {
            return RevitDoc.GetElement(elementId);
        }
        public static Element GetElement(int elementId)
        {
            return GetElement(new ElementId(elementId));
        }
        #endregion

    }
}
