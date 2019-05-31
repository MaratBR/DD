using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeclarativeDiagram.DataModel;

namespace DeclarativeDiagram.Syntax
{
    public sealed class NamedFunctionCall : FunctionCall
    {
        public string Name { get; private set; }

        public NamedFunctionCall(string name, FunctionArguments args) : base(args)
        {
            Name = name;
        }

        public override IFunction GetFunction(Context context)
        {
            return (IFunction)context[Name];
        }
    }
}
