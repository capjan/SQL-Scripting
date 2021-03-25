using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.Common.Syntax.Entity;

namespace Core.SqlScripting.Common.Syntax.AlterTable
{
    public class AddColumnStatement : AlterTableStatement
    {
        public ColumnDefinition Definition { get; }

        public AddColumnStatement(EntityObject entity, ColumnDefinition definition) : base(entity)
        {
            Definition = definition;
        }
    }
}
