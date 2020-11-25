using System;
using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.SqlScripting.Common.Writer.Comment;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SQLite.Syntax;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table;
using Core.Text.Formatter;
using ISqlStatement = Core.SqlScripting.Common.Syntax.ISqlStatement;

namespace Core.SqlScripting.SQLite.Writer
{
    public class SqlWriterSettings
    {
        public ITextFormatter<CommentStatement>     CommentFormatter;
        public ITextFormatter<CreateTableStatement> CreateTableFormatter;

        public SqlWriterSettings(
            ITextFormatter<CommentStatement> commentWriter = default, 
            ITextFormatter<CreateTableStatement> createTableWriter = default)
        {
            CommentFormatter         = commentWriter ?? new CommentStatementWriter();
            CreateTableFormatter     = createTableWriter ?? CreateDefaultIdentifierFormatter();
        }

        private static SqlCreateTableStatementFormatter CreateDefaultIdentifierFormatter()
        {
            var indent = "   ";
            var identifierFormatter = new IdentifierFormatter(IdentifierQuoteStyle.Default);
            var conflictClauseFormatter = new ConflictClauseFormatter();
            var primaryKeyColumnConstraintsFormatter = new PrimaryKeyColumnConstraintFormatter(conflictClauseFormatter);
            var constraintFormatter = new ColumnConstraintsFormatter(primaryKeyColumnConstraintsFormatter);
            var columnDefinitionFormatter = new SqlColumnDefinitionsFormatter(identifierFormatter, constraintFormatter, indent);
            var tableNameFormatter = new TableNameFormatter(identifierFormatter);
            var keyTypeFormatter = new IndexKeyTypeFormatter();
            var sortOrderFormatter = new SortOrderFormatter();
            var indexedColumnFormatter = new IndexedColumnFormatter(sortOrderFormatter, identifierFormatter);
            var primaryKeyFormatter = new PrimaryOrUniqueTableConstraintsFormatter(keyTypeFormatter, indexedColumnFormatter, conflictClauseFormatter, indent, identifierFormatter);
            var tableConstraintsFormatter = new TableConstraintsFormatter(primaryKeyFormatter);
            return new SqlCreateTableStatementFormatter(tableNameFormatter, columnDefinitionFormatter, tableConstraintsFormatter);
        }
    }
    public class SQLiteWriter: ISqlWriter
    {
        private readonly SqlWriterSettings _settings;
        
        public SQLiteWriter(SqlWriterSettings settings = default)
        {
            _settings = settings = new SqlWriterSettings();
        }

        public void Write(SqlScript value, TextWriter writer)
        {
            foreach (var statement in value.Statements)
            {
                
            }
        }

        public void Write(ISqlStatement value, TextWriter writer)
        {
            if (value is CommentStatement commentStatement)
                _settings.CommentFormatter.Write(commentStatement, writer);
            else if (value is CreateTableStatement createTableStatement) 
                _settings.CreateTableFormatter.Write(createTableStatement, writer);
            else
                throw new NotSupportedException("The script contains an unexpected sql statement.");
        }
    }
}