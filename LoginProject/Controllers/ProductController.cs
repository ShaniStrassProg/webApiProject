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
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            Console.WriteLine("productController:GetAllProducts:1");
            List<Product> products = await _productService.getAllProducts();
            Console.WriteLine("productController:GetAllProducts:2");
            List<ProductDto> productsDto = _mapper.Map<List<Product>, List<ProductDto>>(products);
            Console.WriteLine("productController:GetAllProducts:3");
            if (productsDto == null) {
                Console.WriteLine("productController:GetAllProducts:4");
                return NotFound();
        }
            Console.WriteLine("productController:GetAllProducts:5");
            return Ok(productsDto);
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
