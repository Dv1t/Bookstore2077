﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using version1.Identities;
using version1.Services;

namespace version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly UserService _userService;

        public ReadController(BookService bookService, UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public int ReadBook([FromHeader]string userId, [FromHeader]string bookId)
        {
            var user = _userService.Get(userId);
            if (user != null)
            {
                if (user.ReadBooks != null)
                {
                    user.ReadBooks.Add(bookId);
                }
                else
                {
                    user.ReadBooks = new List<String>();
                    user.ReadBooks.Add(bookId);
                }
            }
            else
            {
                return 1;
            }
            _userService.Update(userId, user);
            return 0;
        }
    }
}