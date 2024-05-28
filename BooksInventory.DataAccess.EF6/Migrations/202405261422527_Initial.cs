namespace BooksInventory.DataAccess.EF6.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCategories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    Description = c.String(maxLength: 1000, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 256, unicode: false),
                    Author = c.String(nullable: false, maxLength: 256, unicode: false),
                    ISBN = c.String(nullable: false, maxLength: 13, unicode: false),
                    PublicationYear = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    CategoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.BookCategories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.Books");
            DropTable("dbo.BookCategories");
        }
    }
}
