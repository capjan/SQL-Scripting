using Core.SqlScripting.SqlServer.Syntax;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class InsertStatementTest
    {
        [Fact]
        public void BasicTest()
        {
            var insert = new InsertStatement
            {
                Entity =
                {
                    TableName = "User"
                },
                Assignments =
                {
                    new ColumnAssignment<int>("Id", 6),
                    new ColumnAssignment<string>("FirstName", "Jan"),
                    new ColumnAssignment<string>("LastName", "Ruhlaender")
                }
            };

            var sql = Context.SingleStatementWriteTest(insert, " ");
            
            Assert.Equal("INSERT INTO [User] ( [Id], [FirstName], [LastName] ) VALUES ( 6, 'Jan', 'Ruhlaender' ); ", sql);
        }
    }
}
