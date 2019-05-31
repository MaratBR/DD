using DeclarativeDiagram.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public sealed class ProductOperation : BinaryOperation<Numeric>
    {
        public enum Type
        {
            Mod,
            DivDiv,
            Div,
            Mul
        }

        public Type ProductOperationType { get; private set; }

        public ProductOperation(Numeric n1, Numeric n2, Type type)
        {
            ProductOperationType = type;
            Left = n1;
            Right = n2;
        }

        public override double GetValue(Context context)
        {
            double vL = Left.GetValue(context), vR = Right.GetValue(context);
            switch (ProductOperationType)
            {
                case Type.Mul:
                    return vL * vR;
                case Type.DivDiv:
                    return Math.Floor(vL / vR);
                case Type.Div:
                    return vL / vR;
                case Type.Mod:
                    return vL % vR;
            }
            throw new NotImplementedException();
        }

        public static Type GetType(string str)
        {
            switch (str)
            {
                case "*":
                    return Type.Mul;
                case "/":
                    return Type.Div;
                case "//":
                    return Type.DivDiv;
                case "%":
                    return Type.Mod;
            }
            throw new SyntaxException("Unknown type of product operation");
        }
    }
}
