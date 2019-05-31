using DeclarativeDiagram.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public sealed class DefinedFunction : Function
    {
        public Numeric Expression { get; private set; }

        public DefinedFunction(string name, Numeric expr, ArgumentsDefinition def)
        {
            Name = name;
            Expression = expr;
            Arguments = def;
        }

        public override double CalculateValue(Context context, FunctionArguments args)
        {
            Context fnContext = Context.GetChild(context);

            int index = 0;
            foreach (string argName in Arguments.Names)
            {
                fnContext[argName] = args[index++];
            }

            return Expression.GetValue(fnContext);
        }
    }
}
