using eBooks.Services.DataDB;
using eBooks.Services.Generics;
using Microsoft.AspNetCore.Mvc;

namespace eBooks.Controllers
{
    public class BooksController : ControllerBase
    {
        IService<Book> service { get; set; }
        public BooksController()
        {
        }
        [HttpGet]
        public IEnumerable<Book> Get() {

            return service.Get();
        } 
    }
}
