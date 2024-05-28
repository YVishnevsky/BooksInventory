using BooksInventory.Web.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksInventory.Web.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        // GET: api/Books
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<BookView>> GetAsync([FromUri] GetBooks getBooksRequest) => await _mediator.Send(getBooksRequest);

        // GET: api/Books/5
        [Route("{id}")]
        [HttpGet]
        public async Task<BookView> GetAsync(int id) => await _mediator.Send(new GetSingleBook(id));

        // POST: api/Books
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] NewBook book)
        {
            await _mediator.Send(book);

            return Ok();
        }

        // PUT: api/Books/5
        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(int id, [FromBody] UpdateBook book)
        {
            await _mediator.Send(book with { Id = id });

            return Ok();
        }

        // DELETE: api/Books/5
        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            await _mediator.Send(new Models.DeleteBook(id));

            return Ok();
        }
    }
}
