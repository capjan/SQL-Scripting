using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.Update
{
    /// <summary>
    /// Update Statement
    /// </summary>
    public class UpdateStatement: ISqlStatement
    {
        public QualifiedEntityObject   QualifiedEntity { get; set; }
        public SqlConflictClause          OnConflictRule  { get; set; } = SqlConflictClause.Default;
        public IList<IUpdateAssignment> Assignments     { get; set; } = new List<IUpdateAssignment>();
        public IExpression             WhereExpression { get; set; }
    }
}
