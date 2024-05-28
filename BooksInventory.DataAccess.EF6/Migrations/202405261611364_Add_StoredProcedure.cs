namespace BooksInventory.DataAccess.EF6.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Add_StoredProcedure : DbMigration
    {
        public override void Up()
        {
            Sql("""
                CREATE PROCEDURE [dbo].[GetBooks]
                	@sortBy varchar(20) = 'Id',
                	@sortOrder varchar(4) = 'desc',
                	@page int = 1,
                	@rows int = 10
                AS
                	SELECT b.*, bc.Name CategoryName, bc.Description CategoryDescription from Books b, BookCategories bc where b.CategoryId = bc.Id
                	order by 
                	case 
                	when @sortOrder = 'desc' or @sortOrder is null then
                	case @sortBy
                	when 'Title' then Title
                	when 'Author' then Author
                	when 'ISBN' then ISBN end end desc,

                	case 
                	when @sortOrder = 'desc' or @sortOrder is null then
                	case @sortBy
                	when 'PublicationYear' then PublicationYear
                	when 'Quantity' then Quantity 
                	else b.id end end desc,

                	case 
                	when @sortOrder = 'asc' then
                	case @sortBy
                	when 'Title' then Title
                	when 'Author' then Author
                	when 'ISBN' then ISBN end end,

                	case 
                	when @sortOrder = 'asc' then
                	case @sortBy
                	when 'PublicationYear' then PublicationYear
                	when 'Quantity' then Quantity end end 

                	OFFSET (@page-1)*@rows ROWS FETCH NEXT @rows ROWS ONLY

                RETURN
                """);
        }

        public override void Down()
        {
            Sql("DROP PROCEDURE [dbo].[GetBooks]");
        }
    }
}
