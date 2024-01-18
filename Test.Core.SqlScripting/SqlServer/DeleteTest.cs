using Core.SqlScripting.Common.Syntax;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class DeleteTest
    {
        [Theory]
        [InlineData("DELETE FROM [User];", "User")]
        public void BasicTest(string expected, string tableName)
        {
            var delete = new DeleteStatement(tableName);
            var sql    = Context.SingleStatementWriteTest(delete);
            Assert.Equal(expected, sql);
        }
    }
}
