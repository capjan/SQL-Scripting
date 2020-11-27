using System.IO;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common.Entity
{
    internal class QualifiedEntityObjectFormatter: ITextFormatter<QualifiedEntityObject>
    {
        private readonly EntityObjectFormatter _entityObjectFormatter;
        private readonly IdentifierFormatter   _identifierFormatter;
        public QualifiedEntityObjectFormatter(EntityObjectFormatter entityObjectFormatter, IdentifierFormatter identifierFormatter)
        {
            _entityObjectFormatter    = entityObjectFormatter;
            _identifierFormatter = identifierFormatter;
        }

        public void Write(QualifiedEntityObject value, TextWriter writer)
        {
            _entityObjectFormatter.Write(value.Entity, writer);
            if (!string.IsNullOrWhiteSpace(value.Alias))
            {
                writer.Write(" AS ");
                _identifierFormatter.Write(value.Alias, writer);
            }
        }
    }
}
