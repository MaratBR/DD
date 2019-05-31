using DeclarativeDiagram.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public interface IFunction
    {
        string Name { get; }
        ArgumentsDefinition Arguments { get; }
        double CalculateValue(Context context, FunctionArguments args);
    }
}
