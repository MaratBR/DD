using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{

    [Serializable]
    public class LogicalException : BaseException
    {
        public LogicalException() { }
        public LogicalException(string message) : base(message) { }
        public LogicalException(string message, Exception inner) : base(message, inner) { }
        protected LogicalException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
