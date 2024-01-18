using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class VacuumStatementTest
    {
        [Fact]
        public void BasicTest()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var writer = new SQLiteWriter(settings);
            var vacuum = new VacuumStatement();
            var sql    = writer.WriteToString(vacuum);
            Assert.Equal("VACUUM;", sql);
        }

        [Fact]
        public void VacuumWithSchema()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var writer = new SQLiteWriter(settings);
            var vacuum = new VacuumStatement
            {
                SchemaName = "Users"
            };
            var sql    = writer.WriteToString(vacuum);
            Assert.Equal("VACUUM \"Users\";", sql);
        }

        [Fact]
        public void VacuumWithSchemaAndFilename()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var writer = new SQLiteWriter(settings);
            var vacuum = new VacuumStatement
            {
                SchemaName = "Users",
                OutputPath = "C:\\backup\\myDB.db"
            };
            var sql = writer.WriteToString(vacuum);
            Assert.Equal("VACUUM \"Users\" INTO 'C:\\backup\\myDB.db';", sql);
        }

        [Fact]
        public void VacuumWithFilename()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };

            var writer = new SQLiteWriter(settings);
            var vacuum = new VacuumStatement
            {

                OutputPath = "~/backups/linux.db"
            };
            var sql = writer.WriteToString(vacuum);
            Assert.Equal("VACUUM INTO '~/backups/linux.db';", sql);
        }

    }
}
