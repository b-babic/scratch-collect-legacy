using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using scratch_collect.API.Services;
using scratch_collect.Model;
using System.Collections.Generic;

namespace scratch_collect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<CategoryDTO> Get()
        {
            return _categoryService.Get();
        }
    }
}