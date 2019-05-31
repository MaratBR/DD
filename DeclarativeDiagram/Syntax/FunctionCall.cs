using DeclarativeDiagram.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public abstract class FunctionCall : Numeric
    {
        public abstract IFunction GetFunction(Context context);
        public FunctionArguments Args { get; private set; }

        public FunctionCall(FunctionArguments args)
        {
            Args = args;
        }

        public override double GetValue(Context context)
        {
            return GetFunction(context).CalculateValue(context, Args);
        }
    }
}
