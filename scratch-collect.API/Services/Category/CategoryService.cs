using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.Model;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CategoryDTO> Get()
        {
            var entity = _context.Set<Category>()
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<List<CategoryDTO>>(entity);
        }
    }
}