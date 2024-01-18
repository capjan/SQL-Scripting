using System;
using System.IO;

namespace Core.SqlScripting.Common.Writer.Identifier
{
    public class IdentifierFormatter : ITextFormatter<string>
    {
        private readonly SafeIdentifierFormatter _saveIdentifierWriter = new SafeIdentifierFormatter();
        public           IdentifierQuoteStyle   QuoteStyle { get; }
        private readonly string               _quoteStart;
        private readonly string               _quoteEnd;

        public IdentifierFormatter(IdentifierQuoteStyle quoteStyle)
        {
            QuoteStyle = quoteStyle;
            switch (quoteStyle)
            {
                case IdentifierQuoteStyle.Default:
                    _quoteStart = "\"";
                    _quoteEnd   = "\"";
                    break;
                case IdentifierQuoteStyle.Microsoft:
                    _quoteStart = "[";
                    _quoteEnd   = "]";
                    break;
                case IdentifierQuoteStyle.MySQL:
                    _quoteStart = "`";
                    _quoteEnd   = "`";
                    break;
                default:
                    throw new NotSupportedException("unknown SqlIdentifierStyle");
            }
        }
        
        public void Write(string value, TextWriter writer)
        {
            writer.Write(_quoteStart);
            _saveIdentifierWriter.Write(value, writer);
            writer.Write(_quoteEnd);
        }
    }
}