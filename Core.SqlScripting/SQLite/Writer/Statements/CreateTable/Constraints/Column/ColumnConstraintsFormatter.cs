using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints.Column;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable.Constraints.Column
{
    internal class ColumnConstraintsFormatter : ITextFormatter<IList<ISqlColumnConstraint>>
    {
        private readonly PrimaryKeyColumnConstraintFormatter _primaryKeyConstraintFormatter;

        public ColumnConstraintsFormatter(PrimaryKeyColumnConstraintFormatter primaryKeyConstraintFormatter)
        {
            _primaryKeyConstraintFormatter = primaryKeyConstraintFormatter;
        }

        public void Write(IList<ISqlColumnConstraint> value, TextWriter writer)
        {
            foreach (var constraint in value)
            {
                if (constraint is PrimaryKeyConstraint primaryKeyConstraint)
                    _primaryKeyConstraintFormatter.Write(primaryKeyConstraint, writer);
                else if (constraint is UniqueColumnConstraint)
                    writer.Write("UNIQUE");
                else if (constraint is NotNullColumnConstraint)
                    writer.Write("NOT NULL");
                else
                {
                    Debugger.Break();
                }
            }
        }
    }
}