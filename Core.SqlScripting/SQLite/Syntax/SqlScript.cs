using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax;

namespace Core.SqlScripting.SQLite.Syntax
{
    public class SqlScript
    {
        public IList<ISqlStatement> Statements { get; } = new List<ISqlStatement>();
    }
}
