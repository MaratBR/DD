using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{

    [Serializable]
    public class IllegalTypeException : Exception
    {
        public IllegalTypeException() { }
        public IllegalTypeException(string message) : base(message) { }
        public IllegalTypeException(string message, Exception inner) : base(message, inner) { }
        protected IllegalTypeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
