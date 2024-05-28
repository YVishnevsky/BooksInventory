using BooksInventory.Web.Models;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace BooksInventory.Web
{
    public partial class Books : System.Web.UI.Page
    {
        public IMediator Mediator { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetBooksAsync));
        }

        private async Task GetBooksAsync()
        {
            var books = await Mediator.Send(new GetBooks());
            Repeater1.DataSource = books;
            Repeater1.DataBind();
        }
    }
}