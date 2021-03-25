using Core.SqlScripting.Common.Syntax.Column;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public class DropColumnStatement : AlterTableStatement
    {
        public DropColumnStatement(EntityObject entity, ColumnName columnName) : base(entity)
        {
            ColumnName = columnName;
        }

        public DropColumnStatement(string tableName, string columnName) : this(new EntityObject(tableName), new ColumnName(columnName))
        { }

        public ColumnName ColumnName { get; }
    }
}