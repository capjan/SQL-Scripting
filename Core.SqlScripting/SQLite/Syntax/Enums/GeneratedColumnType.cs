namespace Core.SqlScripting.SQLite.Syntax.Enums
{
    /// <summary>
    /// Type of the generated column.
    /// </summary>
    /// <remarks>
    /// Stored Columns take up space in the database, whereas virtual use more CPU when read.
    /// </remarks>
    public enum GeneratedColumnType
    {
        Default,
        /// <summary>
        /// The column value is computed when read.
        /// </summary>
        Virtual,
        /// <summary>
        /// The column value is written when the row is stored.
        /// </summary>
        Stored
    }
}