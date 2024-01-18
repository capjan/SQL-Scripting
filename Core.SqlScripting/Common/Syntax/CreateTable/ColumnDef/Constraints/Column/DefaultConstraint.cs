namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column
{
    public class DefaultConstraint : AbstractSqlColumnConstraint
    {
        public string? Expression { get; set; }
    }
}