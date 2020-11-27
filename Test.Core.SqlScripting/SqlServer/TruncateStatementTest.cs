using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.SqlServer.Syntax;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class TruncateStatementTest
    {
        [Theory]
        [InlineData("TRUNCATE TABLE [User];", "User")]
        [InlineData("TRUNCATE TABLE [dbo].[User];", "User", "dbo")]
        [InlineData("TRUNCATE TABLE [Master].[dbo].[User];", "User", "dbo", "Master")]
        public void WriteValidCommand(string expected, string tableName, string schemaName = null, string databaseName = null)
        {
            var entity = new EntityObject
            {
                DatabaseName = databaseName,
                SchemaName   = schemaName,
                Name    = tableName
            };
            var truncateTable = new TruncateTableStatement(entity);

            var result = Context.SingleStatementWriteTest(truncateTable);
            Assert.Equal(expected, result);
        }

    }
}
