using System.IO;
using Core.SqlScripting.Common.Syntax.AlterTable;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.AlterTable
{
    internal class AddColumnStatementFormatter : ITextFormatter<AddColumnStatement>
    {
        private readonly EntityObjectFormatter            _entityFormatter;
        private readonly ITextFormatter<ColumnDefinition> _columnDefinitionFormatter;

        public AddColumnStatementFormatter(EntityObjectFormatter entityFormatter, ITextFormatter<ColumnDefinition> columnDefinitionFormatter)
        {
            _entityFormatter           = entityFormatter;
            _columnDefinitionFormatter = columnDefinitionFormatter;
        }

        public void Write(AddColumnStatement value, TextWriter writer)
        {
            writer.Write("ALTER TABLE ");
            _entityFormatter.Write(value.Entity, writer);
            writer.Write(" ADD COLUMN ");
            _columnDefinitionFormatter.Write(value.Definition, writer);
        }
    }
}
