using System.Collections.Generic;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints;

namespace Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef
{
    public class ColumnDefinition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public IList<ISqlColumnConstraint> Constraints { get; } = new List<ISqlColumnConstraint>();
    }
}