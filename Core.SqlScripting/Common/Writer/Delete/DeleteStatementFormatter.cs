using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Writer.Common.Entity;
using Core.SqlScripting.SqlServer.Writer;

namespace Core.SqlScripting.Common.Writer.Delete
{
    internal class DeleteStatementFormatter: ITextFormatter<DeleteStatement>
    {
        private readonly EntityObjectFormatter _entityObjectFormatter;
        public DeleteStatementFormatter(EntityObjectFormatter entityObjectFormatter)
        {
            _entityObjectFormatter = entityObjectFormatter;
        }

        public void Write(DeleteStatement value, TextWriter writer)
        {
            writer.Write("DELETE FROM ");
            _entityObjectFormatter.Write(value.Entity, writer);
        }
    }
}
