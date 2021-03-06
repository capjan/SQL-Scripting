﻿using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.Common.Syntax.CreateTable.TableConstraints
{
    public class IndexedColumn
    {
        public string    ColumnName { get; set; }
        public SortOrder Order      { get; set; }

        public IndexedColumn(string name, SortOrder order = SortOrder.Default)
        {
            ColumnName = name;
            Order      = order;
        }
    }
}
