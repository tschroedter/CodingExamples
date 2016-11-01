using System.Data.Entity.Migrations;

namespace MicroServices.DataAccess.Migrations
{
    public partial class InitialFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                        "dbo.Person",
                        c => new
                             {
                                 Id = c.Int(false,
                                            true),
                                 FirstName = c.String(false,
                                                      255),
                                 Surname = c.String(maxLength : 255),
                                 DateOfBirth = c.DateTime(false,
                                                          storeType : "date"),
                                 Sex = c.String(maxLength : 1),
                                 Email = c.String(maxLength : 255)
                             })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Person");
        }
    }
}