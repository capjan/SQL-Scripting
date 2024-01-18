namespace Core.SqlScripting.Common.Syntax.Entity
{
    /// <summary>
    /// Qualified Entity with an optional alias name
    /// </summary>
    public class QualifiedEntityObject
    {
        public QualifiedEntityObject(EntityObject entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Entity Definition
        /// </summary>
        public EntityObject Entity { get; set; }
        
        /// <summary>
        /// Alias Name
        /// </summary>
        public string?       Alias  { get; set; }
    }
}