namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedstudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "StudentFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Student", "StudentLastName", c => c.String(nullable: false));
            AddColumn("dbo.Student", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Student", "ParentFirstName", c => c.String());
            AddColumn("dbo.Student", "ParentLastName", c => c.String());
            DropColumn("dbo.Student", "FirstName");
            DropColumn("dbo.Student", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Student", "ParentLastName");
            DropColumn("dbo.Student", "ParentFirstName");
            DropColumn("dbo.Student", "DOB");
            DropColumn("dbo.Student", "StudentLastName");
            DropColumn("dbo.Student", "StudentFirstName");
        }
    }
}
