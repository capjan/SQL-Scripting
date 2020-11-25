using System.IO;
using Core.SqlScripting.SqlServer.Syntax;
using Core.Text.Formatter;

namespace Core.SqlScripting.SqlServer.Writer
{
    internal class TruncateTableStatementFormatter: ITextFormatter<TruncateTableStatement>
    {
        private readonly EntityObjectFormatter _entityObjectFormatter;

        public TruncateTableStatementFormatter(EntityObjectFormatter entityObjectFormatter)
        {
            _entityObjectFormatter = entityObjectFormatter;
        }

        public void Write(TruncateTableStatement value, TextWriter writer)
        {
            writer.Write("TRUNCATE TABLE ");
            _entityObjectFormatter.Write(value.Entity, writer);
        }
    }
}
