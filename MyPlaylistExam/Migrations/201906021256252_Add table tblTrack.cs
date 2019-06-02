namespace MyPlaylistExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtabletblTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblTrack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTrack = c.String(nullable: false, maxLength: 255),
                        Artist = c.String(nullable: false, maxLength: 255),
                        Genre = c.String(maxLength: 255),
                        PlaylistId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPlaylist", t => t.PlaylistId)
                .Index(t => t.PlaylistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblTrack", "PlaylistId", "dbo.tblPlaylist");
            DropIndex("dbo.tblTrack", new[] { "PlaylistId" });
            DropTable("dbo.tblTrack");
        }
    }
}
