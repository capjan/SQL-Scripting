using System.Collections.Generic;
using System.IO;
using Core.SqlScripting.SQLite.Syntax.Statements.TableConstraints;
using Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Table;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    internal class TableConstraintsFormatter: ITextFormatter<IList<TableConstraint>>
    {

        private readonly PrimaryOrUniqueTableConstraintsFormatter _primaryKeyFormatter;

        public TableConstraintsFormatter(PrimaryOrUniqueTableConstraintsFormatter primaryKeyFormatter)
        {
            _primaryKeyFormatter = primaryKeyFormatter;
        }

        public void Write(IList<TableConstraint> value, TextWriter writer)
        {
            foreach (var tableConstraint in value)
            {
                if (tableConstraint is TablePrimaryOrUniqueKeyConstraint primaryKeyOrUniqueConstraint)
                    _primaryKeyFormatter.Write(primaryKeyOrUniqueConstraint, writer);
            }
        }
    }
}
