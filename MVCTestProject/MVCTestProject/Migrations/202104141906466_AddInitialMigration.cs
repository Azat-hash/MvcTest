namespace MVCTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PostContent = c.String(nullable: false),
                        ImageName = c.String(nullable: false),
                        Image = c.Binary(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
