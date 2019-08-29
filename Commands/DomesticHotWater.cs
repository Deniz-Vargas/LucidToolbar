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
    /// Create Domestic Hot Water pipe
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class DomesticHotWater : IExternalCommand
    {
        static PipeType GetFirstPipeTypeNamed(Document doc, string name)
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
            //collector.OfCategory(BuiltInCategory.OST_PipingSystem).Where(ps => ps.Name == "Domestic Hot Water");
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
            //FilteredElementCollector sysCollector = new FilteredElementCollector(doc);
            //sysCollector.OfClass(typeof(PipingSystemType)).Where(ps => ps.Name == "Hydraulic - Domestic Hot Water");
            ////sysCollector.OfCategory(BuiltInCategory.OST_PipingSystem).Where(ps => ps.Name == "Domestic Hot Water");
            //ElementId pipeSysTypeId = sysCollector.FirstElementId();


            var mepSystemTypes
                = new FilteredElementCollector(doc)
                    //.WhereElementIsNotElementType()                
                    .OfClass(typeof(PipingSystemType))
                    .OfCategory(BuiltInCategory.OST_PipingSystem)
                    ///.OfType<PipingSystemType>()
                    .Where(ps => ps.Name == "Hydraulic - Domestic Hot Water")
                    .ToList();
            var domesticHotWaterSystemType =
                mepSystemTypes
                    .FirstOrDefault();

            //if (domesticHotWaterSystemType == null)
            //{
            //    message = "Could not found Domestic Hot Water System Type";
            //    return Result.Failed;
            //}


            //Pipe pipe = GetFirstPipeUsingType(doc, pipeType);

            // name of target pipe type that we want to use:

            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    trans.Start();
                    Pipe dmpp = Pipe.Create(doc, domesticHotWaterSystemType.Id, firstPipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(1, 0, 0));
                    Pipe dummyPipe = GetFirstPipeUsingType(doc, firstPipeType);
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
}
