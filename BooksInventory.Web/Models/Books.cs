using MediatR;
using System.Collections.Generic;

namespace BooksInventory.Web.Models;

public record BookView
(
     int Id,
     string Title,
     string Author,
     string ISBN,
     int PublicationYear,
     int Quantity,
     int CategoryId,
     string CategoryName
);

public record NewBook : IRequest
{
    public string Title { get; init; }
    public string Author { get; init; }
    public string ISBN { get; init; }
    public uint PublicationYear { get; init; }
    public uint Quantity { get; init; }
    public int CategoryId { get; init; }
}

public record UpdateBook : IRequest
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public string ISBN { get; init; }
    public int PublicationYear { get; init; }
    public int Quantity { get; init; }
    public int CategoryId { get; init; }
}

public record DeleteBook(int Id) : IRequest;
public record GetBooks : IRequest<IEnumerable<BookView>>
{
    public int Page { get; init; } = 1;
    public int Rows { get; init; } = int.MaxValue;
    public string SortBy { get; init; } = "Id";
    public string SortOrder { get; init; } = "Desc";
    public string Keyword { get; init; }
}

public record GetSingleBook(int Id) : IRequest<BookView>;