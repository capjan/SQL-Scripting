using Core.SqlScripting.Common.Syntax;

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
