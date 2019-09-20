namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class join9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "ClubID", "dbo.Club");
            DropIndex("dbo.Student", new[] { "ClubID" });
            DropColumn("dbo.Student", "ClubID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "ClubID", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "ClubID");
            AddForeignKey("dbo.Student", "ClubID", "dbo.Club", "ClubId", cascadeDelete: true);
        }
    }
}
