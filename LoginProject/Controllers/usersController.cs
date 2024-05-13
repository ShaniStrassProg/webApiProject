//using Services;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
////using Entities;
//using Microsoft.AspNetCore.Identity;
//using Repositories;
//using DTO;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace LoginProject.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private IUserService _userService;
//        public UsersController(IUserService userService)
//        {
//            _userService = userService;
//        }
        
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetById(int id)
//        {
//            User user =await _userService.getUserById(id);
//            if (user != null)
//                return Ok(user);
//            return NotFound();
//        }
//            // GET: api/<UserController>
//            [HttpPost]
//            [Route("login")]
//        public async Task<IActionResult> GetByEmailAndPassword([FromBody] UserLoginDto userLogin)
//            {
//            //Product product = await _productService.getProductById(id);
//            User productDto = _mapper.Map<UserLoginDto, User>(userLogin);
//            if (productDto == null)
//                return NotFound();
//            return Ok(productDto);
//            User user = await _userService.GetUserByEmailAndPassword(userLogin);

//            if (user != null)
//                return Ok(user);
//            return NotFound();
//        }
//        [Route("evalutePassword")]
//        public int EvalutePassword([FromBody] string password)
//        {
//            return (int)_userService.evalutePassword(password);
//        }



//        // POST api/<UserController>
//        [HttpPost]
//            public async Task<ActionResult> Post([FromBody] User user)
//        {
          
//               User newUser = await _userService.addUser(user);
//                if (newUser != null)
//                    return Ok(newUser);
//                return BadRequest(); 
//        }




//        // PUT api/<UserController>/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult <User>> Put(int id, [FromBody] User userToUpdate)
//        {
//           return  await _userService.updateUser(id, userToUpdate);
//        }

        
//    }
       
        
    
//}