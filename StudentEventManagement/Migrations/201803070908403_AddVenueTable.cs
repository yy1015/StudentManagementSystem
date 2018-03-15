namespace StudentEventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVenueTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Venue");
        }
    }
}
