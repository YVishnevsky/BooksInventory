using BookInventory.Domain;
using BooksInventory.Data.EF;
using BooksInventory.Web.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BooksInventory.Web.CommandHandlers
{
    public class NewBookHandler(BookInventoryDbContext db) : IRequestHandler<NewBook>
    {
        readonly BookInventoryDbContext _db = db;

        public async Task Handle(NewBook request, CancellationToken cancellationToken)
        {
            _db.Books.Add(new Book
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublicationYear = (int)request.PublicationYear,
                Quantity = (int)request.Quantity,
                CategoryId = request.CategoryId
            });

            await _db.SaveChangesAsync();
        }
    }
}