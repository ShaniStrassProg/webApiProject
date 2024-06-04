using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        public categoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> getCategories()
        {
           
            List<Category> categoriesFound = await _categoryService.getCategories();
            List<CategoryDto> categories = _mapper.Map<List<Category>, List<CategoryDto>>(categoriesFound);
            if (categories == null)
                return NotFound();
                    return Ok(categories);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Category category = await _categoryService.GetCategoryById(id);
            CategoryDto categoryDto = _mapper.Map<Category, CategoryDto>(category);
            if (categoryDto == null)
                return NotFound();
            return Ok(categoryDto);
        }

   
    }
}
