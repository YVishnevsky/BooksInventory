using MediatR;
using System.Collections.Generic;

namespace BooksInventory.Web.Models;

public record Category
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}

public record GetCategories : IRequest<IEnumerable<Category>>;