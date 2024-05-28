using AutoFixture;
using BooksInventory.Web.Controllers;
using BooksInventory.Web.Models;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace BookInventoryTests
{
    [TestClass]
    public class ApiControllersTests
    {
        [TestMethod]
        public async Task PostAsync_sends_command_to_add_a_new_book()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var controller = new BooksController(mediator);
            var book = new Fixture().Create<NewBook>();

            //Act
            await controller.PostAsync(book);

            //Assert
            await mediator.Received(1).Send(book);
        }

        [TestMethod]
        public async Task PutAsync_sends_command_to_update_book()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var controller = new BooksController(mediator);
            var book = new Fixture().Create<UpdateBook>();

            //Act
            await controller.PutAsync(book.Id, book);

            //Assert
            await mediator.Received(1).Send(book);
        }

        [TestMethod]
        public async Task DeleteAsync_sends_command_to_delete_book()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var controller = new BooksController(mediator);
            var book = new Fixture().Create<DeleteBook>();

            //Act
            await controller.DeleteAsync(book.Id);

            //Assert
            await mediator.Received(1).Send(book);
        }

        [TestMethod]
        public async Task GetListAsync_sends_command_to_get_list_of_book()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var controller = new BooksController(mediator);
            var book = new Fixture().Create<GetBooks>();

            //Act
            await controller.GetAsync(book);

            //Assert
            await mediator.Received(1).Send(book);
        }

        [TestMethod]
        public async Task GetAsync_sends_command_to_get_one_book()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var controller = new BooksController(mediator);
            var book = new Fixture().Create<GetSingleBook>();

            //Act
            await controller.GetAsync(book.Id);

            //Assert
            await mediator.Received(1).Send(book);
        }
    }
}
