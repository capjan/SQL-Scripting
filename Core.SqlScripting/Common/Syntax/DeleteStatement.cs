using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax
{
    public class DeleteStatement: ISqlStatement
    {
        public EntityObject Entity { get; set; }

        public DeleteStatement()
        {
            Entity = new EntityObject();
        }

        public DeleteStatement(string tableName)
        {
            Entity = new EntityObject
            {
                Name = tableName
            };
        }
    }
}
