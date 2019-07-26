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


namespace LucidToolbar
{
    [TransactionAttribute(TransactionMode.Manual)]

    public class PlacePipeElement : IExternalCommand
    {
        PipeType GetFirstPipeTypeNamed(Document doc, string name )
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

            //Get pipetype
            //FilteredElementCollector collector1 = new FilteredElementCollector(doc);

            //PipeType pipeType = collector1.OfClass(typeof(PipeType))
            //.WhereElementIsElementType()
            //.Cast<PipeType>()
            //.First(x => x.Name == "ABS - Solvent Welded_BMA");
            //

            string pipeTypeName = "LCE_H_PI_Carbon Steel - Threaded & Butt Welded_BMA";

            // name of target pipe type that we want to use:
            PipeType pipeType = GetFirstPipeTypeNamed(doc, pipeTypeName);

            Pipe pipe = GetFirstPipeUsingType(doc, pipeType);

            // select the pipe in the UI
            //Show Form1 
            System.Windows.Forms.Application.Run(new Form1());



            //doc.Delete(selectedIds);

            //if (0 == uidoc.Selection.SetElementIds(ElementId))
            //{
            //    // no pipe with the correct pipe type found

            //    FilteredElementCollector collectorEle
            //      = new FilteredElementCollector(doc);

            //    Level ll = collectorEle
            //      .OfClass(typeof(Level))
            //      .FirstElement() as Level;

            //    // place a new pipe with the 
            //    // correct pipe type in the project

            //    Line geomLine = app.Create.NewLineBound(
            //      XYZ.Zero, new XYZ(2, 0, 0));

            //    Transaction t = new Transaction(
            //      doc, "Create dummy pipe");

            //    t.Start();

            //    Pipe pp = Pipe.Create(doc, pipeSysTypeId, pipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(100, 0, 0));

            //    t.Commit();

            //    // Select the new pipe in the project

            //    uidoc.Selection.Elements.Add(pp);

            //    // Start command create similar. In the 
            //    // property menu, our pipe type is set current

            //    Press.Keys("CS");

            //    // select the new pipe in the project, 
            //    // so we can delete it

            //    uidoc.Selection.Elements.Add(pp);

            //    // erase the selected pipe (remark: 
            //    // doc.delete(nw) may not be used, 
            //    // this command will undo)

            //    Press.Keys("DE");

            //    // start up pipe command

            //    Press.Keys("WA");
            //}
            //else
            //{
            //    // the correct pipe is already selected:

            //    Press.Keys("CS"); // start "create similar"
            //}
            //return Result.Succeeded;


            //Try Catch Condition
            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    if (null != pipe) //If there is Existing pipe matched the target pipeType
                    {
                        //Form1.ActiveForm.Activate();
                        ElementId eleId = pipe.GetTypeId();
                        Element ele = doc.GetElement(eleId);
                        ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                        selectedIds.Add(ele.Id);

                        trans.Start();
                        uidoc.Selection.SetElementIds(selectedIds);
                       
                        ExternalApplication.Press.Keys("CS");
                        trans.Commit();
                    }
                    else
                    {
                        //FilteredElementCollector collector1 = new FilteredElementCollector(doc);

                        //PipeType dummyPipeType = collector1.OfClass(typeof(PipeType))
                        //.WhereElementIsElementType()
                        //.Cast<PipeType>()
                        //.First(x => x.Name == "ABS - Solvent Welded_BMA");
                        ////Create dummy Pipe 

                        trans.Start();
                        



                        Pipe dmpp = Pipe.Create(doc, pipeSysTypeId, pipeType.Id, level.Id, new XYZ(0, 0, 0), new XYZ(100, 0, 0));
                        Pipe dummyPipe = GetFirstPipeUsingType(doc, pipeType);
                        ElementId eleId = dummyPipe.GetTypeId();
                        Element ele = doc.GetElement(eleId);
                        ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                        selectedIds.Add(dmpp.Id);
                        trans.Commit();

                        uidoc.Selection.SetElementIds(selectedIds);
                        ExternalApplication.Press.Keys("DE");
                        ExternalApplication.Press.Keys("PI");
                    }
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
                //}
            }
        }
    }
}
