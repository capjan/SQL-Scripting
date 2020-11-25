using System.Collections.Generic;
using System.IO;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    internal class SqlCreateTableStatementFormatter : ITextFormatter<CreateTableStatement>
    {
        private readonly TableNameFormatter                          _tableNameFormatter;
        private readonly ITextFormatter<IList<ColumnDefinition>> _columnDefinitionFormatter;
        private readonly TableConstraintsFormatter                   _tableConstraintsFormatter;

        public SqlCreateTableStatementFormatter(
            TableNameFormatter                          tableNameFormatter,
            ITextFormatter<IList<ColumnDefinition>> columnDefinitionFormatter, TableConstraintsFormatter tableConstraintsFormatter)
        {
            _columnDefinitionFormatter      = columnDefinitionFormatter;
            _tableConstraintsFormatter = tableConstraintsFormatter;
            _tableNameFormatter             = tableNameFormatter;
        }

        public void Write(CreateTableStatement value, TextWriter writer)
        {
            writer.Write("CREATE");
            if (value.IsTemporary) writer.Write(" TEMPORARY");
            writer.Write(" TABLE");
            if (value.IfNotExits) writer.Write(" IF NOT EXISTS");
            _tableNameFormatter.Write(value, writer);
            writer.WriteLine();
            
            // Column definitions
            writer.WriteLine("(");
            _columnDefinitionFormatter.Write(value.Columns, writer);
            // table constraints
            _tableConstraintsFormatter.Write(value.TableConstraints, writer);
            writer.WriteLine();
            writer.Write(")");
            
            

            // Without RowID
            if (value.WithoutRowId) writer.Write(" WITHOUT ROWID");
            writer.WriteLine(";");

        }
    }
}