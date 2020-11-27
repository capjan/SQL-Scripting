using System;
using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.SQLite.Syntax.Enums;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    public class ConflictClauseFormatter : ITextFormatter<SqlConflictClause>
    {
        public void Write(SqlConflictClause value, TextWriter writer)
        {
            if (value == SqlConflictClause.Default) return;
            
         
            switch (value)
            {
                case SqlConflictClause.Rollback:
                    writer.Write("ROLLBACK");
                    break;
                case SqlConflictClause.Abort: 
                    writer.Write("ABORT");
                    break;
                case SqlConflictClause.Fail:
                    writer.Write("FAIL");
                    break;
                case SqlConflictClause.Ignore:
                    writer.Write("IGNORE");
                    break;
                case SqlConflictClause.Replace:
                    writer.Write("REPLACE");
                    break;
                default:
                    throw new NotSupportedException($"unexpected {nameof(SqlConflictClause)} \"{value}\" error");
            }
        }
      
    }
}