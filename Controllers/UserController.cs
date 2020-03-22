using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using version1.Identities;
using version1.Services;

namespace version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create([FromHeader] string login, [FromHeader] string password, [FromHeader] string name, [FromHeader] string surname, [FromHeader] string email)
        {
            var oldUser1 = _userService.FindByLogin(login);
            var oldUser2 = _userService.FindByEmail(email);
            if ((oldUser1 == null)&&(oldUser2==null))
            {
                User user = new User();
                user.Login = login;
                user.Name = name;
                user.Surname = surname;
                user.Email = email;
                user.Password = password;
                user.Cart = new List<string>();
                _userService.Create(user);
                return _userService.FindByLogin(login);
            }
            else
                return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
}
}