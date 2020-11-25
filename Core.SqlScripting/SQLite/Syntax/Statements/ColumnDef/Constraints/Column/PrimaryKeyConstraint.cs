using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    public class PrimaryKeyConstraint : AbstractSqlColumnConstraint
    {
        public SortOrder      Order          { get; set; } = SortOrder.Default;
        public bool           Autoincrement  { get; set; } = false;
        public ConflictClause ConflictClause { get; set; } = ConflictClause.Default;
    }
}