using System;
using System.Linq;

namespace DeclarativeDiagram.Syntax.ANTLR
{
    partial class NumbersParser
    {
        public static double ParseOctNumber(string octalNumber) => ParserNNumber(octalNumber, 8);

        public static double ParseHexNumber(string hexNumber) => ParserNNumber(hexNumber, 16);

        public static double ParseBinNumber(string binNumber) => ParserNNumber(binNumber, 2);

        public static double ParseDecNumber(string number)
        {
            double x = 0;
            bool hasE = false;
            int power = 0;
            if (number.Contains('e') || number.Contains('E'))
            {
                var parts = number.ToLower().Split('e');
                power = Convert.ToInt32(parts[1]);
                hasE = true;
                number = parts[0];
            }

            if (number.Contains('.'))
            {
                var parts = number.Split('.');
                x += Convert.ToInt32(parts[0]);
                x += Convert.ToInt32(parts[1]) / Math.Pow(10, parts[1].Length);
            }
            else
            {
                x = Convert.ToInt32(number);
            }

            if (hasE)
            {
                x *= Math.Pow(10, power);
            }

            return x;
        }

        private static double ParserNNumber(string number, int n)
        {
            int x = 0;
            for (int i = 0; i < number.Length - 2; i++)
            {
                x *= n;
                x += number.ElementAt(i + 2) - '0';
            }
            return x;
        }
    }
}
