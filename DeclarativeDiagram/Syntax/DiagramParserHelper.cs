using Antlr4.Runtime;
using DeclarativeDiagram.Syntax.ANTLR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public static class DiagramParserHelper
    {
        public static DiagramParser GetParser(TextReader r)
        {
            AntlrInputStream inputStream = new AntlrInputStream(r);
            DiagramLexer lexer = new DiagramLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            DiagramParser parser = new DiagramParser(commonTokenStream);
            return parser;
        }

        public static Code ParseCode(TextReader r)
        {
            var parser = GetParser(r);
            var visitor = new DiagramVisitor();
            return (Code)visitor.VisitCode(parser.code());
        }

        public static Code ParseCode(string text)
        {
            return ParseCode(new StringReader(text));
        }
    }
}
