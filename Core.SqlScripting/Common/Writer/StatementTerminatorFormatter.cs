using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.Common.Syntax;
using Core.Text.Formatter;

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
