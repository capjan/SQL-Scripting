using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax.CreateTable;
using Core.SqlScripting.Common.Syntax.CreateTable.ColumnDef;
using Core.SqlScripting.Common.Syntax.CreateTable.TableConstraints;
using Core.SqlScripting.Common.Syntax.Datatypes;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.SQLite.Syntax;
using Core.SqlScripting.SQLite.Syntax.Enums;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class CreateTableTest
    {

        [Fact]
        public void TestSQLGeneration()
        {
            var table = new CreateTableStatement("User")
            {
                Columns = {
                    new ColumnDefinition
                    {
                        Name = "Id",
                        Type = new SqlIntegerType()
                    },
                    new ColumnDefinition
                    {
                        Name = "FirstName",
                        Type = new SqlStringType(SqlStringLengthBehavior.Varying, 50)
                    }
                },
                TableConstraints = { 
                    new TablePrimaryOrUniqueKeyConstraint {
                        KeyType        = KeyType.PrimaryKey,
                        ConflictClause = default,
                        Name           = "PK_User",
                        Columns = {
                            new IndexedColumn( "Id", SortOrder.Asc), 
                            new IndexedColumn("Per")
                        }
                    },
                    new TablePrimaryOrUniqueKeyConstraint {
                        KeyType = KeyType.PrimaryKey,
                        ConflictClause = default,
                        Columns = {
                            new IndexedColumn("Id", SortOrder.Asc), 
                            new IndexedColumn( "Per"),
                        }
                    }
                }
            };

            var writer = new SQLiteWriter();
            var output = writer.WriteToString(table);
            Assert.True(output.Length >0);

        }
    }
}
