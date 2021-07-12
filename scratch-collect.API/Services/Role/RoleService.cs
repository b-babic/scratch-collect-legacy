using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using scratch_collect.API.Database;
using scratch_collect.API.Services.Base;
using scratch_collect.Model.Requests;
using Role = scratch_collect.Model.Role.Role;

namespace scratch_collect.API.Services
{
    public class RoleService: BaseService<Role, RoleSearchRequest, Database.Role>
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;
        
        public RoleService(ScratchCollectContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public override List<Role> Get(RoleSearchRequest search)
        {
            if (search?.UserId.HasValue == true)
            {
                var query = _context.Set<Database.UserRole>().Where(x => x.UserId == search.UserId)
                    .Include(x => x.Role)
                    .Select(x => new { x.Role, x.Role.Name })
                    .OrderBy(x => x.Name)
                    .ToList();

                var list = new List<Role>();
                foreach (var item in query)
                {
                    list.Add(new Role() { 
                        Name= item.Name,
                        Id= item.Role.Id
                    });
                }
                return list;
            }
            var entity = _context.Set<Database.Role>()
                .OrderBy(x => x.Name)
                .ToList();
            
            return _mapper.Map<List<Role>>(entity);
        }
    }
}