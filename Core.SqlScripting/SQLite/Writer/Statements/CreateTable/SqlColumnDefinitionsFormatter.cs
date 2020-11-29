using System.Collections.Generic;
using System.IO;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints;
using Core.SqlScripting.Common.Writer.Common;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    internal class SqlColumnDefinitionsFormatter : ITextFormatter<IList<ColumnDefinition>>
    {
        //private readonly string                                      _indent;
        private readonly ITextFormatter<string>                      _identifierFormatter;
        private readonly ITextFormatter<IList<ISqlColumnConstraint>> _constraintFormatter;
        private readonly ISqlTypeFormatter                           _typeFormatter;

        public SqlColumnDefinitionsFormatter(
            ITextFormatter<string>                      identifierFormatter, 
            ITextFormatter<IList<ISqlColumnConstraint>> constraintFormatter, 
            ISqlTypeFormatter                           typeFormatter)
        {
            _identifierFormatter = identifierFormatter;
            _constraintFormatter = constraintFormatter;
            _typeFormatter       = typeFormatter;
        }

        public void Write(IList<ColumnDefinition> value, TextWriter writer)
        {
            for (var index = 0; index < value.Count; index++)
            {
                var colDef = value[index];
                _identifierFormatter.Write(colDef.Name, writer);
                writer.Write(" ");
                _typeFormatter.Write(colDef.Type, writer);
                if (colDef.Constraints.Count != 0)
                {
                    writer.Write(" ");
                    _constraintFormatter.Write(colDef.Constraints, writer);
                }
                if (index < (value.Count-1)) writer.Write(", ");
            }
        }
    }
}