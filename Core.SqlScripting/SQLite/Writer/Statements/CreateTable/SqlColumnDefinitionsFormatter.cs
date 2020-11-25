using System.Collections.Generic;
using System.IO;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef.Constraints;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements.CreateTable
{
    public class SqlColumnDefinitionsFormatter : ITextFormatter<IList<ColumnDefinition>>
    {
        private readonly string                                      _indent;
        private readonly ITextFormatter<string>                      _identifierFormatter;
        private readonly ITextFormatter<IList<ISqlColumnConstraint>> _constraintFormatter;

        public SqlColumnDefinitionsFormatter(
            ITextFormatter<string>                      identifierFormatter, 
            ITextFormatter<IList<ISqlColumnConstraint>> constraintFormatter, 
            string                                      indent)
        {
            _identifierFormatter = identifierFormatter;
            _constraintFormatter = constraintFormatter;
            _indent              = indent;
        }

        public void Write(IList<ColumnDefinition> value, TextWriter writer)
        {
            for (var index = 0; index < value.Count; index++)
            {
                var colDef = value[index];
                writer.Write(_indent);
                _identifierFormatter.Write(colDef.Name, writer);
                writer.Write(" ");
                writer.Write(colDef.Type);
                if (colDef.Constraints.Count != 0)
                {
                    
                    _constraintFormatter.Write(colDef.Constraints, writer);
                }
                if (index < (value.Count-1)) writer.WriteLine(",");
            }
        }
    }
}