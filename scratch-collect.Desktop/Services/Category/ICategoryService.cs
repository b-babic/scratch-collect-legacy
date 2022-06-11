using scratch_collect.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace scratch_collect.Desktop.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> Get();
    }
}