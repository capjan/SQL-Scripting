namespace Core.SqlScripting.Common.Syntax
{
    public class DropTableStatement: ISqlStatement
    {
        public bool IfExists { get; set; } = true;

        public DropTableStatement(EntityObject entity)
        {
            Entity = entity;
        }

        public EntityObject Entity { get; }
    }
}
