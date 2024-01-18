using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax
{
    public class DeleteStatement: ISqlStatement
    {
        public EntityObject Entity { get; set; }

        public DeleteStatement(EntityObject entity)
        {
            Entity = entity;
        }

        public DeleteStatement(string? entityName)
        {
            Entity = new EntityObject(entityName);
        }
    }
}
