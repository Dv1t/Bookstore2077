﻿using Microsoft.AspNetCore.Mvc;
using version1.Identities;
using version1.Services;

namespace version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Login([FromHeader] string login, [FromHeader] string password)
        {
            var loginByLogin = _userService.FindByLogin(login);
            var loginByEmail = _userService.FindByEmail(login);
            if ((loginByLogin != null))
            {
                if (loginByLogin.Password == password)
                {
                    return loginByLogin;
                }
            }
            if ((loginByEmail != null))
            {
                if (loginByEmail.Password == password)
                {
                    return loginByEmail;
                }
            }
            return NoContent();
        }
    }
}