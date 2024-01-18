using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SQLite.Syntax.Statements;

namespace Core.SqlScripting.SQLite.Writer.Statements
{
    internal class VacuumStatementFormatter: ITextFormatter<VacuumStatement>
    {
        private readonly IdentifierFormatter _identifierFormatter;
        private readonly ISqlStringFormatter _sqlStringFormatter;

        public VacuumStatementFormatter(IdentifierFormatter identifierFormatter, ISqlStringFormatter sqlStringFormatter)
        {
            _identifierFormatter     = identifierFormatter;
            _sqlStringFormatter = sqlStringFormatter;
        }

        public void Write(VacuumStatement value, TextWriter writer)
        {
            writer.Write("VACUUM");
            if (!string.IsNullOrWhiteSpace(value.SchemaName))
            {
                writer.Write(" ");
                _identifierFormatter.Write(value.SchemaName, writer);
            }

            if (value.OutputPath is { } valueOutputPath)
            {
                writer.Write(" INTO ");
                _sqlStringFormatter.Write(valueOutputPath, writer);
            }
        }
    }
}
