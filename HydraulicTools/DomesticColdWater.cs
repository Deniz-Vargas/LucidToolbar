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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //// Extract all pipe system types [THIS IS FROM SAMPLE CODE]
            //var PipingSystemType
            //  = new FilteredElementCollector(doc)
            //    //.WhereElementIsNotElementType()                
            //    .OfClass(typeof(PipingSystemType))
            //    .OfType<PipingSystemType>()
            //    .ToList();

            //// get the Domestic hot water type
            //var NaturalGasSystemType =
            //    mepSystemTypes
            //        .FirstOrDefault(st => st.SystemClassification == MEPSystemClassification.DomesticHotWater);
            //[THIS IS FROM SAMPLE CODE]

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
            //// Create piping system
            //FilteredElementCollector sysCollector = new FilteredElementCollector(doc);
            //sysCollector.OfClass(typeof(PipingSystemType)).OfType<PipingSystemType>().Where(ps => ps.Name == "Hydraulic - Domestic Hot Water");
            ////sysCollector.OfCategory(BuiltInCategory.OST_PipingSystem).Where(ps => ps.Name == "Domestic Hot Water");
            //ElementId pipeSysTypeId = sysCollector.FirstElementId();
            var mepSystemTypes
                = new FilteredElementCollector(doc)
                    //.WhereElementIsNotElementType()                
                    .OfClass(typeof(PipingSystemType))
                    .OfType<PipingSystemType>()
                    .ToList();

            // get the Domestic hot water type
            var NaturalGasSystemType =
                mepSystemTypes
                    .Find(st => st.Name == "Hydraulic - Domestic Cold Water");

            if (NaturalGasSystemType == null)
            {
                message = "Could not found Domestic Cold Water System Type";
                return Result.Failed;
            }

            // looking for the PipeType



            var level = uidoc.ActiveView.GenLevel;

            if (level == null)
            {
                message = "Wrong Active View";
                return Result.Failed;
            }


            var startPoint = XYZ.Zero;

            var endPoint = new XYZ(100, 0, 0);

            using (var t = new Transaction(doc, "Create pipe using Pipe.Create"))
            {
                t.Start();
                Pipe dmpp = Pipe.Create(doc, NaturalGasSystemType.Id, firstPipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(1, 0, 0));
                //Pipe dummyPipe = GetFirstPipeUsingType(doc, firstPipeType);
                ElementId eleId = dmpp.GetTypeId();
                Element ele = doc.GetElement(eleId);
                ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                selectedIds.Add(dmpp.Id);

                uidoc.Selection.SetElementIds(selectedIds);
                Press.Keys("CS");
                uidoc.Selection.SetElementIds(selectedIds);
                Press.Keys("DE");
                t.Commit();
            }

            return Result.Succeeded;
        }

    }
}
