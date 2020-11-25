using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints.Column
{
    /// <summary>
    /// Generated Always Clause. Available from version 3.31.0 (2020-01-22)
    /// </summary>
    public class GeneratedConstraint : AbstractSqlColumnConstraint
    {
        public string              Expression   { get; set; }
        public GeneratedColumnType BehaviorType { get; set; }
    }

}
