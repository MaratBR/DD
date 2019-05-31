using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public class Variable : Numeric
    {
        public string Name { get; private set; }

        public Variable(string name)
        {
            Name = name;
        }

        public override ValueType GetExprType(Context context)
        {
            Value val = context.Get(Name);
            if (val == null)
                return ValueType.Invalid;
            return val.GetExprType(context);
        }

        public override double GetValue(Context context)
        {
            Value val = context.Get(Name);
            if (val == null)
                throw new VariableNotDefinedException(Name);
            if (val is Numeric n)
            {
                return n.GetValue(context);
            }
            throw new IllegalTypeException("not a number");
        }
    }
}
