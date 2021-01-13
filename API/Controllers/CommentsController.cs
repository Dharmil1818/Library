using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;

        public CommentsController(ICommentRepository commentRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        //api/comments
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentDto>))]

        public IActionResult GetComments()
        {
            var comments = _commentRepository.GetComments();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentsDto = new List<CommentDto>();

            foreach (var comment in comments)
            {
                commentsDto.Add(new CommentDto
                {
                    CommentId = comment.CommentId,
                    Desscription = comment.Description,
                    CreatedDate = comment.CreatedDate,
                    ModifiedDate = comment.ModifiedDate
                });
            }
            return Ok(commentsDto);
        }

        //api/comments/commentId
        [HttpGet("{commentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CommentDto))]

        public IActionResult GetComment(int commentId)
        {
            if (!_commentRepository.CommentExists(commentId))
                return NotFound();

            var comment = _commentRepository.GetComment(commentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentDto = new CommentDto()
            {
                CommentId = comment.CommentId,
                Desscription = comment.Description,
                CreatedDate = comment.CreatedDate,
                ModifiedDate = comment.ModifiedDate
            };

            return Ok(commentDto);
        }

        //api/comments/books/bookId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CommentDto>))]

        public IActionResult GetCommentsForABook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var comments = _commentRepository.GetCommnnetsOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentsDto = new List<CommentDto>();

            foreach (var comment in comments)
            {
                commentsDto.Add(new CommentDto
                {
                    CommentId = comment.CommentId,
                    Desscription = comment.Description,
                    CreatedDate = comment.CreatedDate,
                    ModifiedDate = comment.ModifiedDate
                });
            }
            return Ok(commentsDto);
        }

        //api/comments/commentId/book
        [HttpGet("{commentId}/book")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(BookDto))]

        public IActionResult GetBookOfAComment(int commentId)
        {
            if (!_commentRepository.CommentExists(commentId))
                return NotFound();

            var book = _commentRepository.GetBookOfAComment(commentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookDto = new BookDto()
            {
                BookId = book.BookId,
                Title = book.Title,
                CheckOutDate = book.CheckOutDate
            };

            return Ok(bookDto);
        }
    }
}
