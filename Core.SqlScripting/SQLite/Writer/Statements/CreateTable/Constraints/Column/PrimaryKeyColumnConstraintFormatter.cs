using System;
using System.IO;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.SQLite.Syntax.Enums;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column
{
    internal class PrimaryKeyColumnConstraintFormatter: ITextFormatter<PrimaryKeyConstraint>
    {
        private readonly OnConflictClauseFormatter _onConflictClauseFormatter;

        public PrimaryKeyColumnConstraintFormatter(OnConflictClauseFormatter optionalConflictClauseFormatter)
        {
            _onConflictClauseFormatter = optionalConflictClauseFormatter;
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
            _onConflictClauseFormatter.Write(value.ConflictClause, writer);
            if (value.Autoincrement)
                writer.Write(" AUTOINCREMENT");
        }
    }
}
