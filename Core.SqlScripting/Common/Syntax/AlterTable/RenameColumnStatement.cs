using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.Column;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public class RenameColumnStatement : AlterTableStatement
    {
        public RenameColumnStatement(EntityObject entity, ColumnName oldColumnName, ColumnName newColumnName) : base(entity)
        {
            OldColumnName = oldColumnName;
            NewColumnName = newColumnName;
        }

        public RenameColumnStatement(string tableName, string oldColumnName, string newColumnName) : this(new EntityObject(tableName), new ColumnName(oldColumnName), new ColumnName(newColumnName))
        { }

        public ColumnName OldColumnName { get; }
        public ColumnName NewColumnName { get; }
    }
}
