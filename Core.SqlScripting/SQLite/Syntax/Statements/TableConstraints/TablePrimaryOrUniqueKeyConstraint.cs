using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.TableConstraints
{
    public class TablePrimaryOrUniqueKeyConstraint: TableConstraint
    {
        public KeyType              KeyType        { get; set; } = KeyType.PrimaryKey;
        public IList<IndexedColumn> Columns        { get; set; } = new List<IndexedColumn>();
        public SqlConflictClause       ConflictClause { get; set; } = SqlConflictClause.Default;
    }
}
