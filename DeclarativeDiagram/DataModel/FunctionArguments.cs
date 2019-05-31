using System;
using System.Collections.Generic;

namespace DeclarativeDiagram.DataModel
{
    public class FunctionArguments
    {
        public IList<Value> Arguments = new List<Value>();

        public Value this[int index]
        {
            get => Arguments[index];
            set => Arguments[index] = value;
        }

        public void RequireNArguments(int count)
        {
            if (Arguments.Count != count)
                throw new IllegalArgumentsException(count, Arguments.Count);
        }
    }
}