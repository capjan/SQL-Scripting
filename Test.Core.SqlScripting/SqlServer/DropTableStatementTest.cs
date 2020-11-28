using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.SqlServer.Syntax;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class DropTableStatementTest
    {
        [Theory]
        [InlineData("DROP TABLE IF EXISTS [User];", "User")]
        public void BasicTest(string expected, string tableName)
        {
            var entity = new EntityObject(tableName);
            var drop = new DropTableStatement(entity);
            var sql  = Context.SingleStatementWriteTest(drop);
            Assert.Equal(expected, sql);
        }
    }
}
