using System.Collections.Generic;
using System.IO;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    internal class SqlCreateTableStatementFormatter : ITextFormatter<CreateTableStatement>
    {
        private readonly EntityObjectFormatter                   _entityObjectFormatter;
        private readonly ITextFormatter<IList<ColumnDefinition>> _columnDefinitionFormatter;
        private readonly TableConstraintsFormatter               _tableConstraintsFormatter;

        public SqlCreateTableStatementFormatter(
            EntityObjectFormatter                          entityObjectFormatter,
            ITextFormatter<IList<ColumnDefinition>> columnDefinitionFormatter, TableConstraintsFormatter tableConstraintsFormatter)
        {
            _columnDefinitionFormatter = columnDefinitionFormatter;
            _tableConstraintsFormatter = tableConstraintsFormatter;
            _entityObjectFormatter     = entityObjectFormatter;
        }

        public void Write(CreateTableStatement value, TextWriter writer)
        {
            writer.Write("CREATE");
            if (value.IsTemporary) writer.Write(" TEMPORARY");
            writer.Write(" TABLE");
            if (value.IfNotExits) writer.Write(" IF NOT EXISTS");
            writer.Write(" ");
            _entityObjectFormatter.Write(value.Entity, writer);
            
            
            // Column definitions
            writer.Write(" ( ");
            _columnDefinitionFormatter.Write(value.Columns, writer);
            // table constraints
            _tableConstraintsFormatter.Write(value.TableConstraints, writer);
            writer.Write(" )");
            
            

            // Without RowID
            if (value.WithoutRowId) writer.Write(" WITHOUT ROWID");

        }
    }
}