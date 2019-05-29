namespace MyPlaylistExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtabletblUserPL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserPL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        Image = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblUserPL");
        }
    }
}
