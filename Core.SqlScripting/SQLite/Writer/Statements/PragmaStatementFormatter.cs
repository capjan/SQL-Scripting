using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SqlServer.Writer;
using Core.Text.Formatter;

namespace Core.SqlScripting.SQLite.Writer.Statements
{
    internal class PragmaStatementFormatter: ITextFormatter<PragmaStatement>
    {
        private readonly EntityObjectFormatter _entityObjectFormatter;

        public PragmaStatementFormatter(EntityObjectFormatter entityObjectFormatter)
        {
            _entityObjectFormatter = entityObjectFormatter;
        }

        public void Write(PragmaStatement value, TextWriter writer)
        {
            writer.Write("PRAGMA ");
            _entityObjectFormatter.Write(value.Entity, writer);
            throw new NotImplementedException();
        }
    }

    internal class PragamaValueFormatter : ITextFormatter<IPragmaValue>
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
