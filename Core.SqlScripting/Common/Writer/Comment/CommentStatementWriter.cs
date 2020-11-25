using System.IO;
using Core.SqlScripting.Common.Syntax.Comment;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Comment
{
    public class CommentStatementWriter : ITextFormatter<CommentStatement>
    {
        public void Write(CommentStatement value, TextWriter writer)
        {
            writer.Write($"-- {value.Content}");
        }
    }
}