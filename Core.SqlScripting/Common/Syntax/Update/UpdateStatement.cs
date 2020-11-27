using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Enums;

namespace Core.SqlScripting.Common.Syntax.Update
{
    /// <summary>
    /// Update Statement
    /// </summary>
    public class UpdateStatement
    {
        public QualifiedEntityObject   QualifiedEntity { get; set; }
        public ConflictClause          OnConflictRule  { get; set; }
        public IList<UpdateAssignment> Assignments     { get; set; }
        public IExpression             WhereExpression { get; set; }
    }
}
