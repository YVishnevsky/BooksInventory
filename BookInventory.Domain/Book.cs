namespace BookInventory.Domain;

#pragma warning disable RCS1170 
public class Book
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public string ISBN { get; init; }
    public int PublicationYear { get; init; }
    public int Quantity { get; init; }
    public int CategoryId { get; init; }
    public BookCategory Category { get; init; }
}
#pragma warning restore RCS1170