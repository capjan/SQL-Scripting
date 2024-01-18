using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.Column;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.SqlServer.Syntax;

namespace Core.SqlScripting.Extensions
{
    public static class InsertStatementRelated
    {
        public static ColumnAssignment<T?> AddColumn<T>(this InsertStatement statement, string columnName, T? value = default)
        {
            var result = new ColumnAssignment<T?>(columnName, value);
            statement.Assignments.Add(result);
            return result;
        }

        public static UpdateAssignment<T?> SetColumn<T>(this UpdateStatement statement, string columnName, T? value = default)
        {
            var result = new UpdateAssignment<T?>
            {
                ColumnOrColumnNameList = new ColumnName(columnName),
                Value                  = value
            };
            statement.Assignments.Add(result);
            return result;
        }
    }
}
