using System;
using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Writer.Common.Entity;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SqlServer.Writer;

namespace Core.SqlScripting.SQLite.Writer.Statements
{
    internal class PragmaStatementFormatter: ITextFormatter<PragmaStatement>
    {
        private readonly EntityObjectFormatter _entityObjectFormatter;
        private readonly PragmaValueFormatter  _pragmaValueFormatter;

        public PragmaStatementFormatter(EntityObjectFormatter entityObjectFormatter, PragmaValueFormatter pragmaValueFormatter)
        {
            _entityObjectFormatter     = entityObjectFormatter;
            _pragmaValueFormatter = pragmaValueFormatter;
        }

        public void Write(PragmaStatement value, TextWriter writer)
        {
            writer.Write("PRAGMA ");
            _entityObjectFormatter.Write(value.Entity, writer);
            if (value.Value != null)
            {
                writer.Write(" = ");
                _pragmaValueFormatter.Write(value.Value, writer);
            }
        }
    }

    internal class PragmaValueFormatter : ITextFormatter<IPragmaValue>
    {
        public void Write(IPragmaValue value, TextWriter writer)
        {
            if (value is BooleanPragmaValue boolValue)
                writer.Write(boolValue.Value ? "1" : "0");
            else 
                throw new NotSupportedException();
            
        }
    }
}
