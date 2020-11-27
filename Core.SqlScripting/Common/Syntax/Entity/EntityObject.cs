namespace Core.SqlScripting.Common.Syntax.Entity
{
    /// <summary>
    /// Entity definition for a Table/View/Routine/etc.
    /// </summary>
    public class EntityObject
    {
        /// <summary>
        /// Name of the database which contains this entity.
        /// </summary>
        public string DatabaseName { get; set; } = "";
        
        /// <summary>
        /// Name of the Schema which contains this entity.
        /// </summary>
        public string SchemaName   { get; set; } = "";
        
        /// <summary>
        /// Name of the Entity (Table-Name, View-Name, Routine-Name)
        /// </summary>
        public string Name    { get; set; } = "";
    }
}
