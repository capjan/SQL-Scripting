using System.IO;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column
{
    internal class NotNullColumnConstraintFormatter: ITextFormatter<NotNullColumnConstraint>
    {
        private readonly ConflictClauseFormatter _conflictClauseFormatter;
        public NotNullColumnConstraintFormatter(ConflictClauseFormatter conflictClauseFormatter)
        {
            _conflictClauseFormatter = conflictClauseFormatter;
        }

        public void Write(NotNullColumnConstraint value, TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(value.Name))
                writer.Write($" {value.Name}");
            writer.Write(" NOT NULL");
            _conflictClauseFormatter.Write(value.OnConflict, writer);
        }
    }
}
