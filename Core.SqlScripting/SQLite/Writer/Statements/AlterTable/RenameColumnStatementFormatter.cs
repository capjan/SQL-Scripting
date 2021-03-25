using System.IO;
using Core.SqlScripting.Common.Syntax.AlterTable;
using Core.SqlScripting.Common.Writer.Common.Column;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.AlterTable
{
    internal class RenameColumnStatementFormatter : ITextFormatter<RenameColumnStatement>
    {
        private readonly EntityObjectFormatter _entityFormatter;
        private readonly ColumnNameFormatter   _columnNameFormatter;

        public RenameColumnStatementFormatter(EntityObjectFormatter entityFormatter, ColumnNameFormatter columnNameFormatter)
        {
            _entityFormatter          = entityFormatter;
            _columnNameFormatter = columnNameFormatter;
        }

        public void Write(RenameColumnStatement value, TextWriter writer)
        {
            writer.Write("ALTER TABLE ");
            _entityFormatter.Write(value.Entity, writer);
            writer.Write(" RENAME COLUMN ");
            _columnNameFormatter.Write(value.OldColumnName, writer);
            writer.Write(" TO ");
            _columnNameFormatter.Write(value.NewColumnName, writer);
        }
    }
}
