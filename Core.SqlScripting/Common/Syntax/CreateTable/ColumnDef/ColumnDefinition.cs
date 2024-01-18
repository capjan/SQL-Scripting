using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints;

namespace Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef
{
    public class ColumnDefinition(string name, IColumnType type)
    {
        public string Name { get; set; } = name;
        public IColumnType Type { get; set; } = type;
        public IList<ISqlColumnConstraint> Constraints { get; } = new List<ISqlColumnConstraint>();
    }
}