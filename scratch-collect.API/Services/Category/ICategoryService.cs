using scratch_collect.Model;
using System.Collections.Generic;

namespace scratch_collect.API.Services
{
    public interface ICategoryService
    {
        public List<CategoryDTO> Get();
    }
}