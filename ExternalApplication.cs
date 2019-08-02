using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Runtime.InteropServices;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Events;
using Class;

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

            RibbonPanel LucidHydPanelDebug = application.CreateRibbonPanel("Lucid Tools", "Hydraulic Tools");
            string path = Assembly.GetExecutingAssembly().Location;

            //#region DockableWindow
            PushButtonData DomesticColdWater = new PushButtonData("DomesticColdWater", "Domestic Cold Water", path,
                "LucidToolbar.DomesticColdWater");
            DomesticColdWater.LargeImage = GetImage(Resources.dcw.GetHbitmap());

            PushButtonData DomesticHotWater = new PushButtonData("DomesticHotWater", "Domestic Hot Water", path,
                "LucidToolbar.DomesticHotWater");
            DomesticHotWater.LargeImage = GetImage(Resources.dhw.GetHbitmap());

            PushButtonData SewagePipe =
                new PushButtonData("SewagePipe", "Sewage Pipe", path, "LucidToolbar.SewagePipe");
            SewagePipe.LargeImage = GetImage(Resources.Sewage.GetHbitmap());

            RibbonItem ri1 = LucidHydPanelDebug.AddItem(DomesticColdWater);
            RibbonItem ri2 = LucidHydPanelDebug.AddItem(DomesticHotWater);
            RibbonItem ri3 = LucidHydPanelDebug.AddItem(SewagePipe);
            ///Setup document



            return Result.Succeeded;

        }

        private System.Windows.Media.Imaging.BitmapSource GetImage(IntPtr bm)
        {
            System.Windows.Media.Imaging.BitmapSource bmSource =
                System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bm,
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return bmSource;
        }
    }


    public class Press
    {
        [DllImport("USER32.DLL")]
        public static extern bool PostMessage(
            IntPtr hWnd, uint msg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(
            uint uCode, uint uMapType);

        enum WH_KEYBOARD_LPARAM : uint
        {
            KEYDOWN = 0x00000001,
            KEYUP = 0xC0000001
        }

        enum KEYBOARD_MSG : uint
        {
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101
        }

        enum MVK_MAP_TYPE : uint
        {
            VKEY_TO_SCANCODE = 0,
            SCANCODE_TO_VKEY = 1,
            VKEY_TO_CHAR = 2,
            SCANCODE_TO_LR_VKEY = 3
        }

        /// <summary>
        /// Post one single keystroke.
        /// </summary>

        static void OneKey(IntPtr handle, char letter)
        {
            uint scanCode = MapVirtualKey(letter,
                (uint) MVK_MAP_TYPE.VKEY_TO_SCANCODE);

            uint keyDownCode = (uint)
                               WH_KEYBOARD_LPARAM.KEYDOWN
                               | (scanCode << 16);

            uint keyUpCode = (uint)
                             WH_KEYBOARD_LPARAM.KEYUP
                             | (scanCode << 16);

            PostMessage(handle,
                (uint) KEYBOARD_MSG.WM_KEYDOWN,
                letter, keyDownCode);

            PostMessage(handle,
                (uint) KEYBOARD_MSG.WM_KEYUP,
                letter, keyUpCode);
        }

        /// <summary>
        /// Post a sequence of keystrokes.
        /// </summary>
        public static void Keys(string command)
        {
            IntPtr revitHandle = System.Diagnostics.Process
                .GetCurrentProcess().MainWindowHandle;

            foreach (char letter in command)
            {
                OneKey(revitHandle, letter);
            }
        }

    }

    /// <summary>
    /// Create Domestic Cold Water
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class DomesticColdWater : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;

            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //Get Document
            Document doc = uidoc.Document;

            //Get Level
            Level level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .Cast<Level>()
                .First(x => x.Name == "Ground Floor");

            //Get Family Symbol
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_PipingSystem).Where(ps => ps.Name == "Domestic Cold Water");

            // Create piping system
            FilteredElementCollector sysCollector = new FilteredElementCollector(doc);
            sysCollector.OfClass(typeof(PipingSystemType));
            ElementId pipeSysTypeId = sysCollector.FirstElementId();

            string pipeTypeName = "LCE_H_PI_Carbon Steel - Threaded & Butt Welded_BMA";

            PipeType pipeType = GetFirstPipeTypeNamed(doc, pipeTypeName);

            Pipe pipe = GetFirstPipeUsingType(doc, pipeType);

            // name of target pipe type that we want to use:
            PipeType GetFirstPipeTypeNamed(Document doc, string name)
            {
                // built-in parameter storing this 
                // pipe type's name:

                BuiltInParameter bip
                    = BuiltInParameter.SYMBOL_NAME_PARAM;

                ParameterValueProvider provider
                    = new ParameterValueProvider(
                        new ElementId(bip));

                FilterStringRuleEvaluator evaluator
                    = new FilterStringEquals();

                FilterRule rule = new FilterStringRule(
                    provider, evaluator, name, false);

                ElementParameterFilter filter
                    = new ElementParameterFilter(rule);

                FilteredElementCollector collector
                    = new FilteredElementCollector(doc)
                        .OfClass(typeof(PipeType))
                        .WherePasses(filter);

                return collector.FirstElement() as PipeType;
            }

            static Pipe GetFirstPipeUsingType(Document doc, PipeType pipeType)
            {
                // built-in parameter storing this 
                // pipe's pipe type element id:

                BuiltInParameter bip
                    = BuiltInParameter.ELEM_TYPE_PARAM;

                ParameterValueProvider provider
                    = new ParameterValueProvider(
                        new ElementId(bip));

                FilterNumericRuleEvaluator evaluator
                    = new FilterNumericEquals();

                FilterRule rule = new FilterElementIdRule(
                    provider, evaluator, pipeType.Id);

                ElementParameterFilter filter
                    = new ElementParameterFilter(rule);

                FilteredElementCollector collector
                    = new FilteredElementCollector(doc)
                        .OfClass(typeof(Pipe))
                        .WherePasses(filter);

                return collector.FirstElement() as Pipe;

            }
            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    trans.Start();
                    Pipe dmpp = Pipe.Create(doc, pipeSysTypeId, pipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(1, 0, 0));
                    Pipe dummyPipe = GetFirstPipeUsingType(doc, pipeType);
                    ElementId eleId = dummyPipe.GetTypeId();
                    Element ele = doc.GetElement(eleId);
                    ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                    selectedIds.Add(dmpp.Id);
                    

                    uidoc.Selection.SetElementIds(selectedIds);
                    Press.Keys("DE");
                    Press.Keys("PI");
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

    }

    /// <summary>
    /// Create Domestic Hot Water pipe
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class DomesticHotWater : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;

            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //Get Document
            Document doc = uidoc.Document;

            //Get Level
            Level level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .Cast<Level>()
                .First(x => x.Name == "Ground Floor");

            //Get Family Symbol
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_PipingSystem).Where(ps => ps.Name == "Domestic Cold Water");

            // Create piping system
            FilteredElementCollector sysCollector = new FilteredElementCollector(doc);
            sysCollector.OfClass(typeof(PipingSystemType));
            ElementId pipeSysTypeId = sysCollector.FirstElementId();

            string pipeTypeName = "LCE_H_PI_Carbon Steel - Threaded & Butt Welded_BMA";

            PipeType pipeType = GetFirstPipeTypeNamed(doc, pipeTypeName);

            Pipe pipe = GetFirstPipeUsingType(doc, pipeType);

            // name of target pipe type that we want to use:
            PipeType GetFirstPipeTypeNamed(Document doc, string name)
            {
                // built-in parameter storing this 
                // pipe type's name:

                BuiltInParameter bip
                    = BuiltInParameter.SYMBOL_NAME_PARAM;

                ParameterValueProvider provider
                    = new ParameterValueProvider(
                        new ElementId(bip));

                FilterStringRuleEvaluator evaluator
                    = new FilterStringEquals();

                FilterRule rule = new FilterStringRule(
                    provider, evaluator, name, false);

                ElementParameterFilter filter
                    = new ElementParameterFilter(rule);

                FilteredElementCollector collector
                    = new FilteredElementCollector(doc)
                        .OfClass(typeof(PipeType))
                        .WherePasses(filter);

                return collector.FirstElement() as PipeType;
            }

            static Pipe GetFirstPipeUsingType(Document doc, PipeType pipeType)
            {
                // built-in parameter storing this 
                // pipe's pipe type element id:

                BuiltInParameter bip
                    = BuiltInParameter.ELEM_TYPE_PARAM;

                ParameterValueProvider provider
                    = new ParameterValueProvider(
                        new ElementId(bip));

                FilterNumericRuleEvaluator evaluator
                    = new FilterNumericEquals();

                FilterRule rule = new FilterElementIdRule(
                    provider, evaluator, pipeType.Id);

                ElementParameterFilter filter
                    = new ElementParameterFilter(rule);

                FilteredElementCollector collector
                    = new FilteredElementCollector(doc)
                        .OfClass(typeof(Pipe))
                        .WherePasses(filter);

                return collector.FirstElement() as Pipe;

            }
            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    trans.Start();
                    Pipe dmpp = Pipe.Create(doc, pipeSysTypeId, pipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(1, 0, 0));
                    Pipe dummyPipe = GetFirstPipeUsingType(doc, pipeType);
                    ElementId eleId = dummyPipe.GetTypeId();
                    Element ele = doc.GetElement(eleId);
                    ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                    selectedIds.Add(dmpp.Id);


                    uidoc.Selection.SetElementIds(selectedIds);
                    Press.Keys("DE");
                    Press.Keys("PI");
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
    }

    /// <summary>
    /// Create Sewage Pipe
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class SewagePipe : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            return Result.Succeeded;
        }

    }
}