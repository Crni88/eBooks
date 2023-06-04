using eBooks.Services.Base_Services;
using Microsoft.AspNetCore.Mvc;

namespace eBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IService<T,TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }
        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public virtual T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}