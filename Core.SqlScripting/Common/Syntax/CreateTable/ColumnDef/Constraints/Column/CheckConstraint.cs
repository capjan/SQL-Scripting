namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column
{
    public class CheckConstraint : AbstractSqlColumnConstraint
    {
        public string Expression { get; set; } = "";
    }
}