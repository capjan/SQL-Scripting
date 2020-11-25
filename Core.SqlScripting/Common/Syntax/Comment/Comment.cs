namespace Core.SqlScripting.Common.Syntax.Comment
{
    public class CommentStatement: ISqlStatement
    {
        public string Content { get; set; }

        public CommentStatement(string content)
        {
            Content = content;
        }
    }
}
