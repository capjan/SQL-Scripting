namespace Core.SqlScripting.Common.Writer.Identifier
{
    public enum IdentifierQuoteStyle
    {
        /// <summary>
        /// Default SQL Identifier Style via double quotes. Used by SQLite, Postgres
        /// </summary>
        Default,
        /// <summary>
        /// Microsoft Style used in T-SQL for the products SQL-Server and Access.
        /// </summary>
        Microsoft,
        /// <summary>
        /// Quotation Style used by MySQL Databases.
        /// </summary>
        MySQL
    }
}