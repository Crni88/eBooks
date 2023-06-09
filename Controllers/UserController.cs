using eBooks.Model.Requests.User;
using eBooks.Model.SearchObjects;
using eBooks.Model.User;
using eBooks.Services.Users;

namespace eBooks.Controllers
{
    public class UserController : BaseCRUDController<UserModel, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
