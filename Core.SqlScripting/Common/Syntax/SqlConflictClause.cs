namespace Core.SqlScripting.Common.Syntax
{
    public enum SqlConflictClause
    {
        Default,
        Rollback,
        Abort,
        Fail,
        Ignore,
        Replace
    }
}