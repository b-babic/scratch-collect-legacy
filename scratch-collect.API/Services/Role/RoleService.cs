using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public RoleService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RoleDTO> Get(RoleSearchRequest search)
        {
            var entity = _context.Set<Role>()
                .OrderBy(x => x.Name)
                .ToList();

            return _mapper.Map<List<RoleDTO>>(entity);
        }

        public RoleDTO GetById(int id)
        {
            var entity =
                _context.Set<Role>()
                .FirstOrDefault(x => x.Id == id);

            return _mapper.Map<RoleDTO>(entity);
        }
    }
}