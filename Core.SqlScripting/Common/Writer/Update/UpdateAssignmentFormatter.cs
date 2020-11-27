using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.Common.Writer.Common.Column;
using Core.SqlScripting.Common.Writer.Common.Expression;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Update
{
    internal class UpdateAssignmentFormatter: ITextFormatter<IUpdateAssignment>
    {
        private readonly ColumnNameOrColumnNameListFormatter _columnNameOrColumnNameListFormatter;
        private readonly ExpressionFormatter                 _expressionFormatter;
        private readonly ISqlStringFormatter                 _sqlStringFormatter;

        public UpdateAssignmentFormatter(ColumnNameOrColumnNameListFormatter columnNameOrColumnNameListFormatter, ExpressionFormatter expressionFormatter, ISqlStringFormatter sqlStringFormatter)
        {
            _columnNameOrColumnNameListFormatter = columnNameOrColumnNameListFormatter;
            _expressionFormatter                 = expressionFormatter;
            _sqlStringFormatter             = sqlStringFormatter;
        }

        public void Write(IUpdateAssignment value, TextWriter writer)
        {
            _columnNameOrColumnNameListFormatter.Write(value.ColumnOrColumnNameList, writer);
            writer.Write(" = ");
            if (value is UpdateAssignment<IExpression> expressionAssignment)
                _expressionFormatter.Write(expressionAssignment.Value, writer);
            else if (value is UpdateAssignment<string> stringAssignment)
                _sqlStringFormatter.Write(stringAssignment.Value, writer);
            else if (value is UpdateAssignment<int> intAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", intAssignment.Value));
            else if (value is UpdateAssignment<long> longAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", longAssignment.Value));
            else if (value is UpdateAssignment<short> shortAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", shortAssignment.Value));
            else if (value is UpdateAssignment<byte> byteAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", byteAssignment.Value));
            else if (value is UpdateAssignment<float> floatAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:F}", floatAssignment.Value));
            else if (value is UpdateAssignment<double> doubleAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:F}", doubleAssignment.Value));
            else if (value is UpdateAssignment<bool> boolAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "{0:D}", boolAssignment.Value ? "1": "0"));
            else if (value is UpdateAssignment<DateTime> dateTimeAssignment)
                writer.Write(string.Format(CultureInfo.InvariantCulture, "'{0:yyyy-MM-dd HH:mm:ss.fffffff}'", dateTimeAssignment.Value));
            else 
                throw new NotImplementedException($"detected unexpected column assignment type: {value.GetType().FullName}");
        }
    }
}
