using eBooks.Model.BooksModel;
using eBooks.Model.SearchObjects;
using eBooks.Services.Base_Services;

namespace eBooks.Controllers
{
    public class BooksController : BaseController<BookModel,BookSearchObject>
    {
        public BooksController(IService<BookModel, BookSearchObject> service) : base(service)
        {
        }
    }
}
