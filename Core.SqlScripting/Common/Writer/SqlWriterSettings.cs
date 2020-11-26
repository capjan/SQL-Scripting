namespace Core.SqlScripting.Common.Writer
{
    public class SqlWriterSettings
    {
        public string StatementTerminator                  { get; set; } = ";";
        public bool   WriteNewLineAfterStatementTerminator { get; set; } = true;
        public string Indent                               { get; set; } = "   ";
    }
}