using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public class ArgumentsDefinition
    {
        public List<string> Names { get; private set; }

        public ArgumentsDefinition(List<string> names)
        {
            Names = names;
        }

        public override string ToString()
        {
            return "(" + string.Join(", ", Names) + ")";
        }
    }
}
