using System;
using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.SqlScripting.Common.Writer.Comment;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SqlServer.Syntax;
using Core.SqlScripting.SqlServer.Writer.Helper;

namespace Core.SqlScripting.SqlServer.Writer
{

    public class SqlServerSqlWriterSettings
    {
        public string CommandTerminator { get; set; } = ";";
        public string Indent            { get; set; } = "   ";
    }

    public class SqlServerSqlWriter: ISqlWriter
    {
        private readonly SqlServerSqlWriterSettings      _settings;
        private readonly TruncateTableStatementFormatter _truncateTableStatementFormatter;
        private readonly CommentStatementWriter          _commandStatementWriter;
        private readonly InsertStatementFormatter        _insertStatementFormatter;
        private readonly DropTableStatementFormatter     _dropTableStatementFormatter;
        private readonly SetIdentityInsertFormatter      _setIdentityInsertFormatter;

        public SqlServerSqlWriter(SqlServerSqlWriterSettings settings = default)
        {

            var identifierFormatter   = new IdentifierFormatter(IdentifierQuoteStyle.Microsoft);
            var entityObjectFormatter = new EntityObjectFormatter(identifierFormatter);
            var columnValueAssignmentFormatter = new ColumnAssignmentValueFormatter();
            var onOffFormatter = new OnOffFormatter();

            _settings                        = settings ?? new SqlServerSqlWriterSettings();
            _commandStatementWriter          = new CommentStatementWriter();
            _truncateTableStatementFormatter = new TruncateTableStatementFormatter(entityObjectFormatter);
            _insertStatementFormatter = new InsertStatementFormatter(entityObjectFormatter, identifierFormatter, columnValueAssignmentFormatter);
            _dropTableStatementFormatter = new DropTableStatementFormatter(entityObjectFormatter);
            _setIdentityInsertFormatter = new SetIdentityInsertFormatter(entityObjectFormatter, onOffFormatter);

        }
        public void Write(ISqlStatement value, TextWriter writer)
        {

            if (value is TruncateTableStatement truncateTableStatement)
                _truncateTableStatementFormatter.Write(truncateTableStatement, writer);
            else if (value is CommentStatement commentStatement)
            {
                _commandStatementWriter.Write(commentStatement, writer);
                writer.WriteLine();
                return;
            }
            else if (value is InsertStatement insertStatement)
                _insertStatementFormatter.Write(insertStatement, writer);
            else if (value is DropTableStatement dropTableStatement)
                _dropTableStatementFormatter.Write(dropTableStatement, writer);
            else if (value is SetIdentityInsertStatement setIdentityInsertStatement)
                _setIdentityInsertFormatter.Write(setIdentityInsertStatement, writer);
            else throw new InvalidOperationException("unexpected statement detected.");
            writer.WriteLine(_settings.CommandTerminator);
        }
    }
}
