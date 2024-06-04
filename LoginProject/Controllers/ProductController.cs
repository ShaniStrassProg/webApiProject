using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private IProductService _productService;
        private IMapper _mapper;
        public productController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts([FromQuery]int position, [FromQuery] int skip, [FromQuery] string? desc, [FromQuery] int? minPrice
            , [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await _productService.getProducts(position, skip, desc, minPrice,maxPrice, categoryIds);
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            if (productsDto != null)
            {
                return Ok(productsDto);
              
            }
             return NotFound();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await _productService.getProductById(id);
            ProductDto productDto = _mapper.Map<Product, ProductDto>(product);
            if (productDto == null)
                return NotFound();
            return Ok(productDto);
        }

   
    }
}
