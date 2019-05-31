using DeclarativeDiagram.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public sealed class DefineStatement : Statement
    {
        public string Name { get; private set; }
        public Numeric Expression { get; private set; }
        public ArgumentsDefinition Arguments { get; private set; }
        public bool IsFunction => Arguments != null;

        public DefineStatement(string name, Numeric expr, ArgumentsDefinition arguments)
        {
            Arguments = arguments;
            Name = name;
            Expression = expr;
        }

        public override void Execute(Context context)
        {
            context[Name] = new DefinedFunction(Expression, Arguments);
        }

        public override string ToString()
        {
            string argsStr = IsFunction ? $"({string.Join(", ", Arguments.Names)})" : string.Empty;
            return $"{GetType().FullName} = {Expression})";
        }
    }
}
