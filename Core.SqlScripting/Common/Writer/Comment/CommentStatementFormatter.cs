using System.IO;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Comment
{
    internal class CommentStatementFormatter : ITextFormatter<CommentStatement>
    {
        public void Write(CommentStatement value, TextWriter writer)
        {
            writer.Write($"-- {value.Content}");
        }
    }
}