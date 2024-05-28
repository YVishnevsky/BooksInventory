using BooksInventory.Web.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksInventory.Web
{
    public partial class AddBook : System.Web.UI.Page
    {
        public IMediator Mediator { get; set; }
        protected IEnumerable<Category> Categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        public async void AddNewBook(NewBook book)
        {
            await Mediator.Send(book);

            Response.Redirect("Books.aspx");
        }

        public async Task<NewBook> Select()
        {
            Categories = await Mediator.Send(new GetCategories());

            return new NewBook();
        }
    }
}