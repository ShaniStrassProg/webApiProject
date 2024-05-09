using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IUserService _userService;
        public ProductController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        //public async Task<ActionResult<Product>> GetById(int id)
        //{


        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
