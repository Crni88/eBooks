using eBooks.Model.OrdersModel;
using eBooks.Model.Requests.Orders;
using eBooks.Model.SearchObjects;
using eBooks.Services.Orders;

namespace eBooks.Controllers
{
    public class OrdersController : BaseCRUDController<OrderModel, OrderSearchObject,OrderInsertRequest,OrderUpdateRequest> 
    {
        public OrdersController(IOrdersService service) : base(service)
        {
        }
    }
}
