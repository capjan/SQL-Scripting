using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.AlterTable;
using Core.SqlScripting.Common.Writer.Common.Column;
using Core.SqlScripting.Common.Writer.Common.Entity;
using Core.SqlScripting.SqlServer.Writer;

namespace Core.SqlScripting.SQLite.Writer.Statements.AlterTable
{
    internal class DropColumnStatementFormatter : ITextFormatter<DropColumnStatement>
    {
        private readonly EntityObjectFormatter _entityFormatter;
        private readonly ColumnNameFormatter   _columnNameFormatter;

        public DropColumnStatementFormatter(EntityObjectFormatter entityFormatter, ColumnNameFormatter columnNameFormatter)
        {
            _entityFormatter     = entityFormatter;
            _columnNameFormatter = columnNameFormatter;
        }

        public void Write(DropColumnStatement value, TextWriter writer)
        {
            writer.Write("ALTER TABLE ");
            _entityFormatter.Write(value.Entity, writer);
            writer.Write(" DROP COLUMN ");
            _columnNameFormatter.Write(value.ColumnName, writer);
        }
    }
}