﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using version1.Identities;
using version1.Identities.Comparers;
using version1.Services;

namespace version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksListController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksListController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{sortOrder:length(1)}", Name = "GetBooksList")]
        public ActionResult<List<Book>> Get(int sortOrder)
        {
            List<Book> books = _bookService.Get();

            if (books == null)
            {
                return NotFound();
            }

            if(sortOrder==0)
            {
                //List<Book>.Sort(books, new BookComparer0());
            }

            return books;
        }
    }
}