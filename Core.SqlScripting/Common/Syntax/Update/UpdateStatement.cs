using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Enums;

namespace Core.SqlScripting.Common.Syntax.Update
{
    /// <summary>
    /// Update Statement
    /// </summary>
    public class UpdateStatement: ISqlStatement
    {
        public QualifiedEntityObject   QualifiedEntity { get; set; }
        public ConflictClause          OnConflictRule  { get; set; }
        public IList<UpdateAssignment> Assignments     { get; set; } = new List<UpdateAssignment>();
        public IExpression             WhereExpression { get; set; }
    }
}
