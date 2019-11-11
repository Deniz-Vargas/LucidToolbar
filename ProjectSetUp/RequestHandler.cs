//
// (C) Copyright 2003-2017 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE. AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Autodesk;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;

using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Creation;
using System.Linq;

using static LucidToolbar.ModelessForm1;

namespace LucidToolbar
{
    /// <summary>
    ///   A class with methods to execute requests made by the dialog user.
    /// </summary>
    /// 
    public class RequestHandler : IExternalEventHandler
    {
        // A trivial delegate, but handy
        private delegate void DoorOperation(FamilyInstance e);
         
        // The value of the latest request made by the modeless form 
        private Request m_request = new Request();
        public List<Workset> worksets = new List<Workset>();
        public string strworkset = null;
        /// <summary>
        /// A public property to access the current request value
        /// </summary>
        public Request Request
        {
            get { return m_request; }
        }

        /// <summary>
        ///   A method to identify this External Event Handler
        /// </summary>
        public String GetName()
        { 
            return "R2019 External Event Sample";
        }


        /// <summary>
        ///   The top method of the event handler.
        /// </summary>
        /// <remarks>
        ///   This is called by Revit after the corresponding
        ///   external event was raised (by the modeless form)
        ///   and Revit reached the time at which it could call
        ///   the event's handler (i.e. this object)
        /// </remarks>
        /// 
        public void Execute(UIApplication uiapp)
        {
            try
            {
                switch (Request.Take())
                {
                    case RequestId.None:
                        {
                            return;  // no request at this time -> we can leave immediately
                        }
                        ///use this one to test out opening up a document
                    case RequestId.Linkfile:
                        {
                            //ModifySelectedDoors(uiapp, "Delete doors", e => e.Document.Delete(e.Id));
                            LinkFile(uiapp);
                            break;
                        }
                    case RequestId.GetActiveWorkset:
                        {
                            GetWorkset(uiapp);//Get the current active workset and displays it;s name
                            break;
                        }
                    case RequestId.WorksetsInfo:
                        {
                            GetWorksetsInfo(uiapp);
                            break;
                        }
                    case RequestId.MakeLeft:
                        {
                            ModifySelectedDoors(uiapp, "Make door Left", MakeLeft);
                            break;
                        }
                    case RequestId.SetCurWorkset:
                        {
                            SetWorkset(uiapp);
                            break;
                        }
                    case RequestId.TurnOut:
                        {
                            ModifySelectedDoors(uiapp, "Place door Out", TurnOut);
                            break;
                        }
                    case RequestId.TurnIn:
                        {
                            ModifySelectedDoors(uiapp, "Place door In", TurnIn);
                            break;
                        }
                    case RequestId.Rotate:
                        {
                            ModifySelectedDoors(uiapp, "Rotate door", FlipHandAndFace);
                            break;
                        }
                    default:
                        {
                            // some kind of a warning here should
                            // notify us about an unexpected request 
                            break;
                        }
                }
            }
            finally
            {
                ExternalApplication.thisApp.WakeFormUp();
            }

            return;
        }
        //{

        //    OpenOptions options1 = new OpenOptions();
        //    options1.DetachFromCentralOption = DetachFromCentralOption.DetachAndPreserveWorksets;
        //    Document openedDoc = uiapp.ActiveUIDocument.Application.Application.OpenDocumentFile(modelPath, options1);
        //    return openedDoc;           

        //}


        /// <summary>
        ///   The main door-modification subroutine - called from every request 
        /// </summary>
        /// <remarks>
        ///   It searches the current selection for all doors
        ///   and if it finds any it applies the requested operation to them
        /// </remarks>
        /// <param name="uiapp">The Revit application object</param>
        /// <param name="text">Caption of the transaction for the operation.</param>
        /// <param name="operation">A delegate to perform the operation on an instance of a door.</param>
        /// 
        private void ModifySelectedDoors(UIApplication uiapp, String text, DoorOperation operation)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;

            // check if there is anything selected in the active document

            if ((uidoc != null) && (uidoc.Selection != null))
            {
                ICollection<ElementId> selElements = uidoc.Selection.GetElementIds();
                if (selElements.Count > 0)
                {
                    // Filter out all doors from the current selection

                    FilteredElementCollector collector = new FilteredElementCollector(uidoc.Document, selElements);
                    ICollection<Element> doorset = collector.OfCategory(BuiltInCategory.OST_Doors).ToElements();

                    if (doorset != null)
                    {
                        // Since we'll modify the document, we need a transaction
                        // It's best if a transaction is scoped by a 'using' block
                        using (Transaction trans = new Transaction(uidoc.Document))
                        {
                            // The name of the transaction was given as an argument

                            if (trans.Start(text) == TransactionStatus.Started)
                            {
                                // apply the requested operation to every door

                                foreach (FamilyInstance door in doorset)
                                {
                                    operation(door);
                                }

                                trans.Commit();
                            }
                        }
                    }
                }
            }
        }
        private void LinkFile(UIApplication uiapp)
        {
            using (Transaction trans = new Transaction(uiapp.ActiveUIDocument.Document))
            try  
            {
                trans.Start("Link file");
                ModelPath mp = ModelPathUtils.ConvertUserVisiblePathToModelPath(TestCommand.filePath);
                WorksetConfiguration worksetconfig = new WorksetConfiguration();
                RevitLinkOptions option = new RevitLinkOptions(false,worksetconfig);                
                //Create new revit link storing absolute path to a file
                LinkLoadResult result = RevitLinkType.Create(uiapp.ActiveUIDocument.Document, mp, option);
                RevitLinkInstance instance = RevitLinkInstance.Create(uiapp.ActiveUIDocument.Document, result.ElementId, ImportPlacement.Origin);
            }
            
            catch (System.Exception e)
            {
                trans.RollBack();
                TaskDialog.Show("Unhandled Error", e.ToString());
               
            }
            finally
            {
                trans.Commit();
            }
           
        }
        /// <summary>
        /// This function gets the current active workset
        /// </summary>
        /// <param name="uiapp"></param>
        public void GetWorkset(UIApplication uiapp)
        {

            using (Transaction trans = new Transaction(uiapp.ActiveUIDocument.Document))
            try
            {
                trans.Start("Link file");
                //Get the workset table from the document
                WorksetTable worksetTable = uiapp.ActiveUIDocument.Document.GetWorksetTable();
                //Get thee Id of the active workset
                WorksetId activeId = worksetTable.GetActiveWorksetId();
                // Find the workset with the Id
                Workset workset = worksetTable.GetWorkset(activeId);
                //strworkset = workset.Name.ToString();
                TaskDialog.Show("The current active workset is: ", workset.Name.ToString());
                //TaskDialog.Show("The current active workset is: ", strworkset);            
            }

            catch (System.Exception e)
            {
                trans.RollBack();
                TaskDialog.Show("Unhandled Error", e.ToString());

            }
            finally
            {
               // return strworkset;
                trans.Commit();
                
            }
            
        }

        private void SetWorkset(UIApplication uiapp)
        {

            using (Transaction trans = new Transaction(uiapp.ActiveUIDocument.Document))
                try
                {
                    trans.Start("Set Current Workset");
                    // Enumerating worksets in a document and getting basic information for each
                    FilteredWorksetCollector collector = new FilteredWorksetCollector(uiapp.ActiveUIDocument.Document);
                    // find all user worksets
                    collector.OfKind(WorksetKind.UserWorkset);
                    IList<Workset> worksets = collector.ToWorksets();

                    //set active worksetid 

                    //WorksetId worksetId = worksetTable.GetActiveWorksetId();
                    // Find the workset with the Id
                    //Workset workset = worksetTable.GetWorkset(worksetId);
                    foreach(Workset workset in worksets)
                    {
                        //check if there is a workset with the same name as selected in combobox
                        if (workset.Name == targetWorkset)
                            activeId = workset.Id;
                    }
                    //TaskDialog.Show("The current active workset is: ", workset.Name.ToString());
                    //Set the active workset to the targetworkset selected from the combobox
                    uiapp.ActiveUIDocument.Document.GetWorksetTable().SetActiveWorksetId(activeId);
                    //TaskDialog.Show("The current selected workset is: ", targetWorkset);
                }

                catch (System.Exception e)
                {
                    trans.RollBack();
                    TaskDialog.Show("Unhandled Error", e.ToString());

                }
                finally
                {
                    trans.Commit();
                }

        }

        public void GetWorksetsInfo(UIApplication uiapp)
        {
            String message = String.Empty;
            //using (Transaction trans = new Transaction(uiapp.ActiveUIDocument.Document))
            try
            {
                    
                // Enumerating worksets in a document and getting basic information for each
                FilteredWorksetCollector collector = new FilteredWorksetCollector(uiapp.ActiveUIDocument.Document);
                // find all user worksets
                collector.OfKind(WorksetKind.UserWorkset);
                IList<Workset> worksets = collector.ToWorksets();
                //int count = 3; // show info for 3 worksets only
                foreach (Workset workset in worksets)
                {
                    message += "Workset : " + workset.Name.ToString();
                    message += "\nUnique Id : " + workset.UniqueId;
                    
                    //message += "\nOwner : " + workset.Owner;
                    //    //message += "\nKind : " + workset.Kind;
                    //    //message += "\nIs default : " + workset.IsDefaultWorkset;
                    //    //message += "\nIs editable : " + workset.IsEditable;
                    //    //message += "\nIs open : " + workset.IsOpen;
                    //    //message += "\nIs visible by default : " + workset.IsVisibleByDefault;
                    TaskDialog.Show("GetWorksetsInfo", message);

                    //if (0 == --count)

                }
            }
            catch(System.Exception e)
            {
                //trans.RollBack();
                TaskDialog.Show("Unhandled Error", e.ToString());
            }
            finally
            {
                // trans.Commit();
            }
            //get information for each workset
            
        }
        private void FlipHandAndFace(FamilyInstance e)
        {
            e.flipFacing(); e.flipHand();
        }

        // Note: The door orientation [left/right] is according the common
        // conventions used by the building industry in the Czech Republic.
        // If the convention is different in your county (like in the U.S),
        // swap the code of the MakeRight and MakeLeft methods.

        private static void MakeLeft(FamilyInstance e)
        {
            if (e.FacingFlipped ^ e.HandFlipped) e.flipHand();
        }

        private void SetCurWorkset(UIApplication uiapp)
        {
            try
            {


            }
            catch (System.Exception e)
            {
                //trans.RollBack();
                TaskDialog.Show("Unhandled Error", e.ToString());
            }
            finally
            {
                // trans.Commit();
            }
        }

        // Note: The In|Out orientation depends on the position of the
        // wall the door is in; therefore it does not necessary indicates
        // the door is facing Inside, or Outside, respectively.
        // The presented implementation is good enough to demonstrate
        // how to flip a door, but the actual algorithm will likely
        // have to be changes in a read-world application.

        private void TurnIn(FamilyInstance e)
        {
            if (!e.FacingFlipped) e.flipFacing();
        }

        private void TurnOut(FamilyInstance e)
        {
            if (e.FacingFlipped) e.flipFacing();
        }

    }  // class

}  // namespace
