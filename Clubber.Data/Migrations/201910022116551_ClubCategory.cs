namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClubCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Club", "ClubType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Club", "ClubType");
        }
    }
}
