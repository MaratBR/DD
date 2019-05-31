using DeclarativeDiagram.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public sealed class AddOperation : BinaryOperation<Numeric>
    {
        public enum Type : byte
        {
            Sum,
            Subtract
        }

        public Type AddOperationType { get; private set; }

        public AddOperation(Numeric n1, Numeric n2, Type type)
        {
            AddOperationType = type;
            Left = n1;
            Right = n2;
        }

        public override double GetValue(Context context)
        {
            double vL = Left.GetValue(context), vR = Right.GetValue(context);
            switch (AddOperationType)
            {
                case Type.Subtract:
                    return vL - vR;
                case Type.Sum:
                    return vL + vR;
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"+({Left}, {Right})";
        }
    }
}
