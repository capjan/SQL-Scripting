using System.IO;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable;

namespace Core.SqlScripting.Common.Writer.Common
{
    internal class OnConflictClauseFormatter: ITextFormatter<SqlConflictClause>
    {
        private readonly ConflictClauseFormatter _conflictClauseFormatter;

        public OnConflictClauseFormatter(ConflictClauseFormatter conflictClauseFormatter)
        {
            _conflictClauseFormatter = conflictClauseFormatter;
        }

        public void Write(SqlConflictClause value, TextWriter writer)
        {
            if (value == SqlConflictClause.Default) return;
            writer.Write(" ON CONFLICT ");
            _conflictClauseFormatter.Write(value, writer);
            
        }
    }
}
