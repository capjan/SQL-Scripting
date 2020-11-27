using System.IO;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common
{
    public interface ISqlStringFormatter : ITextFormatter<string> { }

    public class SqlStringFormatter: ISqlStringFormatter
    {
        public void Write(string value, TextWriter writer)
        {
            var escapedString = value.Replace("'", "''");
            writer.Write($"'{escapedString}'");
        }
    }
}
