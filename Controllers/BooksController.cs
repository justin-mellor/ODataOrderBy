using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataOrderBy.Models;

namespace ODataOrderBy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in BookStoreDataSource.GetBooks())
                {
                    context.Books.Add(b);
                    if (b.Press != null)
                        context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Book> Get(ODataQueryOptions<Book> queryOptions)
        {
            var queryable = (IQueryable<Book>)queryOptions.ApplyTo(_db.Books.AsQueryable());

            return queryable.ToList();
        }
    }
}
