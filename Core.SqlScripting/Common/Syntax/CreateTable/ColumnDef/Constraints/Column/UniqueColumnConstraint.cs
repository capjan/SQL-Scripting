namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column
{
    public class UniqueColumnConstraint: AbstractSqlColumnConstraint
    {
        public SqlConflictClause OnConflict { get; set; } = SqlConflictClause.Default;
    }
}
