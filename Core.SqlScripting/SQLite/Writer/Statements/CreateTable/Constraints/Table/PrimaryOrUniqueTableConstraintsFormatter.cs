using System.IO;
using System.Linq;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.CreateTable.TableConstraints;
using Core.SqlScripting.Common.Writer.Common;
using Core.SqlScripting.Common.Writer.Identifier;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table
{
    internal class PrimaryOrUniqueTableConstraintsFormatter: ITextFormatter<TablePrimaryOrUniqueKeyConstraint>
    {
        private readonly string                  _indent;
        private readonly IndexKeyTypeFormatter        _indexKeyTypeFormatter;
        private readonly IndexedColumnFormatter  _indexColumnFormatter;
        private readonly OnConflictClauseFormatter _onConflictClauseFormatter;
        private readonly IdentifierFormatter  _identifierFormatter;

        public PrimaryOrUniqueTableConstraintsFormatter(IndexKeyTypeFormatter indexKeyTypeFormatter, IndexedColumnFormatter indexColumnFormatter, OnConflictClauseFormatter onConflictClauseFormatter, string indent, IdentifierFormatter identifierFormatter)
        {
            _indexKeyTypeFormatter         = indexKeyTypeFormatter;
            _indexColumnFormatter     = indexColumnFormatter;
            _onConflictClauseFormatter  = onConflictClauseFormatter;
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
            writer.Write(value.Columns.Select(i=> string.Join(", ", _indexColumnFormatter.WriteToString(i))));
            writer.Write(" )");
            _onConflictClauseFormatter.Write(value.ConflictClause, writer);
        }
    }
}
