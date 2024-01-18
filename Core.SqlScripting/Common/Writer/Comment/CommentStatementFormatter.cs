using System.IO;
using Core.SqlScripting.Common.Syntax.Comment;

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