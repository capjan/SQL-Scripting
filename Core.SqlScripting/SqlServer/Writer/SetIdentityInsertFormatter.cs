using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.SqlScripting.SqlServer.Syntax;
using Core.SqlScripting.SqlServer.Writer.Helper;
using Core.Text.Formatter;

namespace Core.SqlScripting.SqlServer.Writer
{
    internal class SetIdentityInsertFormatter: ITextFormatter<SetIdentityInsertStatement>
    {
        private readonly EntityObjectFormatter _entityFormatter;
        private readonly OnOffFormatter        _onOffFormatter;

        public SetIdentityInsertFormatter(EntityObjectFormatter entityFormatter, OnOffFormatter onOffFormatter)
        {
            _entityFormatter     = entityFormatter;
            _onOffFormatter = onOffFormatter;
        }

        public void Write(SetIdentityInsertStatement value, TextWriter writer)
        {
            writer.Write("SET IDENTITY_INSERT ");
            _entityFormatter.Write(value.Entity, writer);
            writer.Write(" ");
            _onOffFormatter.Write(value.Value, writer); 
        }
    }
}
