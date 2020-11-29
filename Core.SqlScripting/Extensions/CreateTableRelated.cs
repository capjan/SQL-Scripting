using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column;

namespace Core.SqlScripting.Extensions
{
    public static class CreateTableRelated
    {

        public static ColumnDefinition AddColumn(this CreateTableStatement createTableStatement,  string columnName, IColumnType type)
        {
            var newColumn =  new ColumnDefinition()
            {
                Name = columnName, Type = type
            };
            createTableStatement.Columns.Add(newColumn);
            return newColumn;
        }

        public static ColumnDefinition AddPrimaryKey(this ColumnDefinition value)
        {
            value.Constraints.Add(new PrimaryKeyConstraint());
            return value;
        }

        public static ColumnDefinition AddNotNull(this ColumnDefinition value)
        {
            value.Constraints.Add(new NotNullColumnConstraint());
            return value;
        }

        public static ColumnDefinition AddUnique(this ColumnDefinition value)
        {
            value.Constraints.Add(new UniqueColumnConstraint());
            return value;
        }
    }
}
