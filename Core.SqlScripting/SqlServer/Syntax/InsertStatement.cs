using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax;

namespace Core.SqlScripting.SqlServer.Syntax
{
    public interface IColumnAssignment
    {
        string ColumnName { get; }
    }

    public class ColumnAssignment<T> : IColumnAssignment
    {
        public string ColumnName { get; }
        public T      Value      { get; set; }

        public ColumnAssignment(string columnName, T value)
        {
            ColumnName = columnName;
            Value      = value;
        }
    }

    public class InsertStatement: ISqlStatement
    {
        public EntityObject             Entity      { get; set; } = new EntityObject();
        public IList<IColumnAssignment> Assignments { get; }      = new List<IColumnAssignment>();
    }
}
