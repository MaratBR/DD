using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.DataModel
{
    public class Context
    {
        private Context Inner;
        private Dictionary<string, Value> Values = new Dictionary<string, Value>();

        public Context()
        {
        }

        public Value this[string name]
        {
            get
            {
                var val = GetValue(name);

                if (val != null)
                    return val;

                if (Inner != null)
                    return Inner[name];
                throw new KeyNotFoundException(name);
            }
            set
            {
                Values[name] = value;
            }
        }

        public Context(Context context)
        {
            Inner = context;
        }

        public Value GetValue(string key, Value fallback = null)
        {
            if (Values.ContainsKey(key))
                return Values[key];
            return fallback;
        }

        public bool HasInner => Inner != null;
        public bool IsEmptyOuter => Values.Count == 0;
        public bool IsEmpty => IsEmptyOuter && (Inner == null || Inner.IsEmpty);
        

        public Context GetChild()
        {
            return new Context(this);
        }

        public Context GetChildIfEmpty()
        {
            return IsEmptyOuter ? this : GetChild();
        }

        public Value Get(string name)
        {
            if (Values.ContainsKey(name))
            {
                return Values[name];
            }

            if (Inner != null)
                return Inner.Get(name);
            return null;
        }

        public T GetAs<T>(string name) where T : Value
        {
            return GetValue(name) as T;
        }

        public static Context GetChild(Context context)
        {
            return context == null ? new Context() : context.GetChild();
        }
    }
}
