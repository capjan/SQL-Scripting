namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    public class CheckConstraint : AbstractSqlColumnConstraint
    {
        public string Expression { get; set; }
    }
}