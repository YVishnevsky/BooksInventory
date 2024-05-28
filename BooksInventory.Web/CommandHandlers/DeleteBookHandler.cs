using BooksInventory.Data.EF;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BooksInventory.Web.CommandHandlers;

public class DeleteBookHandler(BookInventoryDbContext db) : IRequestHandler<Models.DeleteBook>
{
    readonly BookInventoryDbContext _db = db;

    public async Task Handle(Models.DeleteBook request, CancellationToken cancellationToken)
    {
        var book = await _db.Books.FindAsync(request.Id);

        _db.Books.Remove(book);

        await _db.SaveChangesAsync();
    }
}