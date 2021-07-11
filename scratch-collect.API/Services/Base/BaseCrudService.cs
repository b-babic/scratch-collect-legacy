using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.Api.Services;

namespace scratch_collect.API.Services.Base
{
    public class BaseCrudService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICrudService<TModel, TSearch, TInsert, TUpdate> where TDatabase:class
    {
        private readonly IMapper _mapper;
        private readonly ScratchCollectContext _context;
        public BaseCrudService(ScratchCollectContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);
            _mapper.Map(request, entity);
         

            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }
    }
}