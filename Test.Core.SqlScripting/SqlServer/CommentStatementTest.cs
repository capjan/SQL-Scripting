using Core.SqlScripting.Common.Syntax.Comment;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class CommentStatementTest
    {

        [Theory]
        [InlineData("-- Hello", "Hello")]
        public void TestComments(string expected, string comment)
        {
            Assert.Equal(expected, Context.SingleStatementWriteTest(new CommentStatement(comment)));
        }
    }
}
