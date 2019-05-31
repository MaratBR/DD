using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{

    [Serializable]
    public class VariableNotDefinedException : LogicalException
    {
        public VariableNotDefinedException() { }
        public VariableNotDefinedException(string message) : base(message) { }
        public VariableNotDefinedException(string message, Exception inner) : base(message, inner) { }
        protected VariableNotDefinedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
