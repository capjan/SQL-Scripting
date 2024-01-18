using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.Insert
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
        public EntityObject             Entity      { get; }
        public IList<IColumnAssignment> Assignments { get; }      = new List<IColumnAssignment>();

        
        public InsertStatement(string tableName)
        {
            Entity = new EntityObject(tableName);
        }
    }
}
