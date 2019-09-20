namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class join10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Club", "MeetingTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Club", "MeetingTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
