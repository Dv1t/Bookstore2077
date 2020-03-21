using System;
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
    public class CommentController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly UserService _userService;

        public CommentController(BookService bookService, UserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        [HttpPost]
        public Comment AddComment([FromForm] string userId, [FromForm] string bookId, [FromForm] string text)
        {
            var book = _bookService.Get(bookId);
            var user = _userService.Get(userId);
            Comment comment = new Comment();
            comment.Author = user.Login;
            comment.Text = text;
            comment.Data = DateTime.UtcNow.ToString();
            if (book.Comments != null)
            {
                book.Comments.Add(comment);
            }
            else
            {
                book.Comments = new List<Comment>();
                book.Comments.Add(comment);
            }
            if(user.Comments!=null)
            {
                user.Comments.Add(comment);
            }
            else
            {
                user.Comments = new List<Comment>();
                user.Comments.Add(comment);
            }
            _bookService.Update(bookId, book);
            _userService.Update(userId, user);
            return comment;
        }
    }
}