using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Controls;
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
            DomesticColdWater.LargeImage = GetImage(Properties.Resources.dcw.GetHbitmap());

            PushButtonData DomesticHotWater = new PushButtonData("DomesticHotWater", "Domestic Hot Water", path,
                "LucidToolbar.DomesticHotWater");
            DomesticHotWater.LargeImage = GetImage(Properties.Resources.dhw.GetHbitmap());

            PushButtonData NaturalGasPipe =
                new PushButtonData("NaturalGasPipe", "Natural Gas Pipe", path, "LucidToolbar.NaturalGasPipe");
            NaturalGasPipe.LargeImage = GetImage(Properties.Resources.NaturalGas.GetHbitmap());

            PushButtonData AvoidObstruction =
                new PushButtonData("AvoidObstruction", "Avoid Obstruction", path, "LucidToolbar.AvoidObstruction");
            AvoidObstruction.LargeImage = GetImage(Properties.Resources.AvoidObstruction.GetHbitmap());

            RibbonItem ri1 = LucidHydPanelDebug.AddItem(DomesticColdWater);
            RibbonItem ri2 = LucidHydPanelDebug.AddItem(DomesticHotWater);
            RibbonItem ri3 = LucidHydPanelDebug.AddItem(NaturalGasPipe);
            LucidHydPanelDebug.AddSeparator();
            RibbonItem ri4 = LucidHydPanelDebug.AddItem(AvoidObstruction);
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
}