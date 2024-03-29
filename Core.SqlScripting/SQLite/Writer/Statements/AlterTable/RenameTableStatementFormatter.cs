﻿using System.IO;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.AlterTable;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer.Common.Entity;
using Core.SqlScripting.SqlServer.Writer;

namespace Core.SqlScripting.SQLite.Writer.Statements.AlterTable
{
    internal class RenameTableStatementFormatter: ITextFormatter<RenameTableStatement>
    {
        private readonly EntityObjectFormatter _entityFormatter;

        public RenameTableStatementFormatter(EntityObjectFormatter entityFormatter)
        {
            _entityFormatter = entityFormatter;
        }

        public void Write(RenameTableStatement value, TextWriter writer)
        {
            writer.Write("ALTER TABLE ");
            _entityFormatter.Write(value.Entity, writer);
            writer.Write(" RENAME TO ");
            var newEntity = new EntityObject(value.NewTableName);
            _entityFormatter.Write(newEntity, writer);
        }
    }
}
