using Core.Extensions.TextRelated;
using Core.SqlScripting.SQLite.Syntax;
using Core.SqlScripting.SQLite.Syntax.Enums;
using Core.SqlScripting.SQLite.Syntax.Statements;
using Core.SqlScripting.SQLite.Syntax.Statements.ColumnDef;
using Core.SqlScripting.SQLite.Syntax.Statements.TableConstraints;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class CreateTableTest
    {

        [Fact]
        public void TestSQLGeneration()
        {
            var table = new CreateTableStatement()
            {
                Name = "User",
                Columns = {
                    new ColumnDefinition
                    {
                        Name = "Id",
                        Type = SQLiteTypeAffinity.Integer
                    },
                    new ColumnDefinition
                    {
                        Name = "FirstName",
                        Type = SQLiteTypeAffinity.Text
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
