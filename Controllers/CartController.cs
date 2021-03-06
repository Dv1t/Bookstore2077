﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using version1.Services;

namespace version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UserService _userService;

        public CartController(BookService bookService, UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:length(24)}", Name = "GetCart")]
        public ActionResult<List<String>> Cart(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }
            if(user.Cart!=null)
                return user.Cart;
            return new List<string>();
        }

        [HttpPost]
        public int BuyBook([FromHeader]string userId, [FromHeader]string bookId)
        {
            var user = _userService.Get(userId);
            if (user != null)
            {
                if (user.Cart != null)
                {
                    user.Cart.Add(bookId);
                }
                else
                {
                    user.Cart = new List<String>();
                    user.Cart.Add(bookId);
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