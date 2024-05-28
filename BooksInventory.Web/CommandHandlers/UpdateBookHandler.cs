using BooksInventory.Data.EF;
using BooksInventory.Web.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BooksInventory.Web.CommandHandlers
{
    public class UpdateBookHandler(BookInventoryDbContext db) : IRequestHandler<UpdateBook>
    {
        readonly BookInventoryDbContext _db = db;

        public async Task Handle(UpdateBook request, CancellationToken cancellationToken)
        {
            var book = await _db.Books.FindAsync(request.Id);
            _db.Entry(book).CurrentValues.SetValues(request);

            await _db.SaveChangesAsync();
        }
    }
}