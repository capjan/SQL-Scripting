using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public class RenameTableStatement : AlterTableStatement
    {
        public string NewTableName { get; }

        public RenameTableStatement(EntityObject entity, string newTableName) : base(entity)
        {
            NewTableName = newTableName;
        }

        public RenameTableStatement(string tableName, string newTableName) : this(new EntityObject(tableName), newTableName)
        { }
    }
}