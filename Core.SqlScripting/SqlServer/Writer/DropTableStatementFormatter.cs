using System.IO;
using Core.SqlScripting.SqlServer.Syntax;
using Core.Text.Formatter;

namespace Core.SqlScripting.SqlServer.Writer
{
    internal class DropTableStatementFormatter: ITextFormatter<DropTableStatement>
    {
        private readonly EntityObjectFormatter _entityObjectFormatter;
        public DropTableStatementFormatter(EntityObjectFormatter entityObjectFormatter)
        {
            _entityObjectFormatter = entityObjectFormatter;
        }

        public void Write(DropTableStatement value, TextWriter writer)
        {
            writer.Write("DROP TABLE");
            if (value.IfExists) writer.Write(" IF EXISTS");
            writer.Write(" ");
            _entityObjectFormatter.Write(value.Entity, writer);
        }
    }
}
