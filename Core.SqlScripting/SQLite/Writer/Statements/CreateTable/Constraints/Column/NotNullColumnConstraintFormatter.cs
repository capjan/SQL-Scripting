using System.IO;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column
{
    internal class NotNullColumnConstraintFormatter: ITextFormatter<NotNullColumnConstraint>
    {
        private readonly OnConflictClauseFormatter _onConflictClauseFormatter;
        public NotNullColumnConstraintFormatter(OnConflictClauseFormatter conflictClauseFormatter)
        {
            _onConflictClauseFormatter = conflictClauseFormatter;
        }

        public void Write(NotNullColumnConstraint value, TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(value.Name))
                writer.Write($" {value.Name}");
            writer.Write(" NOT NULL");
            _onConflictClauseFormatter.Write(value.OnConflict, writer);
        }
    }
}
