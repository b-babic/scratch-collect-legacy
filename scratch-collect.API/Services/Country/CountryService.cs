using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.Model;
using scratch_collect.Model.Requests;
using System.Collections.Generic;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class CountryService : ICountryService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public CountryService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CountryDTO> Get(CountrySearchRequest request)
        {
            var query = _context.Countries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Name.StartsWith(request.Text));
            }

            var list = query.ToList();

            return _mapper.Map<List<CountryDTO>>(list);
        }
    }
}