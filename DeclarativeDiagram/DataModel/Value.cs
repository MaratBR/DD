using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public enum ValueType
    {
        Numeric,
        Function,
        Invalid
    }

    public abstract class Value
    {
        public abstract ValueType GetExprType(Context context);
    }
}
