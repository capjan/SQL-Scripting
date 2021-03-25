using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax.AlterTable;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class AlterTableTest
    {
        [Theory]
        [InlineData("ALTER TABLE \"OldName\" RENAME TO \"NewName\";", "OldName", "NewName")]
        public void RenameTableTest(string expected, string tableName, string newTableName)
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var statement = new RenameTableStatement(tableName, newTableName);
            var writer    = new SQLiteWriter(settings);
            var actual    = writer.WriteToString(statement);
            
            Assert.Equal(expected, actual);
            
        }
    }
}
