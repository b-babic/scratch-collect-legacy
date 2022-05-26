using Microsoft.AspNetCore.Mvc;
using scratch_collect.Api.Services;

namespace scratch_collect.API.Controllers
{
    public class BaseCrudController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICrudService<T, TSearch, TInsert, TUpdate> _service = null;

        public BaseCrudController(ICrudService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public T Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id, TUpdate request)
        {
            return _service.Update(id, request);
        }
    }
}