using System.Collections.Generic;

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
        public EntityObject             Entity      { get; set; } = new EntityObject();
        public IList<IColumnAssignment> Assignments { get; }      = new List<IColumnAssignment>();

        public InsertStatement() { }

        public InsertStatement(string tableName)
        {
            Entity = new EntityObject
            {
                TableName = tableName
            };
        }
    }
}
