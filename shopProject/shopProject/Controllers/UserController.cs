using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        // GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await userService.GetUserById(id);
            return user == null ? NotFound() : user;

        }

        // POST api/<UserController>
        [HttpPost]
        //[Route("Users")]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            return await userService.CreataeUser(user); ;


        }

        [HttpPost]
        [Route("signIn")]
        
        // public ActionResult<User> Post1([FromBody] string password,string email)
        public async Task<ActionResult<User>> SignIn([FromBody] User data)
        {
            User user = await userService.SignIN(data);
            if (user == null) return NotFound();
            else
                return Ok(user);
            //return user == null ? NotFound() : Ok(user);


        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await userService.UpdateUser(id, userToUpdate);



        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
