using System.IO;
using System.Linq;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.Common.Writer.Common.Entity;
using Core.SqlScripting.Common.Writer.Common.Expression;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Update
{
    internal class UpdateStatementFormatter: ITextFormatter<UpdateStatement>
    {
        private readonly QualifiedEntityObjectFormatter _qualifiedEntityObjectFormatter;
        private readonly ConflictClauseFormatter        _conflictClauseFormatter;
        private readonly SeparatorFormatter<string>     _separatorFormatter;
        private readonly UpdateAssignmentFormatter      _updateAssignmentFormatter;
        private readonly ExpressionFormatter            _expressionFormatter;
        
        public UpdateStatementFormatter(ConflictClauseFormatter conflictClauseFormatter, QualifiedEntityObjectFormatter qualifiedEntityObjectFormatter, SeparatorFormatter<string> separatorFormatter, UpdateAssignmentFormatter updateAssignmentFormatter, ExpressionFormatter expressionFormatter)
        {
            _conflictClauseFormatter        = conflictClauseFormatter;
            _qualifiedEntityObjectFormatter = qualifiedEntityObjectFormatter;
            _separatorFormatter             = separatorFormatter;
            _updateAssignmentFormatter      = updateAssignmentFormatter;
            _expressionFormatter       = expressionFormatter;
        }

        public void Write(UpdateStatement value, TextWriter writer)
        {
            writer.Write("UPDATE");
            if (value.OnConflictRule != SqlConflictClause.Default)
            {
                writer.Write(" OR ");
                _conflictClauseFormatter.Write(value.OnConflictRule, writer);
            }
            writer.Write(" ");
            _qualifiedEntityObjectFormatter.Write(value.QualifiedEntity, writer);
            writer.Write(" SET ");
            _separatorFormatter.Write(value.Assignments.Select(i=>_updateAssignmentFormatter.WriteToString(i)), writer);
            if (value.WhereExpression != null)
            {
                writer.Write(" WHERE ");
                _expressionFormatter.Write(value.WhereExpression, writer);
            }
        }
    }
}
