namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hobbies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentProfile", "Hobby1", c => c.String());
            AddColumn("dbo.StudentProfile", "Hobby2", c => c.String());
            AddColumn("dbo.StudentProfile", "Hobby3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentProfile", "Hobby3");
            DropColumn("dbo.StudentProfile", "Hobby2");
            DropColumn("dbo.StudentProfile", "Hobby1");
        }
    }
}
