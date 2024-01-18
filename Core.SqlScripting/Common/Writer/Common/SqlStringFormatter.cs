using System.IO;

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
