using DeclarativeDiagram.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public abstract class Function : Value, IFunction
    {
        public string Name { get; protected set; }

        public override ValueType GetExprType(Context context)
            => ValueType.Function;

        public ArgumentsDefinition Arguments { get; protected set; }   
        public abstract double CalculateValue(Context context, FunctionArguments args);

        public string ToMathString()
        {
            return $"{Name}{Arguments}";
        }

        public override string ToString()
        {
            return $"{GetType().Name}({Name}{Arguments})";
        }
    }
}
