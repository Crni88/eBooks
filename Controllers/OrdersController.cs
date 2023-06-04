using eBooks.Model.OrdersModel;
using eBooks.Model.SearchObjects;
using eBooks.Services.Orders;

namespace eBooks.Controllers
{
    public class OrdersController : BaseController<OrderModel, OrderSearchObject>
    {
        public OrdersController(IOrdersService service) : base(service)
        {
        }
    }
}
