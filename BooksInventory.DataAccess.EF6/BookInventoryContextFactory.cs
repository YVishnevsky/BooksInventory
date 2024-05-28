using BooksInventory.Data.EF;
using System.Data.Entity.Infrastructure;

namespace BooksInventory.DataAccess.EF6
{
    public class BookInventoryContextFactory : IDbContextFactory<BookInventoryDbContext>
    {
        public BookInventoryDbContext Create()
        {
            return new BookInventoryDbContext("Data Source=.;Initial Catalog=books_dev;Integrated Security=true;");
        }
    }
}
