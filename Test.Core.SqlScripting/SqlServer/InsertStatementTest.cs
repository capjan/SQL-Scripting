using System;
using Core.SqlScripting.Common.Syntax.Entity;
using Core.SqlScripting.Common.Syntax.Insert;
using Core.SqlScripting.Extensions;
using Core.SqlScripting.SqlServer.Syntax;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SqlServer
{
    public class InsertStatementTest
    {


        [Fact]
        public void BasicTest()
        {
            
            var insert = new InsertStatement("User")
            {
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


        class Reservations
        {
            public int      Id     { get; set; }
            public string   Token  { get; set; }
            public int      RoomId { get; set; }
            public DateTime Start  { get; set; }
            public DateTime End    { get; set; }
        }

        [Fact]
        public void TestReservationInsert()
        {
            var insert    = new InsertStatement("Reservations");
            insert.AddColumn("Id", 1);
            insert.AddColumn("Token", "TEST");
            insert.AddColumn("RoomId", 123);
            insert.AddColumn("Start", new DateTime(2020,11,10,7,8,0));
            insert.AddColumn("End", new DateTime(2020,11,10,7,8,0));

            var sql = Context.SingleStatementWriteTest(insert);
            Assert.Equal("INSERT INTO [Reservations] ( [Id], [Token], [RoomId], [Start], [End] )VALUES ( 1, 'TEST', 123, '2020-11-10 07:08:00.0000000', '2020-11-10 07:08:00.0000000' );", sql);
        }
    }
}
