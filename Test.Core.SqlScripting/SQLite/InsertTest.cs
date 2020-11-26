using System;
using System.Collections.Generic;
using System.Text;
using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.Extensions;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class InsertTest
    {
        [Fact]
        public void BasicTest()
        {
            var insert = new InsertStatement("User");
            insert.AddColumn("Id", 1);
            insert.AddColumn("Name", "Jan Ruhlaender");
            insert.AddColumn("Mail", "jan.ruhlaender@dataport.de");

            var settings = new SqlWriterSettings {WriteNewLineAfterStatementTerminator = false};
            var writer = new SQLiteWriter(settings);

            var sql = writer.WriteToString(insert, " ");
            Assert.Equal("INSERT INTO \"User\" ( \"Id\", \"Name\", \"Mail\" ) VALUES ( 1, 'Jan Ruhlaender', 'jan.ruhlaender@dataport.de' );", sql);
        }
    }
}
