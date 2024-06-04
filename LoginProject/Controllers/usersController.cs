using Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
//using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserRegister userRegister)
        {
            User user = _mapper.Map<UserRegister, User>(userRegister);
            User newUser = await _userService.addUser(user);
            if (newUser != null)
                return Ok(newUser);
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> GetByEmailAndPassword([FromBody] UserLoginDto userLogin)
        {
            _logger.LogInformation("Login with user {0} and password {1}", userLogin.Email, userLogin.Password);
            User user = _mapper.Map<UserLoginDto,User>(userLogin);
            User userFound = await _userService.GetUserByEmailAndPassword(user);
            if (userFound == null)
                return NotFound();
            return Ok(userFound);
            
        }
        [HttpPost]
        [Route("evalutePassword")]
        public int EvalutePassword([FromBody] string password)
        {
            return (int)_userService.evalutePassword(password);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] UserRegister userToUpdate)
        {
            User user = _mapper.Map<UserRegister, User>(userToUpdate);
            return await _userService.updateUser(id, user);
        }


    }



}