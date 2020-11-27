using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.Common.Syntax.Update;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common.Expression
{
    public class ExpressionFormatter: ITextFormatter<IExpression>
    {
        public void Write(IExpression value, TextWriter writer)
        {
            if (value is RawExpression rawExpression)
                writer.Write(rawExpression.Content);
            else 
                throw new ArgumentException("unexpected expression", nameof(value));
        }
    }
}
