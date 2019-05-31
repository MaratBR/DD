using DeclarativeDiagram.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public abstract class BinaryOperation<T> : Numeric where T : Numeric 
    {
        public T Left { get; protected set; }
        public T Right { get; protected set; }
    }
}
