using System.Collections.Generic;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef;
using Core.SqlScripting.SQLite.Syntax.Statements.TableConstraints;

namespace Core.SqlScripting.SQLite.Syntax.Statements
{
    public class CreateTableStatement: ISqlStatement
    {
        public bool                    IsTemporary      { get; set; }
        public bool                    IfNotExits       { get; set; }
        public string                  Schema           { get; set; }
        public string                  Name             { get; set; }
        public bool                    WithoutRowId     { get; set; }
        public IList<ColumnDefinition> Columns          { get; } = new List<ColumnDefinition>();
        public IList<TableConstraint>  TableConstraints { get; } = new List<TableConstraint>();
    }
}