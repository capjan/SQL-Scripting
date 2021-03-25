using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public abstract class AlterTableStatement : ISqlStatement
    {
        public EntityObject Entity { get; set; }
    }
}
