using System;
using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table
{
    internal class SortOrderFormatter: ITextFormatter<SortOrder>
    {
        public void Write(SortOrder value, TextWriter writer)
        {
            switch (value)
            {
                case SortOrder.Asc:
                    writer.Write("ASC");
                    break;
                case SortOrder.Desc:
                    writer.Write("DESC");
                    break;
                case SortOrder.Default:
                    break;
                default:
                    throw new NotSupportedException($"unexpected SortOrder: {value}");
            }
        }
    }
}