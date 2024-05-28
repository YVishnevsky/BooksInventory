using BooksInventory.Data.EF;
using BooksInventory.Web.Models;
using MediatR;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace BooksInventory.Web.CommandHandlers;

public class GetSingleBookHandler(BookInventoryDbContext db) : IRequestHandler<GetSingleBook, BookView>
{
    readonly BookInventoryDbContext _db = db;

    public async Task<BookView> Handle(GetSingleBook request, CancellationToken cancellationToken)
    {
        var book = await _db.Books
           .Include(b => b.Category)
           .SingleAsync(b => b.Id == request.Id);

        return new BookView(book.Id, book.Title, book.Author, book.ISBN, book.PublicationYear, book.Quantity, book.CategoryId, book.Category.Name);
    }
}