using Core.Extensions.TextRelated;
using Core.SqlScripting.Common.Syntax;
using Core.SqlScripting.Common.Syntax.Column;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Syntax.Update;
using Core.SqlScripting.Common.Writer;
using Core.SqlScripting.SQLite.Writer;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class UpdateTest
    {
        [Fact]
        public void UpdateWithSetAndWhereClause()
        {
            var settings = new SqlWriterSettings
            {
                WriteNewLineAfterStatementTerminator = false
            };
            var writer = new SQLiteWriter(settings);
            var entity = new EntityObject
            {
                Name = "User"
            };
            var qualifiedEntityObject = new QualifiedEntityObject
            {
                Entity = entity
            };

            var update = new UpdateStatement
            {
                QualifiedEntity = qualifiedEntityObject,
                WhereExpression = new RawExpression
                {
                    Content = "\"Name\" LIKE '%Th'"
                }

            };
            update.Assignments.Add(new UpdateAssignment
            {
                ColumnOrColumnNameList = new ColumnName{Name = "Name"},
                Value = new RawExpression
                {
                    Content = "'Jan'"
                }
            });

            var sql = writer.WriteToString(update);
            Assert.Equal("UPDATE \"User\" SET \"Name\" = 'Jan' WHERE \"Name\" LIKE '%Th';", sql);

        }

        [Fact]
        public void UpdateWithoutWhereClause()
        {
            var settings              = new SqlWriterSettings {WriteNewLineAfterStatementTerminator = false};
            var writer                = new SQLiteWriter(settings);
            var entity                = new EntityObject {Name                = "User"};
            var qualifiedEntityObject = new QualifiedEntityObject { Entity    = entity };
            var update                = new UpdateStatement {QualifiedEntity = qualifiedEntityObject};
            update.Assignments.Add(new UpdateAssignment
            {
                ColumnOrColumnNameList = new ColumnName{Name = "Name"},
                Value = new RawExpression
                {
                    Content = "'Jan'"
                }
            });

            var sql = writer.WriteToString(update);
            Assert.Equal("UPDATE \"User\" SET \"Name\" = 'Jan';", sql);

        }

        
        [Fact]
        public void UpdateWithOnConflictClauseButWithoutWhereClause()
        {
            var settings              = new SqlWriterSettings {WriteNewLineAfterStatementTerminator = false};
            var writer                = new SQLiteWriter(settings);
            var entity                = new EntityObject {Name                = "User"};
            var qualifiedEntityObject = new QualifiedEntityObject { Entity    = entity, Alias = "u"};

            var update = new UpdateStatement
            {
                QualifiedEntity = qualifiedEntityObject, 
                OnConflictRule = SqlConflictClause.Rollback
            };

            // update.OnConflictRule = Core.SqlScripting.Common.Syntax.ConflictClause.Rollback;

            update.Assignments.Add(new UpdateAssignment
            {
                ColumnOrColumnNameList = new ColumnName{Name = "Name"},
                Value = new RawExpression
                {
                    Content = "'Jan'"
                }
            });

            var sql = writer.WriteToString(update);
            Assert.Equal("UPDATE OR ROLLBACK \"User\" AS \"u\" SET \"Name\" = 'Jan';", sql);

        }
    }
}
