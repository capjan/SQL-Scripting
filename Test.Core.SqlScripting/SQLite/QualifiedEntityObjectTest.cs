using System;
using System.Collections.Generic;
using System.Text;
using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Writer;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class QualifiedEntityObjectTest
    {
        public void BasicTest()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };
            var writer = new SQLiteWriter(settings);
            var qualifiedEntityObject = new QualifiedEntityObject();

           // var sql = writer.WriteToString(qualifiedEntityObject);

        }
    }
}
