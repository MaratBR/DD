using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{

    [Serializable]
    public class IllegalArgumentsException : LogicalException
    {
        const string MESSAGE = "Illegal count of arguments, expected {0}, got {1}";

        public IllegalArgumentsException(int expected, int got) : base(string.Format(MESSAGE, expected, got)) { }
        public IllegalArgumentsException(int expected, int got, Exception inner) : base(string.Format(MESSAGE, expected, got), inner) { }
        protected IllegalArgumentsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
