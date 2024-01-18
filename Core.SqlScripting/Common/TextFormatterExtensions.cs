using System.IO;
using System.Text;

namespace Core.SqlScripting.Common
{
    public static class TextFormatterExt
    {
        public static string WriteToString<T>(this ITextFormatter<T> formatter, T value, string? newLine = default)
        {
            var sb = new StringBuilder();
            using (var stream = new StringWriter(sb))
            {
                stream.NewLine = newLine ?? stream.NewLine;
                formatter.Write(value, stream);
            }
            return sb.ToString();
        }
    

        public static void WriteLine<T>(this ITextFormatter<T> formatter, T value, TextWriter writer)
        {
            formatter.Write(value, writer);
            writer.WriteLine();
        }
    



        public static string ToFormattedString<T>(this T value, ITextFormatter<T> formatter)
        {
            return formatter.WriteToString(value);
        }


    }
}