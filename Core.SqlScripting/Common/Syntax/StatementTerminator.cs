using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SqlScripting.Common.Syntax
{
    internal class StatementTerminator
    {
        public StatementTerminator(string terminator = ";", bool followedByNewline = true)
        {
            Terminator             = terminator;
            FollowedByNewline = followedByNewline;
        }

        public string Terminator        { get; }
        public bool   FollowedByNewline { get; }

    }
}
