using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Syntax.Statements.TableConstraints
{
    public class IndexedColumn
    {
        public string    ColumnName { get; set; }
        public SortOrder Order      { get; set; }

        public IndexedColumn(string name, SortOrder order = SortOrder.Default)
        {
            ColumnName = name;
            Order      = order;
        }
    }
}
