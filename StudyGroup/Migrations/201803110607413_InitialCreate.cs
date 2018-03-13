namespace StudyGroup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        GroupLeader = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.GroupStatus",
                c => new
                    {
                        GroupStatusID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        MajorID = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.GroupStatusID)
                .ForeignKey("dbo.Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Major", t => t.MajorID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.MajorID);
            
            CreateTable(
                "dbo.Major",
                c => new
                    {
                        MajorID = c.Int(nullable: false),
                        MajorName = c.String(),
                    })
                .PrimaryKey(t => t.MajorID);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                    })
                .PrimaryKey(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupStatus", "MajorID", "dbo.Major");
            DropForeignKey("dbo.GroupStatus", "GroupID", "dbo.Group");
            DropIndex("dbo.GroupStatus", new[] { "MajorID" });
            DropIndex("dbo.GroupStatus", new[] { "GroupID" });
            DropTable("dbo.Room");
            DropTable("dbo.Major");
            DropTable("dbo.GroupStatus");
            DropTable("dbo.Group");
        }
    }
}
