using System.IO;
using System.Text;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.SqlServer.Writer;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    class Context
    {
        public static ISqlWriter CreateSingleStatementWriter()
        {
            var settings = new SqlServerSqlWriterSettings
            {
                CommandTerminator = ";"
            };
            return new SqlServerSqlWriter(settings);
        }

        public static string SingleStatementWriteTest(ISqlStatement statement, string newLine = "")
        {
            var       writer       = CreateSingleStatementWriter();
            var       sb           = new StringBuilder();
            using var stringWriter = new StringWriter(sb) {NewLine = newLine};
            writer.Write(statement, stringWriter);
            return sb.ToString();
        }
    }
}
