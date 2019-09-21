namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeysInJoinTab : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StudentAndClub", "StudentID");
            CreateIndex("dbo.StudentAndClub", "ClubID");
            AddForeignKey("dbo.StudentAndClub", "ClubID", "dbo.Club", "ClubId", cascadeDelete: true);
            AddForeignKey("dbo.StudentAndClub", "StudentID", "dbo.Student", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAndClub", "StudentID", "dbo.Student");
            DropForeignKey("dbo.StudentAndClub", "ClubID", "dbo.Club");
            DropIndex("dbo.StudentAndClub", new[] { "ClubID" });
            DropIndex("dbo.StudentAndClub", new[] { "StudentID" });
        }
    }
}
