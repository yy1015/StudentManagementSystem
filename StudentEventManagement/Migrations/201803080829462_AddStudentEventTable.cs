namespace StudentEventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Maximum = c.Short(nullable: false),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venue", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentEvent", "VenueId", "dbo.Venue");
            DropIndex("dbo.StudentEvent", new[] { "VenueId" });
            DropTable("dbo.StudentEvent");
        }
    }
}
