using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.SqlServer.Syntax
{
    public class SetIdentityInsertStatement: ISqlStatement
    {
        public EntityObject Entity { get; set; }
        public bool         Value  { get; set; }
    }
}
