using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class DropTableStatementTest
    {
        [Theory]
        [InlineData("DROP TABLE IF EXISTS \"User\";", "User")]
        public void BasicTest(string expected, string tableName)
        {

            var entity = new EntityObject(tableName);
        
            var drop = new DropTableStatement(entity);

            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var delete = new DeleteStatement(tableName);
            var writer = new SQLiteWriter(settings);

            var sql = writer.WriteToString(drop);
            Assert.Equal(expected, sql);
        }
    }
}
