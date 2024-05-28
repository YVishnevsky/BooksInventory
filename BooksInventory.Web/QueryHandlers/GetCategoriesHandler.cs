using BooksInventory.Data.EF;
using BooksInventory.Web.Models;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BooksInventory.Web.CommandHandlers
{
    public class GetCategoriesHandler(BookInventoryDbContext db) : IRequestHandler<GetCategories, IEnumerable<Category>>
    {
        readonly BookInventoryDbContext _db = db;

        public async Task<IEnumerable<Category>> Handle(GetCategories request, CancellationToken cancellationToken) =>
            await _db.BookCategories
                .Select(bc => new Category { Id = bc.Id, Name = bc.Name, Description = bc.Description })
                .ToArrayAsync();
    }
}