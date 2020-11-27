using System;
using System.IO;
using Core.SqlScripting.Enums;
using Core.SqlScripting.SQLite.Syntax.Enums;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    public class ConflictClauseFormatter : ITextFormatter<ConflictClause>
    {
        public void Write(ConflictClause value, TextWriter writer)
        {
            if (value == ConflictClause.Default) return;
            
            writer.Write(" ON CONFLICT");
            switch (value)
            {
                case ConflictClause.Rollback:
                    writer.Write(" ROLLBACK");
                    break;
                case ConflictClause.Abort: 
                    writer.Write(" ABORT");
                    break;
                case ConflictClause.Fail:
                    writer.Write(" FAIL");
                    break;
                case ConflictClause.Ignore:
                    writer.Write(" IGNORE");
                    break;
                case ConflictClause.Replace:
                    writer.Write(" REPLACE");
                    break;
                default:
                    throw new NotSupportedException($"unexpected {nameof(ConflictClause)} \"{value}\" error");
            }
        }
      
    }
}