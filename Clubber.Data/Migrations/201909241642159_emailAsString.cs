namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailAsString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "ContactEMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "ContactEMail");
        }
    }
}
