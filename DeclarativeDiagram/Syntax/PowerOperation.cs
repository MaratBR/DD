using DeclarativeDiagram.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public class PowerOperation : BinaryOperation<Numeric>
    {
        public PowerOperation(Numeric n, Numeric power)
        {
            Left = n;
            Right = power;
        }

        public override double GetValue(Context context)
        {
            return Math.Pow(Left.GetValue(context), Right.GetValue(context));
        }
    }
}
