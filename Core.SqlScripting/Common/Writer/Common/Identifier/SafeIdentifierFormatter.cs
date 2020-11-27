using System;
using System.IO;
using Core.Extensions.TextRelated;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Identifier
{
    /// <summary>
    /// Ensures that only allowed and desired names are used for identifiers.
    /// </summary>
    public class SafeIdentifierFormatter: ITextFormatter<string>
    {
        private const string Pattern = "^[A-Za-z_][A-Za-z0-9_]*$";
        
        public void Write(string value, TextWriter writer)
        {
            if (!value.IsMatch(Pattern))
                throw new NotSupportedException($"Invalid identifier name: >> {value} <<. This library forces identifier to match: {Pattern}");
            writer.Write(value);
        }
    }
}
