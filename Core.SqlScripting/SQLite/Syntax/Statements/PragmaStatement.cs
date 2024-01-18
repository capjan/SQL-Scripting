using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.SQLite.Syntax.Statements
{
    public class PragmaStatement: ISqlStatement
    {
        public PragmaStatement(EntityObject entity, IPragmaValue value)
        {
            Entity = entity;
            Value = value;
        }

        public EntityObject Entity { get; set; }
        public IPragmaValue Value  { get; set; }
    }

    public interface IPragmaValue
    {

    }

    public class BooleanPragmaValue : IPragmaValue
    {
        public bool Value { get; set; }
    }
}
