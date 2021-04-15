namespace MVCTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Posts", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "Category_Id");
        }
    }
}
