using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using DeclarativeDiagram.Syntax;
using DeclarativeDiagram.Syntax.ANTLR;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Code code = null;
                try
                {
                    code = DiagramParserHelper.ParseCode(File.ReadAllText("code.dd"));
                }
                catch(Exception exc)
                {
                    Console.Error.WriteLine(exc.ToString());
                    Thread.Sleep(3000);
                    Console.Clear();
                    continue;
                }

                Console.WriteLine(code.ToString());

                Thread.Sleep(3000);
                Console.Clear();
            }
        }

        static string GetCode()
        {
            StringBuilder builder = new StringBuilder();
            Console.Write("\n>>> ");
            int emptyLines = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    emptyLines++;
                    if (emptyLines == 2)
                    {
                        break;
                    }
                }
                else
                {
                    emptyLines = 0;
                }
                builder.AppendLine(line);
                Console.Write("-->");
            }

            return builder.ToString();
        }
    }
}
