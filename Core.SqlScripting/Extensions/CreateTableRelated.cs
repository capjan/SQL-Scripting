using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;

namespace Core.SqlScripting.Extensions
{
    public static class CreateTableRelated
    {

        public static ColumnDefinition AddColumn(this CreateTableStatement createTableStatement,  string columnName, IColumnType type)
        {
            return new ColumnDefinition()
            {
                Name = columnName, Type = type
            };
        }
    }
}
