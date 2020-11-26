using System;
using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.Common.Writer.Comment;
using Core.SqlScripting.Common.Writer.Delete;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SQLite.Syntax;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table;
using Core.SqlScripting.SqlServer.Writer;
using ISqlStatement = Core.SqlScripting.Common.Syntax.ISqlStatement;

namespace Core.SqlScripting.SQLite.Writer
{

    public class SQLiteWriter: ISqlWriter
    {
        private readonly StatementTerminatorFormatter     _statementTerminatorFormatter;
        private readonly SqlCreateTableStatementFormatter _createTableFormatter;
        private readonly CommentStatementFormatter        _commentStatementFormatter;
        private readonly DeleteStatementFormatter         _deleteStatementFormatter;
        private readonly StatementTerminator              _statementTerminator;


        public SQLiteWriter(SqlWriterSettings settings = default)
        {
            settings = settings ?? new SqlWriterSettings
            {
                Indent                               = "   ",
                StatementTerminator                  = ";",
                WriteNewLineAfterStatementTerminator = true
            };

            _statementTerminator = new StatementTerminator(settings.StatementTerminator, settings.WriteNewLineAfterStatementTerminator);
            _statementTerminatorFormatter = new StatementTerminatorFormatter();
            var identifierFormatter = new IdentifierFormatter(IdentifierQuoteStyle.Default);
            var entityFormatter = new EntityObjectFormatter(identifierFormatter);
            var conflictClauseFormatter = new ConflictClauseFormatter();
            var primaryKeyColumnConstraintsFormatter = new PrimaryKeyColumnConstraintFormatter(conflictClauseFormatter);
            var constraintFormatter = new ColumnConstraintsFormatter(primaryKeyColumnConstraintsFormatter);
            var columnDefinitionFormatter = new SqlColumnDefinitionsFormatter(identifierFormatter, constraintFormatter, settings.Indent);
            var tableNameFormatter = new TableNameFormatter(identifierFormatter);
            var keyTypeFormatter = new IndexKeyTypeFormatter();
            var sortOrderFormatter = new SortOrderFormatter();
            var indexedColumnFormatter = new IndexedColumnFormatter(sortOrderFormatter, identifierFormatter);
            var primaryKeyFormatter = new PrimaryOrUniqueTableConstraintsFormatter(keyTypeFormatter, indexedColumnFormatter, conflictClauseFormatter, settings.Indent, identifierFormatter);
            var tableConstraintsFormatter = new TableConstraintsFormatter(primaryKeyFormatter);
           _createTableFormatter =  new SqlCreateTableStatementFormatter(tableNameFormatter, columnDefinitionFormatter, tableConstraintsFormatter);

            _commentStatementFormatter = new CommentStatementFormatter();
            _deleteStatementFormatter = new DeleteStatementFormatter(entityFormatter);
            _statementTerminatorFormatter = new StatementTerminatorFormatter();
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
            {
                _commentStatementFormatter.Write(commentStatement, writer);
                return;
            }
            
            if (value is CreateTableStatement createTableStatement) 
                _createTableFormatter.Write(createTableStatement, writer);
            else if (value is DeleteStatement deleteStatement)
                _deleteStatementFormatter.Write(deleteStatement, writer);
            else
                throw new NotSupportedException("The script contains an unexpected sql statement.");

            _statementTerminatorFormatter.Write(_statementTerminator, writer);
        }
    }
}