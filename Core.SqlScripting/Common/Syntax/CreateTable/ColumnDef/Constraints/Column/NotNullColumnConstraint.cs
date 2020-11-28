namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column
{
    public class NotNullColumnConstraint : AbstractSqlColumnConstraint
    {
        public SqlConflictClause OnConflict { get; set; } = SqlConflictClause.Default;
    }
}