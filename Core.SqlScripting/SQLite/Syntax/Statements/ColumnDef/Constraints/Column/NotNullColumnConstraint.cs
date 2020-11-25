using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    public class NotNullColumnConstraint : AbstractSqlColumnConstraint
    {
        public ConflictClause OnConflict { get; set; } = ConflictClause.Default;
    }
}