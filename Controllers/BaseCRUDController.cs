using eBooks.Services.Base_Services;
using Microsoft.AspNetCore.Mvc;

namespace eBooks.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
        where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
        }

        [HttpPost]
        public virtual T Insert(TInsert request)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)this._service).Insert(request);
        }

        [HttpPut("{id}")]
        public virtual T Update(int id, TUpdate request)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)this._service).Update(id, request);
        }
        [HttpPut("delete/{id}")]
        public virtual T Delete(int id)
        {
            return ((ICRUDService<T, TSearch, TInsert, TUpdate>)this._service).Delete(id);
        }
    }
}
