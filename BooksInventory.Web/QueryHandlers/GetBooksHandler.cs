using BookInventory.Domain;
using BooksInventory.Data.EF;
using BooksInventory.Web.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BooksInventory.Web.CommandHandlers
{
    public class GetBooksHandler(BookInventoryDbContext db) : IRequestHandler<GetBooks, IEnumerable<BookView>>
    {
        readonly BookInventoryDbContext _db = db;

        public async Task<IEnumerable<BookView>> Handle(GetBooks request, CancellationToken cancellationToken)
        {
            // SP call: GetBooks @sortBy, @sortOrder, @page, @rows @keyword --parameters order
            var books = (await _db.Database.SqlQuery<Book>($"GetBooks @p0, @p1, @p2, @p3, @p4", request.SortBy, request.SortOrder, request.Page, request.Rows, request.Keyword)
                .ToArrayAsync());

            return books.Join(_db.BookCategories, b => b.CategoryId, bc => bc.Id, (b, bc) =>
                new BookView(b.Id, b.Title, b.Author, b.ISBN, b.PublicationYear, b.Quantity, b.CategoryId, bc.Name));
        }
    }
}