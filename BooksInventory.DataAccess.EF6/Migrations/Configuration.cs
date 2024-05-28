using BookInventory.Domain;
namespace BooksInventory.DataAccess.EF6.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BooksInventory.Data.EF.BookInventoryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksInventory.Data.EF.BookInventoryDbContext context)
        {
            context.BookCategories.AddOrUpdate(new BookCategory { Id = 1, Name = "Science fiction", Description = "Science fiction" });
            context.BookCategories.AddOrUpdate(new BookCategory { Id = 2, Name = "History", Description = "History" });

            context.Books.AddOrUpdate(new Book { Id = 1, Title = "Dune", Author = "Frank Herbert", PublicationYear = 1965, ISBN = "9780441172719", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 2, Title = "Neuromancer", Author = "William Gibson", PublicationYear = 1984, ISBN = "9780441569595", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 3, Title = "Foundation", Author = "Isaac Asimov", PublicationYear = 1951, ISBN = "9780553293357", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 4, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", PublicationYear = 1979, ISBN = "9780345391803", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 5, Title = "Snow Crash", Author = "Neal Stephenson", PublicationYear = 1992, ISBN = "9780553380958", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 6, Title = "The War of the Worlds", Author = "H.G. Wells", PublicationYear = 1898, ISBN = "9780486295060", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 7, Title = "Ender's Game", Author = "Orson Scott Card", PublicationYear = 1985, ISBN = "9780812550702", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 8, Title = "1984", Author = "George Orwell", PublicationYear = 1949, ISBN = "9780451524935", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 9, Title = "Starship Troopers", Author = "Robert A. Heinlein", PublicationYear = 1959, ISBN = "9780441783588", CategoryId = 1, Quantity = 1 });
            context.Books.AddOrUpdate(new Book { Id = 10, Title = "The Left Hand of Darkness", Author = "Ursula K. Le Guin", PublicationYear = 1969, ISBN = "9780441478125", CategoryId = 1, Quantity = 1 });

            base.Seed(context);
        }
    }
}
