namespace BooksInventory.DataAccess.EF6.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Use_FullTextSearch : DbMigration
    {
        public override void Up()
        {
            Sql("""
                    ALTER PROCEDURE [dbo].[GetBooks]
                	@sortBy varchar(20) = 'Id',
                	@sortOrder varchar(4) = 'desc',
                	@page int = 1,
                	@rows int = 10,
                	@keyword varchar(20) = null

                AS
                  declare @word varchar(20)='*'
                  if (@keyword is not null)
                  set @word = @keyword

                	SELECT b.*, bc.Name CategoryName, bc.Description CategoryDescription from Books b, BookCategories bc where b.CategoryId = bc.Id
                	and b.id = case when @keyword is not null then case when FREETEXT((Title, Author, ISBN), @word) then b.Id end else b.Id end
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
        }
    }
}
