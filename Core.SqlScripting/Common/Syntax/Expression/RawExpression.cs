namespace Core.SqlScripting.Common.Syntax.Update
{
    public class RawExpression(string content) : IExpression
    {
        public string Content { get; set; } = content;
    }
}