namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    public abstract class AbstractSqlColumnConstraint: ISqlColumnConstraint
    {
        public string Name { get; set; }
    }
}
