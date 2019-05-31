using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DeclarativeDiagram.DataModel;

namespace DeclarativeDiagram.Syntax.ANTLR
{
    public class DiagramVisitor : DiagramBaseVisitor<object>
    {
        public override object VisitCode([NotNull] DiagramParser.CodeContext context)
        {
            var list = new List<Statement>(context.stmt().Select(x => (Statement)VisitStmt(x)));
            return new Code(list);
        }

        public override object VisitExpression([NotNull] DiagramParser.ExpressionContext context)
        {
            var identifier = context.IDENTIFIER();

            if (identifier != null)
            {
                return new Variable(identifier.GetText());
            }

            var compoundExprContext = context.compoundExpr();

            if (compoundExprContext != null)
            {
                return VisitCompoundExpr(compoundExprContext);
            }

            return VisitNumber(context.number());
        }

        public override object VisitStmt([NotNull] DiagramParser.StmtContext context)
        {
            var defineCtx = context.define();

            if (defineCtx != null)
                return VisitDefine(defineCtx);

            throw new IllegalTypeException("Failed to visit statement");
        }

        public override object VisitFunctionArgsDefinition([NotNull] DiagramParser.FunctionArgsDefinitionContext context)
        {
            return new ArgumentsDefinition(
                new List<string>(
                    context.IDENTIFIER().Select(x => x.GetText())));
        }

        public override object VisitDefine([NotNull] DiagramParser.DefineContext context)
        {
            var name = context.IDENTIFIER().GetText();
            var argsCtx = context.functionArgsDefinition();
            return new DefineStatement(
                context.IDENTIFIER().GetText(), 
                (Numeric)VisitCompoundExpr(context.compoundExpr()),
                (ArgumentsDefinition)(argsCtx == null ? null : VisitFunctionArgsDefinition(argsCtx))
                );
        }

        public override object VisitCompoundExpr([NotNull] DiagramParser.CompoundExprContext context)
        {
            {
                var expr = context.expression();

                if (expr != null) return VisitExpression(expr);
            }

            {
                var powerOp = context.powerOp();

                if (powerOp != null) return VisitPowerOp(powerOp);
            }

            {
                var addOp = context.addOp();

                if (addOp != null) return VisitAddOp(addOp);
            }


            {
                var productOp = context.productOp();

                if (productOp != null) return VisitProductOp(productOp);
            }

            
            var fCall = context.functionCall();

            return VisitFunctionCall(fCall);
        }

        public override object VisitComment([NotNull] DiagramParser.CommentContext context)
        {
            string value = context.GetText().Trim();
            if (value.Contains('\n'))
            {
                value = string.Concat(value.Skip(3).Take(value.Length - 6));
            }
            return new Comment(value);
        }

        public override object VisitNumber([NotNull] DiagramParser.NumberContext context)
        {
            string text = context.GetText();
            if (text.ElementAt(0) == '0')
            {
                if (text.Length == 1) // text == "0" -> True
                {
                    return 0;
                }

                switch (text.ElementAt(1))
                {
                    case 'o':
                        return Numbers.ParseOctNumber(text);
                    case 'x':
                        return Numbers.ParseHexNumber(text);
                    case 'b':
                        return Numbers.ParseBinNumber(text);
                    default:
                        // Decimal number
                        throw new FormatException($"Invalid number: {text}");
                }
            }
            return ConstNumeric.Of(Numbers.ParseDecNumber(text));
        }

        public override object VisitPowerOp([NotNull] DiagramParser.PowerOpContext context)
        {
            var expr = context.expression();
            if (expr != null)
            {
                return VisitExpression(expr);
            }

            DiagramParser.PowerOpContext[] ops = context.powerOp();
            Numeric 
                left = (Numeric)VisitExpression(ops[0].expression()), 
                right = (Numeric)VisitExpression(ops[1].expression());
            return new PowerOperation(left, right);
        }

        public override object VisitAddOp([NotNull] DiagramParser.AddOpContext context)
        {
            var pOp = context.productOp();
            if (pOp != null)
            {
                return VisitProductOp(pOp);
            }

            DiagramParser.AddOpContext[] ops = context.addOp();
            Numeric
                left = (Numeric)VisitAddOp(ops[0]),
                right = (Numeric)VisitAddOp(ops[1]);
            return new AddOperation(left, right, context.ADD_OP().GetText() == "+" ? AddOperation.Type.Sum : AddOperation.Type.Subtract);
        }

        public override object VisitProductOp([NotNull] DiagramParser.ProductOpContext context)
        {
            var pOp = context.powerOp();
            if (pOp != null)
            {
                return VisitPowerOp(pOp);
            }

            DiagramParser.ProductOpContext[] ops = context.productOp();
            Numeric
                left = (Numeric)VisitProductOp(ops[0]),
                right = (Numeric)VisitProductOp(ops[1]);
            return new ProductOperation(left, right, ProductOperation.GetType(context.PRODUCT_OP().GetText()));
        }

        public override object VisitFunctionArgs([NotNull] DiagramParser.FunctionArgsContext context)
        {
            var args = context.compoundExpr();
            var fArgs = new List<Value>();

            foreach (var arg in args)
            {
                fArgs.Add((Value)VisitCompoundExpr(arg));
            }

            return fArgs;
        }

        public override object VisitFunctionCall([NotNull] DiagramParser.FunctionCallContext context)
        {
            return new NamedFunctionCall(context.IDENTIFIER().GetText(), (FunctionArguments)VisitFunctionArgs(context.functionArgs()));
        }
    }
}
