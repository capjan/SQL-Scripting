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
        public string? Database { get; }
        
        /// <summary>
        /// Name of the Schema which contains this entity.
        /// </summary>
        public string? Schema   { get; }
        
        /// <summary>
        /// Name of the Entity (Table-Name, View-Name, Routine-Name)
        /// </summary>
        public string? Name    { get; }

        public EntityObject(string? name, string? schema = "", string? database = "")
        {
            Name     = name;
            Schema   = schema;
            Database = database;
        }
    }
}
