using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public abstract class AlterTableStatement : ISqlStatement
    {
        protected AlterTableStatement(EntityObject entity)
        {
            Entity = entity;
        }
        public EntityObject Entity { get; }
    }
}
