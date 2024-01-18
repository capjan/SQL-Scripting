using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.Datatypes;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.Extensions;
using Core.SqlScripting.SQLite.Writer;
using Core.SqlScripting.SqlServer.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.StatementTest
{
    public class CreateTableTest
    {
        [Fact]
        public void BasicTest()
        {
            var createTable = new CreateTableStatement("User");
            createTable.AddColumn("Id", new SqlIntegerType()).AddPrimaryKey();
            createTable.AddColumn("Login", new SqlStringType(SqlStringLengthBehavior.Varying, 50)).AddNotNull();
            createTable.AddColumn("Password", new SqlStringType(SqlStringLengthBehavior.Varying, 50)).AddNotNull();

            var settings = new SqlWriterSettings()
            {
                Indent = " ",
                WriteNewLineAfterStatementTerminator = false
            };
            var sqlite = new SQLiteWriter(settings);
            var sql = sqlite.WriteToString(createTable, "");

            Assert.Equal("CREATE TABLE \"User\" ( \"Id\" INTEGER PRIMARY KEY, \"Login\" TEXT NOT NULL, \"Password\" TEXT NOT NULL );", sql);

            var sqlServer    = new SqlServerSqlWriter(settings);
            var sqlServerSql = sqlServer.WriteToString(createTable, "");

            Assert.Equal("CREATE TABLE [User] ( [Id] INT PRIMARY KEY, [Login] NVARCHAR(50) NOT NULL, [Password] NVARCHAR(50) NOT NULL );", sqlServerSql);

        }
    }
}
