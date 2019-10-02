namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoDOB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Student", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "DOB", c => c.DateTime(nullable: false));
            DropColumn("dbo.Student", "Age");
        }
    }
}
