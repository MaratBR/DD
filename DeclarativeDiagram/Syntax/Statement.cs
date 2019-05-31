using DeclarativeDiagram.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public abstract class Statement
    {
        public abstract void Execute(Context context);
        public Context Execute()
        {
            var context = new Context();
            Execute(context);
            return context;
        }
    }
}
