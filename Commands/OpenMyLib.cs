﻿/*
 * Created by SharpDevelop.
 * User: gorina_admin
 * Date: 9/30/2016
 * Time: 2:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * 
 * rebuilt without errors for 2019.1 on 8/15/2018
 * 
 * 
 * 
 * 
 * 
 */
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
    [Regeneration(RegenerationOption.Manual)]
    public class OpenMyLib : IExternalCommand
    {
        private const string Path = @"S:\Staff Folders\Max Sun\NewProjectSetUp\2017 (Current)\LCE00000-General.rvt";

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //opens a document
            commandData.Application.Application.OpenDocumentFile(Path);

            //opens a document in the editor
            //commandData.Application.OpenAndActivateDocument(Path);

            return Result.Succeeded;
        }
    }


}