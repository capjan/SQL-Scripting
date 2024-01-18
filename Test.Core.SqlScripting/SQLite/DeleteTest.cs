using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class DeleteTest
    {
        [Theory]
        [InlineData("DELETE FROM \"User\";", "User")]
        public void BasicTest(string expected, string tableName)
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var delete = new DeleteStatement(tableName);
            var writer = new SQLiteWriter(settings);
            
            var sql    = writer.WriteToString(delete);
            Assert.Equal(expected, sql);
        }
    }
}
