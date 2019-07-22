using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace LucidToolbar
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;

        }

        public Result OnStartup(UIControlledApplication application)
        {
            //create ribbon tab
            application.CreateRibbonTab("Lucid Tools");

            string path = Assembly.GetExecutingAssembly().Location;

            PushButtonData button = new PushButtonData("HydraulicTools", "PlacePipeElement", path, "LucidToolbar.PlacePipeElement");

            RibbonPanel panel = application.CreateRibbonPanel("Lucid Tools", "Hydraulic");

            //Add button image
            Uri imagepath = new Uri(@"C:\Users\Max.Sun\Desktop\Revit Folder\tools.png");
       
            BitmapImage image = new BitmapImage(imagepath);

            PushButton pushButton = panel.AddItem(button) as PushButton;
            pushButton.LargeImage = image;
            //S:\Bluesky\Project Files\RevitTools[Testing]\output - onlinepngtools.png

            return Result.Succeeded;

        }
    }
}
