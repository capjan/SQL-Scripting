using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.SqlServer.Syntax
{
    public class SetIdentityInsertStatement(EntityObject entity) : ISqlStatement
    {
        public EntityObject Entity { get; set; } = entity;
        public bool         Value  { get; set; }
    }
}
