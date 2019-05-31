using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarativeDiagram.Syntax
{
    public sealed class Comment
    {
        public Comment(string value) { Content = value; }
        public string Content { get; private set; }
        public bool IsMultiline => Content.Contains('\n');

        public override string ToString()
        {
            return $"Comment({(IsMultiline ? "multiline" : "one line")})";
        }
    }
}
