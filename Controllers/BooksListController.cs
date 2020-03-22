using System.Collections.Generic;
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
        public ActionResult<List<SimpleBook>> Get(int sortOrder)
        {
            List<Book> books = _bookService.Get();
            List<SimpleBook> simpleBooks = new List<SimpleBook>();
            if (books == null)
            {
                return NotFound();
            }

            if(sortOrder==0)
            {
                books.Sort(new BookComparer0());
            }
            if (sortOrder == 1)
            {
                books.Sort(new BookComparer1());
            }
            if (sortOrder == 2)
            {
                books.Sort(new BookComparer2());
            }
            if (sortOrder == 3)
            {
                books.Sort(new BookComparer3());
            }
            if (sortOrder == 4)
            {
                books.Sort(new BookComparer4());
            }
            if (sortOrder == 5)
            {
                books.Sort(new BookComparer5());
            }
            if (sortOrder == 6)
            {
                books.Sort(new BookComparer6());
            }

            foreach (Book elem in books)
            {
                simpleBooks.Add(elem.GetSimple());
            }

            return simpleBooks;
        }
    }
}