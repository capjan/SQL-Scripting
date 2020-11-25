namespace Core.SqlScripting.SQLite.Syntax.Enums
{
    public enum ConflictClause
    {
        Default,
        Rollback,
        Abort,
        Fail,
        Ignore,
        Replace
    }
}