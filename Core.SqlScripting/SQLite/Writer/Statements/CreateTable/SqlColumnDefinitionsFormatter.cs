using System.Collections.Generic;
using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef.Constraints;
using Core.SqlScripting.Common.Writer.Common;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    internal class SqlColumnDefinitionFormatter : ITextFormatter<ColumnDefinition>
    {
        //private readonly string                                      _indent;
        private readonly ITextFormatter<string>                      _identifierFormatter;
        private readonly ITextFormatter<IList<ISqlColumnConstraint>> _constraintFormatter;
        private readonly ISqlTypeFormatter                           _typeFormatter;

        public SqlColumnDefinitionFormatter(ITextFormatter<string> identifierFormatter, ITextFormatter<IList<ISqlColumnConstraint>> constraintFormatter, ISqlTypeFormatter typeFormatter)
        {
            _identifierFormatter = identifierFormatter;
            _constraintFormatter = constraintFormatter;
            _typeFormatter  = typeFormatter;
        }

        public void Write(ColumnDefinition value, TextWriter writer)
        {
            _identifierFormatter.Write(value.Name, writer);
            writer.Write(" ");
            _typeFormatter.Write(value.Type, writer);
            if (value.Constraints.Count != 0)
            {
                writer.Write(" ");
                _constraintFormatter.Write(value.Constraints, writer);
            }
        }
    }

    internal class SqlColumnDefinitionsFormatter : ITextFormatter<IList<ColumnDefinition>>
    {
        private readonly ITextFormatter<ColumnDefinition> _columnDefinitionFormatter;

        public SqlColumnDefinitionsFormatter(ITextFormatter<ColumnDefinition> columnDefinitionFormatter)
        {
            _columnDefinitionFormatter = columnDefinitionFormatter;
        }

        public void Write(IList<ColumnDefinition> value, TextWriter writer)
        {
            for (var index = 0; index < value.Count; index++)
            {
                var colDef = value[index];
                _columnDefinitionFormatter.Write(colDef, writer);
                if (index < (value.Count-1)) writer.Write(", ");
            }
        }
    }
}