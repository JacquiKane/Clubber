namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class join33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sponsor", "BackGroundCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sponsor", "BackGroundCheck");
        }
    }
}
