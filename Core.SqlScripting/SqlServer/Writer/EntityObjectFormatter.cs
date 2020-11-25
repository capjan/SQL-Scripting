using System.IO;
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
            if (!string.IsNullOrWhiteSpace(value.DatabaseName))
            {
                _identifierFormatter.Write(value.DatabaseName, writer);
                writer.Write(".");
            }

            if (!string.IsNullOrWhiteSpace(value.SchemaName))
            {
                _identifierFormatter.Write(value.SchemaName, writer);
                writer.Write(".");
            }
            _identifierFormatter.Write(value.TableName, writer);
        }
    }
}