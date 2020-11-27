using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.SqlServer.Syntax
{
    public class TruncateTableStatement: ISqlStatement
    {
        public TruncateTableStatement(EntityObject entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Database Table Entity to Truncate
        /// </summary>
        public EntityObject Entity { get; }
    }
}
