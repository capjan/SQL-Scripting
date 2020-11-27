using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    public class NotNullColumnConstraint : AbstractSqlColumnConstraint
    {
        public SqlConflictClause OnConflict { get; set; } = SqlConflictClause.Default;
    }
}