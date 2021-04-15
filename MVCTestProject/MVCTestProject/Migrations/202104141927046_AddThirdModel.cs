namespace MVCTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThirdModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "Category_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Category_Id");
            AddForeignKey("dbo.Posts", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropColumn("dbo.Posts", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
