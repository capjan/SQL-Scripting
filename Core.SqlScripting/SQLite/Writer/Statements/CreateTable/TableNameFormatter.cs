using System.IO;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    internal class TableNameFormatter : ITextFormatter<CreateTableStatement>
    {
        private readonly IdentifierFormatter _identifierFormatter;
        
        public TableNameFormatter(IdentifierFormatter identifierFormatter)
        {
            _identifierFormatter = identifierFormatter;
        }

        public void Write(CreateTableStatement value, TextWriter writer)
        {
            writer.Write(" ");
            if (!string.IsNullOrWhiteSpace(value.Schema))
            {
                _identifierFormatter.Write(value.Schema, writer);
                writer.Write(".");
            }
            _identifierFormatter.Write(value.Name, writer);
        }
    }
}