namespace Core.SqlScripting.Enums
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