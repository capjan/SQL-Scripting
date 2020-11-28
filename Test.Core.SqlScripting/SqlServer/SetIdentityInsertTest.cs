using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.SqlServer.Syntax;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class SetIdentityInsertTest
    {
        [Fact]
        public void BasicTest()
        {
            var entity = new EntityObject("User");
            var setIdentityInsert = new SetIdentityInsertStatement
            {
                Entity = entity,
                Value  = false
            };
            var sql1 = Context.SingleStatementWriteTest(setIdentityInsert);
            Assert.Equal("SET IDENTITY_INSERT [User] OFF;", sql1);
            setIdentityInsert.Value = true;
            var sql2 = Context.SingleStatementWriteTest(setIdentityInsert);
            Assert.Equal("SET IDENTITY_INSERT [User] ON;", sql2);
        }
    }
}
