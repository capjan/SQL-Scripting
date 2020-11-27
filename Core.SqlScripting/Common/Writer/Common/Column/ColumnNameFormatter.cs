using System.IO;
using Core.SqlScripting.Common.Syntax.Column;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common.Column
{
    internal class ColumnNameFormatter: ITextFormatter<ColumnName>
    {
        private readonly IdentifierFormatter _identifierFormatter;
        public ColumnNameFormatter(IdentifierFormatter identifierFormatter)
        {
            _identifierFormatter = identifierFormatter;
        }

        public void Write(ColumnName value, TextWriter writer)
        {
            _identifierFormatter.Write(value.Name, writer);
        }
    }
}
