using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.Common.Syntax.CreateTable.TableConstraints;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.CreateTable
{
    public class CreateTableStatement: ISqlStatement
    {
        public bool                    IsTemporary      { get; set; }
        public bool                    IfNotExits       { get; set; }
        public EntityObject            Entity           { get; }
        public bool                    WithoutRowId     { get; set; }
        public IList<ColumnDefinition> Columns          { get; } = new List<ColumnDefinition>();
        public IList<TableConstraint>  TableConstraints { get; } = new List<TableConstraint>();

        public CreateTableStatement(string tableName)
        {
            Entity = new EntityObject(tableName);
        }

        public CreateTableStatement(EntityObject entity)
        {
            Entity = entity;
        }
    }
}