using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SqlServer.Syntax;
using Core.Text.Formatter;

namespace Core.SqlScripting.SqlServer.Writer
{
    internal class EntityObjectFormatter : ITextFormatter<EntityObject>
    {
        private readonly IdentifierFormatter _identifierFormatter;
        
        public EntityObjectFormatter(IdentifierFormatter identifierFormatter)
        {
            _identifierFormatter = identifierFormatter;
        }

        public void Write(EntityObject value, TextWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(value.Database))
            {
                _identifierFormatter.Write(value.Database, writer);
                writer.Write(".");
            }

            if (!string.IsNullOrWhiteSpace(value.Schema))
            {
                _identifierFormatter.Write(value.Schema, writer);
                writer.Write(".");
            }
            _identifierFormatter.Write(value.Name, writer);
        }
    }
}