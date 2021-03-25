using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public class RenameTableStatement : AlterTableStatement
    {
        public string NewTableName { get; set; }

        public RenameTableStatement(EntityObject entity, string newTableName)
        {
            Entity  = entity;
            NewTableName = newTableName;
        }

        public RenameTableStatement(string tableName, string newTableName) : this(new EntityObject(tableName), newTableName)
        { }
    }
}