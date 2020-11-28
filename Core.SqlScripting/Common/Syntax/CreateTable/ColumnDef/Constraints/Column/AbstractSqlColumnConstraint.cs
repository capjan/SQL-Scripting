namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column
{
    public abstract class AbstractSqlColumnConstraint: ISqlColumnConstraint
    {
        public string Name { get; set; }
    }
}
