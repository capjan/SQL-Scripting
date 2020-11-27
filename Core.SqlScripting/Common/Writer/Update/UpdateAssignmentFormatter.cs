using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.Common.Writer.Common.Column;
using Core.SqlScripting.Common.Writer.Common.Expression;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Update
{
    internal class UpdateAssignmentFormatter: ITextFormatter<UpdateAssignment>
    {
        private readonly ColumnNameOrColumnNameListFormatter _columnNameOrColumnNameListFormatter;
        private readonly ExpressionFormatter                 _expressionFormatter;
        public UpdateAssignmentFormatter(ColumnNameOrColumnNameListFormatter columnNameOrColumnNameListFormatter, ExpressionFormatter expressionFormatter)
        {
            _columnNameOrColumnNameListFormatter = columnNameOrColumnNameListFormatter;
            _expressionFormatter            = expressionFormatter;
        }

        public void Write(UpdateAssignment value, TextWriter writer)
        {
            _columnNameOrColumnNameListFormatter.Write(value.ColumnOrColumnNameList, writer);
            writer.Write(" = ");
            _expressionFormatter.Write(value.Value, writer);
        }
    }
}
