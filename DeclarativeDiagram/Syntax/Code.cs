using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeclarativeDiagram.DataModel;

namespace DeclarativeDiagram.Syntax
{
    public class Code : Statement
    {
        public List<Statement> Statements { get; private set; }
        public Context GlobalContext { get; private set; }

        public Code(List<Statement> statements)
        {
            Statements = statements;
            GlobalContext = new Context();
        }

        public override void Execute(Context context)
        {
            foreach (var stmt in Statements)
            {
                stmt.Execute(context);
            }
        }

        public new Context Execute()
        {
            Execute(GlobalContext);
            return GlobalContext;
        }

        public override string ToString()
        {
            var str = $"{GetType().FullName}" + "{\n\t";

            str += string.Join("\n\t", Statements.Select(x => x.ToString())) + "\n}";

            return str;
        }
    }
}
