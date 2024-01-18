using System.IO;
using Core.SqlScripting.Common.Syntax;

namespace Core.SqlScripting.Common.Writer
{
    internal class StatementTerminatorFormatter: ITextFormatter<StatementTerminator>
    {
        public void Write(StatementTerminator value, TextWriter writer)
        {
            writer.Write(value.Terminator);
            if (value.FollowedByNewline) writer.WriteLine();
        }
    }
}
