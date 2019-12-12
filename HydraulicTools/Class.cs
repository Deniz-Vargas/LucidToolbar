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


namespace Class
{
    [TransactionAttribute(TransactionMode.Manual)]

    public class Class : IExternalCommand
    {
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


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            throw new NotImplementedException();
        }
    }




}
