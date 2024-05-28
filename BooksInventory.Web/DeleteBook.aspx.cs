using BooksInventory.Web.Models;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Web.UI;

namespace BooksInventory.Web
{
    public partial class DeleteBook : System.Web.UI.Page
    {
        public IMediator Mediator { get; set; }
        private int _bookId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _bookId = Convert.ToInt32(Request.QueryString["id"]);
            if (_bookId != 0)
            {
                if (!IsPostBack)
                {
                    const string message = "Do you realy want to delete this book?";
                    ClientScript.RegisterOnSubmitStatement(this.GetType(), "confirm", "return confirm('" + message + "');");

                    RegisterAsyncTask(new PageAsyncTask(() => GetBookAsync(_bookId)));
                }
            }
            else
            {
                Response.Redirect("Books.aspx");
            }
        }

        private async Task GetBookAsync(int id)
        {
            var book = await Mediator.Send(new GetSingleBook(id));
            DetailsView1.DataSource = new[] { book };

            DataBind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                await Mediator.Send(new Models.DeleteBook(_bookId));
                Response.Redirect("Books.aspx");
            }));
        }
    }
}