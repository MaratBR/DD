namespace DeclarativeDiagram.DataModel
{
    public abstract class Numeric : Value
    {
        public override ValueType GetExprType(Context context)
            => ValueType.Numeric;

        public abstract double GetValue(Context context);
    }
}