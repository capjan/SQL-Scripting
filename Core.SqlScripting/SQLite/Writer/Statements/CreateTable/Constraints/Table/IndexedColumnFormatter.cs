using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.CreateTable.TableConstraints;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SQLite.Syntax.Enums;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table
{
    /// <summary>
    /// Formats an Indexed Column. Used in the Primary Key Table Constraint
    /// </summary>
    internal class IndexedColumnFormatter: ITextFormatter<IndexedColumn>
    {
        private readonly SortOrderFormatter     _sortOrderFormatter;
        private readonly IdentifierFormatter _identifierFormatter;

        public IndexedColumnFormatter(SortOrderFormatter sortOrderFormatter, IdentifierFormatter identifierFormatter)
        {
            _sortOrderFormatter  = sortOrderFormatter;
            _identifierFormatter = identifierFormatter;
        }

        public void Write(IndexedColumn value, TextWriter writer)
        {
            
            _identifierFormatter.Write(value.ColumnName, writer);
            if (value.Order != SortOrder.Default)
            {
                writer.Write(" ");
                _sortOrderFormatter.Write(value.Order, writer);
            }
        }
    }
}