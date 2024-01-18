using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class PragmaTest
    {
        [Fact]
        public void BasicTest()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var writer = new SQLiteWriter(settings);

            var pragma = new PragmaStatement(new EntityObject("auto_vacuum"), new BooleanPragmaValue {Value = true});

            var sql = writer.WriteToString(pragma);
            Assert.Equal("PRAGMA \"auto_vacuum\" = 1;", sql);

        }
    }
}
