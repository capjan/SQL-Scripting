using System;
using System.Collections.Generic;
using System.Text;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.StatementTest
{
    public class CreateTableTest
    {
        [Fact]
        public void BasicTest()
        {
            var createTable = new CreateTableStatement("User");

            var id = new ColumnDefinition();


            createTable.Columns.Add(new ColumnDefinition());
            createTable.Columns.Add(new ColumnDefinition()
            {

            });
           // createTable.

        }
    }
}
