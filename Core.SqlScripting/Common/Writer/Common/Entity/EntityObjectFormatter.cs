using System.IO;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer.Identifier;

namespace Core.SqlScripting.Common.Writer.Common.Entity
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
            if (value.Name is {} name)
                _identifierFormatter.Write(name, writer);
        }
    }
}