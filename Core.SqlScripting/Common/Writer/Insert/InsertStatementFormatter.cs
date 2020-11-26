using System.IO;
using System.Linq;
using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Common.Writer.Identifier;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;

namespace Core.SqlScripting.Common.Writer.Insert
{
    internal class InsertStatementFormatter: ITextFormatter<InsertStatement>
    {
        private readonly EntityObjectFormatter          _entityFormatter;
        private readonly IdentifierFormatter            _identifierFormatter;
        private readonly SeparatorFormatter<string>     _separatorFormatter = new SeparatorFormatter<string>();
        private readonly ColumnAssignmentValueFormatter _columnAssignmentValueFormatter;

        public InsertStatementFormatter(EntityObjectFormatter entityFormatter, IdentifierFormatter identifierFormatter, ColumnAssignmentValueFormatter columnAssignmentValueFormatter)
        {
            _entityFormatter                     = entityFormatter;
            _identifierFormatter                 = identifierFormatter;
            _columnAssignmentValueFormatter = columnAssignmentValueFormatter;
        }

        public void Write(InsertStatement value, TextWriter writer)
        {
            writer.Write("INSERT INTO ");
            _entityFormatter.Write(value.Entity, writer);
            writer.Write(" ( ");
            
            var columnList = value.Assignments.Select(i => i.ColumnName)
                                  .Select(i => _identifierFormatter.WriteToString(i)).ToArray();
            _separatorFormatter.Write(columnList, writer);
  
            writer.WriteLine(" )");
            writer.Write("VALUES ( ");
            var valueList = value.Assignments.Select(i => _columnAssignmentValueFormatter.WriteToString(i)).ToArray();
            _separatorFormatter.Write(valueList, writer);
            writer.Write(" )");


        }
    }
}
