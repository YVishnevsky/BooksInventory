using BooksInventory.Web.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksInventory.Web
{
    public partial class EditBook : System.Web.UI.Page
    {
        public IMediator Mediator { get; set; }
        private int _bookId;
        protected IEnumerable<Category> Categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            _bookId = Convert.ToInt32(Request.QueryString["id"]);

            if (_bookId == 0)
            {
                Response.Redirect("Books.aspx");
            }
        }

        public async Task<UpdateBook> GetBook()
        {
            var book = await Mediator.Send(new GetSingleBook(_bookId));
            Categories = await Mediator.Send(new GetCategories());

            return new UpdateBook
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationYear = (int)book.PublicationYear,
                Quantity = (int)book.Quantity,
                CategoryId = book.CategoryId
            };
        }

        public async Task UpdateBook(UpdateBook book)
        {
            await Mediator.Send(book with { Id = _bookId });

            Response.Redirect("Books.aspx");
        }
    }
}