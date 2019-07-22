using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;


namespace LucidToolbar
{
    [TransactionAttribute(TransactionMode.Manual)]

    public class PlacePipeElement : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
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

            //Get pipetype
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);

            PipeType pipeType = collector1.OfClass(typeof(PipeType))
            .WhereElementIsElementType()
            .Cast<PipeType>()
            .First(x => x.Name == "ABS - Solvent Welded_BMA");

            //Try Catch Condition
            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    if (null != pipeType)
                    {
                        trans.Start();
                        //Create Pipe 
                        Pipe.Create(doc, pipeSysTypeId, pipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(100, 0, 0));
                        trans.Commit();
                    }
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
