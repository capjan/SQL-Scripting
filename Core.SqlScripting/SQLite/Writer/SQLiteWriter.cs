using System;
using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.AlterTable;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.Common.Writer.Comment;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.Common.Writer.Common.Column;
using Core.SqlScripting.Common.Writer.Common.Entity;
using Core.SqlScripting.Common.Writer.Common.Expression;
using Core.SqlScripting.Common.Writer.Delete;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.Common.Writer.Insert;
using Core.SqlScripting.Common.Writer.Update;
using Core.SqlScripting.SQLite.Syntax;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Writer.Statements;
using Core.SqlScripting.SQLite.Writer.Statements.AlterTable;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;
using ISqlStatement = Core.SqlScripting.Common.Syntax.ISqlStatement;

namespace Core.SqlScripting.SQLite.Writer
{
    // ReSharper disable once InconsistentNaming
    public class SQLiteWriter: ISqlWriter
    {
        private readonly StatementTerminatorFormatter   _statementTerminatorFormatter;
        private readonly CreateTableStatementFormatter  _createTableFormatter;
        private readonly CommentStatementFormatter      _commentStatementFormatter;
        private readonly DeleteStatementFormatter       _deleteStatementFormatter;
        private readonly StatementTerminator            _statementTerminator;
        private readonly InsertStatementFormatter       _insertStatementFormatter;
        private readonly DropTableStatementFormatter    _dropTableStatementFormatter;
        private readonly VacuumStatementFormatter       _vacuumStatementFormatter;
        private readonly UpdateStatementFormatter       _updateStatementFormatter;
        private readonly PragmaStatementFormatter       _pragmaStatementFormatter;
        private readonly RenameTableStatementFormatter  _renameTableStatementFormatter;
        private readonly RenameColumnStatementFormatter _renameColumnStatementFormatter;
        private readonly AddColumnStatementFormatter    _addColumnStatementFormatter;
        private readonly DropColumnStatementFormatter   _dropColumnStatementFormatter;


        public SQLiteWriter(SqlWriterSettings? settings = default)
        {
            settings = settings ?? new SqlWriterSettings
            {
                Indent                               = "   ",
                StatementTerminator                  = ";",
                WriteNewLineAfterStatementTerminator = true
            };

            var separatorFormatter                   = new SeparatorFormatter<string>();
            var identifierFormatter                  = new IdentifierFormatter(IdentifierQuoteStyle.Default);
            var entityFormatter                      = new EntityObjectFormatter(identifierFormatter);
            var qualifiedEntityFormatter             = new QualifiedEntityObjectFormatter(entityFormatter, identifierFormatter);
            var conflictClauseFormatter              = new ConflictClauseFormatter();
            var onConflictClauseFormatter            = new OnConflictClauseFormatter(conflictClauseFormatter);
            var sqlStringFormatter                   = new SqlStringFormatter();
            var primaryKeyColumnConstraintsFormatter = new PrimaryKeyColumnConstraintFormatter(onConflictClauseFormatter);
            var constraintFormatter                  = new ColumnConstraintsFormatter(primaryKeyColumnConstraintsFormatter);
            var sqlTypeFormatter                     = new SQLiteTypeFormatter();
            var columnDefinitionFormatter            = new SqlColumnDefinitionFormatter(identifierFormatter, constraintFormatter, sqlTypeFormatter);
            var columnDefinitionListFormatter        = new SqlColumnDefinitionsFormatter(columnDefinitionFormatter);
            var keyTypeFormatter                     = new IndexKeyTypeFormatter();
            var sortOrderFormatter                   = new SortOrderFormatter();
            var indexedColumnFormatter               = new IndexedColumnFormatter(sortOrderFormatter, identifierFormatter);
            var primaryKeyFormatter                  = new PrimaryOrUniqueTableConstraintsFormatter(keyTypeFormatter, indexedColumnFormatter, onConflictClauseFormatter, settings.Indent, identifierFormatter);
            var tableConstraintsFormatter            = new TableConstraintsFormatter(primaryKeyFormatter);
            var columnAssignmentFormatter            = new ColumnAssignmentValueFormatter(sqlStringFormatter);
            var expressionFormatter                  = new ExpressionFormatter();
            var columnNameFormatter                  = new ColumnNameFormatter(identifierFormatter);
            var columnNameListFormatter              = new ColumnNameListFormatter(columnNameFormatter, separatorFormatter);
            var columnNameOrColumnListFormatter      = new ColumnNameOrColumnNameListFormatter(columnNameFormatter, columnNameListFormatter);
            var updateAssignmentFormatter            = new UpdateAssignmentFormatter(columnNameOrColumnListFormatter, expressionFormatter, sqlStringFormatter);
            
            var pragmaValueFormatter = new PragmaValueFormatter();
            
 
            _statementTerminator = new StatementTerminator(settings.StatementTerminator, settings.WriteNewLineAfterStatementTerminator);
            _statementTerminatorFormatter = new StatementTerminatorFormatter();
            _createTableFormatter =  new CreateTableStatementFormatter(entityFormatter, columnDefinitionListFormatter, tableConstraintsFormatter);
            _commentStatementFormatter = new CommentStatementFormatter();
            _deleteStatementFormatter = new DeleteStatementFormatter(entityFormatter);
            _statementTerminatorFormatter = new StatementTerminatorFormatter();
            _insertStatementFormatter = new InsertStatementFormatter(entityFormatter, identifierFormatter, columnAssignmentFormatter);
            _dropTableStatementFormatter = new DropTableStatementFormatter(entityFormatter);
            _vacuumStatementFormatter = new VacuumStatementFormatter(identifierFormatter, sqlStringFormatter);
            _updateStatementFormatter = new UpdateStatementFormatter(conflictClauseFormatter, qualifiedEntityFormatter, separatorFormatter, updateAssignmentFormatter, expressionFormatter);
            _pragmaStatementFormatter = new PragmaStatementFormatter(entityFormatter, pragmaValueFormatter);
            _renameTableStatementFormatter = new RenameTableStatementFormatter(entityFormatter);
            _renameColumnStatementFormatter = new RenameColumnStatementFormatter(entityFormatter, columnNameFormatter);
            _addColumnStatementFormatter = new AddColumnStatementFormatter(entityFormatter, columnDefinitionFormatter);
            _dropColumnStatementFormatter = new DropColumnStatementFormatter(entityFormatter, columnNameFormatter);
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
            else if (value is InsertStatement insertStatement)
                _insertStatementFormatter.Write(insertStatement, writer);
            else if (value is DropTableStatement dropTableStatement)
                _dropTableStatementFormatter.Write(dropTableStatement, writer);
            else if (value is VacuumStatement vacuumStatement)
                _vacuumStatementFormatter.Write(vacuumStatement, writer);
            else if (value is UpdateStatement updateStatement)
                _updateStatementFormatter.Write(updateStatement, writer);
            else if (value is PragmaStatement pragmaStatement)
                _pragmaStatementFormatter.Write(pragmaStatement, writer);
            else if (value is RenameTableStatement renameTableStatement)
                _renameTableStatementFormatter.Write(renameTableStatement, writer);
            else if (value is RenameColumnStatement renameColumnStatement)
                _renameColumnStatementFormatter.Write(renameColumnStatement, writer);
            else if (value is AddColumnStatement addColumnStatement)
                _addColumnStatementFormatter.Write(addColumnStatement, writer);
            else if (value is DropColumnStatement dropColumnStatement)
                _dropColumnStatementFormatter.Write(dropColumnStatement, writer);
            else
                throw new NotSupportedException("The script contains an unexpected sql statement.");

            _statementTerminatorFormatter.Write(_statementTerminator, writer);
        }
    }
}