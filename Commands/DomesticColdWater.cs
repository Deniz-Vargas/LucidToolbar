using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using LucidToolbar;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace LucidToolbar
{
    /// <summary>
        /// Create Domestic Cold Water
        /// </summary>
        [Transaction(TransactionMode.Manual)]
        public class DomesticColdWater : IExternalCommand
        {
            public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
            {
            UIApplication uiapp = commandData.Application;
            //Get UIDocument
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            //Get Document
            Document doc = uidoc.Document;

            //name of target pipe that we want to use:
            //string pipeTypeName = "LCE_H_PI_Copper - Soldered_BMA";

            //PipeType pipeType = GetFirstPipeTypeNamed(doc, pipeTypeName);
            //PipeType pipeType = ;
            //Pipe pipe = GetFirstPipeUsingType(doc, pipeType);

            //Get Level
            Level level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .Cast<Level>()
                .First(x => x.Name == "Ground Floor");

            //////Get Family Symbol
            //FilteredElementCollector collector = new FilteredElementCollector(doc);
            //collector.OfCategory(BuiltInCategory.OST_PipingSystem).Where(ps => ps.Name == "Domestic Cold Water");
            //string pipeTypeName = "LCE_H_PI_Copper - Soldered_BMA";
            var pipeTypes =
                new FilteredElementCollector(doc)
                    .OfClass(typeof(PipeType))
                    .OfType<PipeType>()
                    .Where(pt => pt.Name == "LCE_H_PI_Copper - Soldered_BMA");

            // get the first type from the collection
            var firstPipeType =
                pipeTypes.FirstOrDefault();

            if (firstPipeType == null)
            {
                message = "Could not found Pipe Type";
                return Result.Failed;
            }
            //PipeType pipeType = GetFirstPipeTypeNamed(doc, pipeTypeName);
            //// Create piping system
            // get the Domestic Cold water type
            var mepSystemTypes
                = new FilteredElementCollector(doc)
                    //.WhereElementIsNotElementType()                
                    .OfClass(typeof(PipingSystemType))
                    .OfType<PipingSystemType>()
                    .ToList();

            var domesticColdWaterSystemType =
                mepSystemTypes
                    //.FirstOrDefault(st => st.SystemClassification == MEPSystemClassification.DomesticColdWater);
                    .Find(st => st.Name == "Hydraulic - Domestic Cold Water");

            if (domesticColdWaterSystemType == null)
            {
                message = "Could not found Domestic Cold Water System Type";
                return Result.Failed;
            }

            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    trans.Start();
                    Pipe dmpp = Pipe.Create(doc, domesticColdWaterSystemType.Id, firstPipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(1, 0, 0));
                    //Pipe dummyPipe = GetFirstPipeUsingType(doc, firstPipeType);
                    ElementId eleId = dmpp.GetTypeId();
                    Element ele = doc.GetElement(eleId);
                    ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                    selectedIds.Add(dmpp.Id);

                    uidoc.Selection.SetElementIds(selectedIds);
                    Press.Keys("CS");
                    uidoc.Selection.SetElementIds(selectedIds);
                    Press.Keys("DE");
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
}
