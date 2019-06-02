namespace MyPlaylistExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtabletblPlaylist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPlaylist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameList = c.String(nullable: false, maxLength: 255),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUserPL", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPlaylist", "UserId", "dbo.tblUserPL");
            DropIndex("dbo.tblPlaylist", new[] { "UserId" });
            DropTable("dbo.tblPlaylist");
        }
    }
}
