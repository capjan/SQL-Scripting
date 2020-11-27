using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.Enums;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Common
{
    internal class OnConflictClauseFormatter: ITextFormatter<ConflictClause>
    {
        private readonly ConflictClauseFormatter _conflictClauseFormatter;

        public OnConflictClauseFormatter(ConflictClauseFormatter conflictClauseFormatter)
        {
            _conflictClauseFormatter = conflictClauseFormatter;
        }

        public void Write(ConflictClause value, TextWriter writer)
        {
            if (value == ConflictClause.Default) return;
            writer.Write(" ON CONFLICT ");
            _conflictClauseFormatter.Write(value, writer);
            
        }
    }
}
