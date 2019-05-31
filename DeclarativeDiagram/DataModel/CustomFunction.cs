using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public delegate double NumericFunctionDelegate(Context context, FunctionArguments args);

    public class CustomFunction : Function
    {
        public NumericFunctionDelegate Inner { get; private set; }

        public CustomFunction(NumericFunctionDelegate numericFunction)
        {
            Inner = numericFunction;
        }

        public override double CalculateValue(Context context, FunctionArguments args)
        {
            return Inner(context, args);
        }
    }
}
