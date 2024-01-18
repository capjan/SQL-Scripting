using Core.SqlScripting.Common.Syntax;

namespace Core.SqlScripting.SQLite.Syntax.Statements
{
    /// <summary>
    /// The VACUUM command rebuilds the database file, repacking it into a minimal amount of disk space.
    /// </summary>
    /// <remarks>This is a SQLite only statement.</remarks>
    public class VacuumStatement : ISqlStatement
    {
        /// <summary>
        /// Optional: By default, VACUUM only works only on the main database. Use the Schema name to apply the vacuum onto an attached database.
        /// </summary>
        public string? SchemaName { get; set; }

        /// <summary>
        /// INTO filename clause. By default Vacuum is applied to the Database itself. If you set a OutputPath the result is written to the given file and the main database remains untouched.
        /// </summary>
        public string? OutputPath { get; set; }

    }
}
