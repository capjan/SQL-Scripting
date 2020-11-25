using System;
using System.IO;
using Core.SqlScripting.SQLite.Syntax.Enums;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column
{
    public class PrimaryKeyColumnConstraintFormatter: ITextFormatter<PrimaryKeyConstraint>
    {
        private readonly ConflictClauseFormatter _optionalConflictClauseFormatter;

        public PrimaryKeyColumnConstraintFormatter(ConflictClauseFormatter optionalConflictClauseFormatter)
        {
            _optionalConflictClauseFormatter = optionalConflictClauseFormatter;
        }

        public void Write(PrimaryKeyConstraint value, TextWriter writer)
        {
            writer.Write(" PRIMARY KEY");
            switch (value.Order)
            {
                case SortOrder.Default:
                    break;
                case SortOrder.Asc:
                    writer.Write(" ASC");
                    break;
                case SortOrder.Desc:
                    writer.Write(" DESC");
                    break;
                default:
                    throw new NotSupportedException("Unexpected sort order detected.");
            }
            _optionalConflictClauseFormatter.Write(value.ConflictClause, writer);
            if (value.Autoincrement)
                writer.Write(" AUTOINCREMENT");
        }
    }
}
