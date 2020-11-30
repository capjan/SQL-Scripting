using System;
using System.IO;
using System.Runtime.CompilerServices;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.Common.Writer.Comment;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.Common.Writer.Delete;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.Common.Writer.Insert;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table;
using Core.SqlScripting.SqlServer.Syntax;
using Core.SqlScripting.SqlServer.Writer.Helper;

namespace Core.SqlScripting.SqlServer.Writer
{
    public class SqlServerSqlWriter: ISqlWriter
    {
        private readonly StatementTerminator              _statementTerminator;
        private readonly StatementTerminatorFormatter     _statementTerminatorFormatter;
        private readonly TruncateTableStatementFormatter  _truncateTableStatementFormatter;
        private readonly CommentStatementFormatter        _commandStatementFormatter;
        private readonly InsertStatementFormatter         _insertStatementFormatter;
        private readonly DropTableStatementFormatter      _dropTableStatementFormatter;
        private readonly SetIdentityInsertFormatter       _setIdentityInsertFormatter;
        private readonly DeleteStatementFormatter         _deleteStatementFormatter;
        private readonly CreateTableStatementFormatter    _createTableFormatter;

        public SqlServerSqlWriter(SqlWriterSettings settings = default)
        {
            settings = settings ?? new SqlWriterSettings
            {
                Indent = "   ",
                StatementTerminator = ";",
                WriteNewLineAfterStatementTerminator = true
            };

            var identifierFormatter            = new IdentifierFormatter(IdentifierQuoteStyle.Microsoft);
            var entityObjectFormatter          = new EntityObjectFormatter(identifierFormatter);
            var sqlStringFormatter             = new SqlStringFormatter();
            var columnValueAssignmentFormatter = new ColumnAssignmentValueFormatter(sqlStringFormatter);
            var conflictClauseFormatter = new ConflictClauseFormatter();
            var onColflictClauseFormatter = new OnConflictClauseFormatter(conflictClauseFormatter);
            
            var primaryKeyColumnConstraintFormatter =
                new PrimaryKeyColumnConstraintFormatter(onColflictClauseFormatter);
            var typeFormatter = new SqlServerTypeFormatter();
            var columnConstraintFormatter  = new ColumnConstraintsFormatter(primaryKeyColumnConstraintFormatter);
            var columnDefinitionFormatter =
                new SqlColumnDefinitionsFormatter(identifierFormatter, columnConstraintFormatter, typeFormatter);
            var indexKeyFormatter       = new IndexKeyTypeFormatter();
            var sortOrderFormatter      = new SortOrderFormatter();
            var indexedColumnFormatter = new IndexedColumnFormatter(sortOrderFormatter, identifierFormatter);

            var primaryOrUniqueTableConstraintsFormatter = new PrimaryOrUniqueTableConstraintsFormatter(
                indexKeyFormatter, indexedColumnFormatter, onColflictClauseFormatter, settings.Indent,
                identifierFormatter);
            var onOffFormatter            = new OnOffFormatter();
            var tableConstraintsFormatter = new TableConstraintsFormatter(primaryOrUniqueTableConstraintsFormatter);

            _statementTerminator = new StatementTerminator(settings.StatementTerminator, settings.WriteNewLineAfterStatementTerminator);
            _statementTerminatorFormatter = new StatementTerminatorFormatter();
            _commandStatementFormatter          = new CommentStatementFormatter();
            _truncateTableStatementFormatter = new TruncateTableStatementFormatter(entityObjectFormatter);
            _insertStatementFormatter = new InsertStatementFormatter(entityObjectFormatter, identifierFormatter, columnValueAssignmentFormatter);
            _dropTableStatementFormatter = new DropTableStatementFormatter(entityObjectFormatter);
            _setIdentityInsertFormatter = new SetIdentityInsertFormatter(entityObjectFormatter, onOffFormatter);
            _deleteStatementFormatter = new DeleteStatementFormatter(entityObjectFormatter);
            _createTableFormatter = new CreateTableStatementFormatter(entityObjectFormatter, columnDefinitionFormatter, tableConstraintsFormatter);

        }
        public void Write(ISqlStatement value, TextWriter writer)
        {

            if (value is TruncateTableStatement truncateTableStatement)
                _truncateTableStatementFormatter.Write(truncateTableStatement, writer);
            else if (value is CommentStatement commentStatement)
            {
                _commandStatementFormatter.Write(commentStatement, writer);
                writer.WriteLine();
                return;
            }
            else if (value is InsertStatement insertStatement)
                _insertStatementFormatter.Write(insertStatement, writer);
            else if (value is DropTableStatement dropTableStatement)
                _dropTableStatementFormatter.Write(dropTableStatement, writer);
            else if (value is SetIdentityInsertStatement setIdentityInsertStatement)
                _setIdentityInsertFormatter.Write(setIdentityInsertStatement, writer);
            else if (value is DeleteStatement deleteStatement)
                _deleteStatementFormatter.Write(deleteStatement, writer);
            else if (value is CreateTableStatement createTableStatement)
                _createTableFormatter.Write(createTableStatement, writer);
            else throw new InvalidOperationException("unexpected statement detected.");
            
            // Command Terminator
            _statementTerminatorFormatter.Write(_statementTerminator, writer);
        }
    }
}
