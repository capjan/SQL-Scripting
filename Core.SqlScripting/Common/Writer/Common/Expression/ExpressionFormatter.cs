using System;
using System.IO;
using Core.SqlScripting.Common.Syntax.Update;

namespace Core.SqlScripting.Common.Writer.Common.Expression
{
    public class ExpressionFormatter: ITextFormatter<IExpression>
    {
        public void Write(IExpression? value, TextWriter writer)
        {
            if (value is RawExpression rawExpression)
                writer.Write(rawExpression.Content);
            else 
                throw new ArgumentException("unexpected expression", nameof(value));
        }
    }
}
