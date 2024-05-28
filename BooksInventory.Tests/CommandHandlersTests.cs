using BooksInventory.Data.EF;
using BooksInventory.Web.CommandHandlers;
using BooksInventory.Web.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BookInventoryTests
{
    [TestClass]
    public class CommandAndQueryHandlersTests
    {
        private const string ConnectionString = @"Server=.;Database=books_test;Trusted_Connection=True;ConnectRetryCount=0;";

        [TestMethod]
        public async Task GetSingleBookHandler_returns_correct_item()
        {
            using var context = new BookInventoryDbContext(ConnectionString);
            var handler = new GetSingleBookHandler(context);

            var book = await handler.Handle(new GetSingleBook(1), default);

            Assert.AreEqual(1, book.Id);
        }

        [TestMethod]
        public async Task NewBookHandler_creates_new_book()
        {
            using var context = new BookInventoryDbContext(ConnectionString);
            var handler = new NewBookHandler(context);
            var newBook = new NewBook
            {
                Title = "TestTitle",
                Author = "Test Author",
                PublicationYear = 2024,
                ISBN = "2024202420241",
                CategoryId = 1,
                Quantity = 11
            };

            await handler.Handle(newBook, default);

            using var checkContext = new BookInventoryDbContext(ConnectionString);
            var book = await checkContext.Books.FirstAsync(x => x.ISBN == newBook.ISBN);

            book.Should().BeEquivalentTo(newBook, opt => opt.IgnoringNonBrowsableMembersOnSubject());
        }

        [TestMethod]
        public async Task UpdateBookHandler_updates_existing_book()
        {
            using var context = new BookInventoryDbContext(ConnectionString);
            var handler = new UpdateBookHandler(context);
            var updatedBook = new UpdateBook
            {
                Id = (int)(DateTime.Now.Ticks % 10),
                Title = "Updated Title",
                Author = "Updated Author",
                PublicationYear = 2024,
                ISBN = "2024202420241",
                CategoryId = 2,
                Quantity = 2
            };

            await handler.Handle(updatedBook, default);

            using var checkContext = new BookInventoryDbContext(ConnectionString);
            var book = await checkContext.Books.FindAsync(updatedBook.Id);

            book.Should().BeEquivalentTo(updatedBook, opt => opt.IgnoringNonBrowsableMembersOnSubject());
        }

        [TestMethod]
        public async Task DeleteBookHandler_deletes_existing_book()
        {
            using var context = new BookInventoryDbContext(ConnectionString);
            var handler = new DeleteBookHandler(context);
            var deleteBook = new DeleteBook((int)(DateTime.Now.Ticks % 10));


            await handler.Handle(deleteBook, default);

            using var checkContext = new BookInventoryDbContext(ConnectionString);
            var book = await checkContext.Books.FindAsync(deleteBook.Id);

            book.Should().BeNull();
        }

        [TestCleanup]
        public void Cleanup()
        {
            using var context = new BookInventoryDbContext(ConnectionString);
            context.Database.Delete();
        }

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookInventoryDbContext, BooksInventory.DataAccess.EF6.Migrations.Configuration>(true));
        }
    }
}
