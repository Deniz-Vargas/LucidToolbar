﻿using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LucidToolbar
{
    class ExternalApplication : IExternalApplication
    {
        // class instance
        internal static ExternalApplication thisApp = null;
        // ModelessForm instance
        private ProjectSetUp.ViewTemplate.AllViewsForm m_ViewForm;
        private ModelessForm1 m_MyForm;
       
        public Result OnShutdown(UIControlledApplication application)
        {
            if (m_MyForm != null && m_MyForm.Visible)
            {
                m_MyForm.Close();
            }

            if (m_ViewForm != null && m_ViewForm.Visible)
            {
                m_ViewForm.Close();
            }
            return Result.Succeeded;

        }

        public Result OnStartup(UIControlledApplication application)
        {
            //create ribbon tabs
            application.CreateRibbonTab("Project Set-up");
            RibbonPanel LucidQAPanel = application.CreateRibbonPanel("Project Set-up", "Project Set-up");
            //RibbonPanel LucidQAPanel2 = application.CreateRibbonPanel("Project Setup", "Test Command");

            application.CreateRibbonTab("Hydraulic Tools");
            RibbonPanel LucidHydPanel = application.CreateRibbonPanel("Hydraulic Tools", "Hydraulic Tools");
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

            //PushButtonData ProjectInfo = 
            //    new PushButtonData("Project Information", "Project Info", path, "LucidToolbar.TestCommand");
            //ProjectSetUp.LargeImage = GetImage(Properties.Resources.ProjectInfo.GetHbitmap());

            PushButtonData ProjectSetUp =
                new PushButtonData("ProjectSetUp", "Project Set-up", path, "LucidToolbar.TestCommand");
            ProjectSetUp.LargeImage = GetImage(Properties.Resources.ProjectInfo.GetHbitmap());
            
            PushButtonData Reconcile =
                new PushButtonData("Reconcile Coordinate", "Reconcile Coordinates", path, "LucidToolbar.ProjectCoordinate");
            Reconcile.LargeImage = GetImage(Properties.Resources.Reconcile.GetHbitmap());

            PushButtonData CopyMonitor =
                new PushButtonData("Copy L&Gs", "Copy Levels & Grids", path, "LucidToolbar.CopyMonitor");
            CopyMonitor.LargeImage = GetImage(Properties.Resources.save_to_grid.GetHbitmap());

            PushButtonData AddFloorPlan =
                new PushButtonData("Add Floor Plan", "Add Floor Plans", path, "LucidToolbar.AddFloorPlan");
            AddFloorPlan.LargeImage = GetImage(Properties.Resources.floorplan.GetHbitmap());

            PushButtonData ArchCleanUp =
                new PushButtonData("Arch Cleanup", "Arch Clean Up", path, "LucidToolbar.ArchCleanUp");
            ArchCleanUp.LargeImage = GetImage(Properties.Resources.Cleanup.GetHbitmap());

            PushButtonData PlaceSpaceTag =
                new PushButtonData("Place Space Tag", "Place Space Tag", path, "LucidToolbar.CreateSpace");
            PlaceSpaceTag.LargeImage = GetImage(Properties.Resources.grid.GetHbitmap());

            //PushButtonData SetParameter =
            //    new PushButtonData("Set Parameter", "Set Parameter", path, "LucidToolbar.SetParameter");
            //SetParameter.LargeImage = GetImage(Properties.Resources.Set.GetHbitmap());

            PushButtonData AllViews =
            new PushButtonData("Set AllViews", "Apply Templates", path, "LucidToolbar.AllViews");
            AllViews.LargeImage = GetImage(Properties.Resources.CopyMonitor.GetHbitmap());

            RibbonItem ri1 = LucidHydPanel.AddItem(DomesticColdWater);
            RibbonItem ri2 = LucidHydPanel.AddItem(DomesticHotWater);
            RibbonItem ri3 = LucidHydPanel.AddItem(NaturalGasPipe);
            LucidHydPanel.AddSeparator();
            RibbonItem ri4 = LucidHydPanel.AddItem(AvoidObstruction);

            RibbonItem ri5 = LucidQAPanel.AddItem(ProjectSetUp);
            RibbonItem ri6 = LucidQAPanel.AddItem(Reconcile);
            RibbonItem ri7 = LucidQAPanel.AddItem(CopyMonitor);
            RibbonItem ri8 = LucidQAPanel.AddItem(AddFloorPlan);
            RibbonItem ri9 = LucidQAPanel.AddItem(ArchCleanUp);
            RibbonItem ri10 = LucidQAPanel.AddItem(PlaceSpaceTag);
            RibbonItem ri12 = LucidQAPanel.AddItem(AllViews);
            //RibbonItem ri11 = LucidQAPanel.AddItem(SetParameter);
            LucidQAPanel.AddSeparator();
            
            //LucidHydPanel.AddSeparator();
            //
            ///Setup document
            m_MyForm = null;   // no dialog needed yet; the command will bring it
            m_ViewForm = null; // no dialog needed yet; the command will bring it
            thisApp = this;    // static access to this application instance

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
        /// <summary>
        ///   This method creates and shows a modeless dialog, unless it already exists.
        /// </summary>
        /// <remarks>
        ///   The external command invokes this on the end-user's request
        /// </remarks>
        /// 
        public void ShowForm(UIApplication uiapp)
        {
            // If we do not have a dialog yet, create and show it
            if (m_MyForm == null || m_MyForm.IsDisposed)
            {
                // A new handler to handle request posting by the dialog
                RequestHandler handler = new RequestHandler();

                // External Event for the dialog to use (to post requests)
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible fore disposing them, eventually.
                //m_MyForm = new ModelessForm2(exEvent, handler);
                m_MyForm = new ModelessForm1(exEvent,handler);
                m_MyForm.Show();
            }
        }


        public void ShowViewForm(UIApplication uiapp)
        {
           // If we do not have a dialog yet, create and show it
            if (m_ViewForm == null || m_ViewForm.IsDisposed)
            {
                // A new handler to handle request posting by the dialog
                ViewerRequestHandler handler = new ViewerRequestHandler();

                // External Event for the dialog to use (to post requests)
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible fore disposing them, eventually.
                //m_MyForm = new ModelessForm2(exEvent, handler);
                m_ViewForm = new ProjectSetUp.ViewTemplate.AllViewsForm(exEvent, handler);
                m_ViewForm.Show();
            }
        }

        /// <summary>
        ///   Waking up the dialog from its waiting state.
        /// </summary>
        /// 
        public void WakeFormUp()
        {
            if (m_MyForm != null)
            {
                m_MyForm.WakeUp();
            }
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
                (uint)MVK_MAP_TYPE.VKEY_TO_SCANCODE);

            uint keyDownCode = (uint)
                               WH_KEYBOARD_LPARAM.KEYDOWN
                               | (scanCode << 16);

            uint keyUpCode = (uint)
                             WH_KEYBOARD_LPARAM.KEYUP
                             | (scanCode << 16);

            PostMessage(handle,
                (uint)KEYBOARD_MSG.WM_KEYDOWN,
                letter, keyDownCode);

            PostMessage(handle,
                (uint)KEYBOARD_MSG.WM_KEYUP,
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