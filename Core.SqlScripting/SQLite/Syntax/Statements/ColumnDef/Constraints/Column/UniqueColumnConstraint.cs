using Core.SqlScripting.Enums;
using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    public class UniqueColumnConstraint: AbstractSqlColumnConstraint
    {
        public ConflictClause OnConflict { get; set; } = ConflictClause.Default;
    }
}
