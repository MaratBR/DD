using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public sealed class ConstNumeric : Numeric
    {
        private double Value;

        ConstNumeric(double val)
        {
            Value = val;
        }

        public override double GetValue(Context context)
            => Value;

        public override string ToString() 
            => $"ConstNumeric({Value})";

        public static ConstNumeric Of(double val) => new ConstNumeric(val); 
    }
}
