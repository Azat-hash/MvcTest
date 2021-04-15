namespace MVCTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            AlterColumn("dbo.Posts", "AuthorId", c => c.Int());
            CreateIndex("dbo.Posts", "AuthorId");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            AlterColumn("dbo.Posts", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "AuthorId");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
