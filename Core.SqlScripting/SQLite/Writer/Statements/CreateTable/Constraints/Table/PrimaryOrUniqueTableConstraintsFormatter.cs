using System.IO;
using System.Linq;
using Core.Extensions.CollectionRelated;
using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SQLite.Syntax.Statements.TableConstraints;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table
{
    internal class PrimaryOrUniqueTableConstraintsFormatter: ITextFormatter<TablePrimaryOrUniqueKeyConstraint>
    {
        private readonly string                  _indent;
        private readonly IndexKeyTypeFormatter        _indexKeyTypeFormatter;
        private readonly IndexedColumnFormatter  _indexColumnFormatter;
        private readonly ConflictClauseFormatter _conflictClauseFormatter;
        private readonly IdentifierFormatter  _identifierFormatter;

        public PrimaryOrUniqueTableConstraintsFormatter(IndexKeyTypeFormatter indexKeyTypeFormatter, IndexedColumnFormatter indexColumnFormatter, ConflictClauseFormatter conflictClauseFormatter, string indent, IdentifierFormatter identifierFormatter)
        {
            _indexKeyTypeFormatter         = indexKeyTypeFormatter;
            _indexColumnFormatter     = indexColumnFormatter;
            _conflictClauseFormatter  = conflictClauseFormatter;
            _indent                   = indent;
            _identifierFormatter = identifierFormatter;
        }

        public void Write(TablePrimaryOrUniqueKeyConstraint value, TextWriter writer)
        {
            writer.WriteLine(",");
            writer.Write(_indent);
            if (!string.IsNullOrWhiteSpace(value.Name))
            {
                writer.Write("CONSTRAINT ");
                _identifierFormatter.Write(value.Name, writer);
                writer.Write(" ");
            }
            _indexKeyTypeFormatter.Write(value.KeyType, writer);
            writer.Write(" ( ");
            writer.Write(value.Columns.Select(i=> _indexColumnFormatter.WriteToString(i)).ToSeparatedString(", "));
            writer.Write(" )");
            _conflictClauseFormatter.Write(value.ConflictClause, writer);
        }
    }
}
