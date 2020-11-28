using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints;

namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef
{
    public class ColumnDefinition
    {
        public string Name { get; set; }
        public IColumnType Type { get; set; }
        public IList<ISqlColumnConstraint> Constraints { get; } = new List<ISqlColumnConstraint>();
    }
}