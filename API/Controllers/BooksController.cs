using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BOL;
using DAL;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository _bookRepository;
        private ICommentRepository _commentRepository;
        private IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository, ICommentRepository commentRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _commentRepository = commentRepository;
            _authorRepository = authorRepository;
        }

        //GET: api/Books1
       [HttpGet]
        public ActionResult GetBooks()
        {
            return Ok(_bookRepository.GetBooks().ToList());
        }

        //GET: api/Books1/5
        [HttpGet("{bookId}")]
        public ActionResult GetBook(int bookId)
        {
            var book = _bookRepository.GetBook(bookId);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //PUT: api/Books1/bookId?authorId=1&authorId=2
       [HttpPut("{bookId}")]
        public IActionResult UpdateBook(int bookId, [FromQuery] List<int> authorId, Book book)
        {
            if (bookId != book.BookId)
            {
                return BadRequest();
            }

            _bookRepository.UpdateBook(authorId, book);

            //UpdateBook(book).State = EntityState.Modified;
            try
            {
                _bookRepository.Save();
            }
            catch (Exception)
            {
                if (!_bookRepository.BookExists(bookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books1?authorId=1&authorId=2
        [HttpPost]
        public ActionResult CreateBook([FromQuery] List<int> authorId,[FromBody] Book book)
        {
            _bookRepository.CreateBook(authorId, book);
            _bookRepository.Save();
            

            return CreatedAtAction("GetBook", new { bookId = book.BookId }, book);
        }

        //DELETE: api/Books1/5
        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            //var comments = _commentRepository.GetCommnnetsOfABook(bookId);
            var book = _bookRepository.GetBook(bookId);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(book);
            _bookRepository.Save();

            return NoContent();
        }

        //private bool BookExists(int bookId)
        //{
        //    return _bookRepository.Books.Any(e => e.BookId == bookId);
        //}
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using BOL;
//using DAL;
//using Microsoft.AspNetCore.Authorization;
//using API.DTOS;

//namespace API.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class BooksController : ControllerBase
//    {
//        private IBookRepository _bookRepository;
//        private IAuthorRepository _authorRepository;
//        private ICommentRepository _commentRepository;

//        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository, ICommentRepository commentRepository)
//        {
//            _bookRepository = bookRepository;
//            _authorRepository = authorRepository;
//            _commentRepository = commentRepository;
//        }

//        //api/books
//        [HttpGet]
//        [ProducesResponseType(400)]
//        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]

//        public IActionResult GetBooks()
//        {
//            var books = _bookRepository.GetBooks().ToList();

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var booksDto = new List<BookDto>();

//            foreach (var book in books)
//            {
//                booksDto.Add(new BookDto
//                {
//                    BookId = book.BookId,
//                    Title = book.Title,
//                    CheckOutDate = book.CheckOutDate
//                });
//            }
//            return Ok(booksDto);

//        }

//        //api/books/bookId
//        [HttpGet("{bookId}", Name = "GetBook")]
//        [ProducesResponseType(200, Type = typeof(BookDto))]
//        [ProducesResponseType(400)]
//        [ProducesResponseType(404)]

//        public IActionResult GetBook(int bookId)
//        {
//            if (!_bookRepository.BookExists(bookId))
//                return NotFound();

//            var book = _bookRepository.GetBook(bookId);

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var bookDto = new BookDto()
//            {
//                BookId = book.BookId,
//                Title = book.Title
//                //CheckOutDate = book.CheckOutDate
//            };

//            return Ok(bookDto);
//        }

//        //api/books?authId=1&authId=2
//        [HttpPost]
//        [ProducesResponseType(201, Type = typeof(BookDto))]
//        [ProducesResponseType(400)]
//        [ProducesResponseType(404)]
//        [ProducesResponseType(422)]
//        [ProducesResponseType(500)]

//        public IActionResult CreateBook([FromQuery] List<int> authId, [FromBody] Book bookToCreate)
//        {
//            var statusCode = ValidateBook(authId, bookToCreate);

//            if (!ModelState.IsValid)
//                return StatusCode(statusCode.StatusCode);

//            if (!_bookRepository.CreateBook(authId, bookToCreate))
//            {
//                ModelState.AddModelError("", $"Something went wrong saving the book" +
//                    $"{bookToCreate.Title}");
//                return StatusCode(500, ModelState);
//            }
//            return CreatedAtRoute("GetBook", new { bookId = bookToCreate.BookId }, bookToCreate);
//        }

//        //api/books/bookId?authId=1&authId=2
//        [HttpPut("{bookId}")]
//        [ProducesResponseType(204)]
//        [ProducesResponseType(400)]
//        [ProducesResponseType(404)]
//        [ProducesResponseType(422)]
//        [ProducesResponseType(500)]

//        public IActionResult UpdateBook(int bookId, [FromQuery] List<int> authId, [FromBody] Book bookToUpdate)
//        {
//            var statusCode = ValidateBook(authId, bookToUpdate);

//            if (bookId != bookToUpdate.BookId)
//                return BadRequest();

//            if (!_bookRepository.BookExists(bookId))
//                return NotFound();

//            if (!ModelState.IsValid)
//                return StatusCode(statusCode.StatusCode);

//            if (!_bookRepository.UpdateBook(authId, bookToUpdate))
//            {
//                ModelState.AddModelError("", $"Something went wrong saving the book" +
//                    $"{bookToUpdate.Title}");
//                return StatusCode(500, ModelState);
//            }
//            return NoContent();
//        }


//        private StatusCodeResult ValidateBook(List<int> authId, Book book)
//        {
//            if (book == null || authId.Count <= 0)
//            {
//                ModelState.AddModelError("", "Missing Book or Author");
//                return BadRequest();
//            }

//            foreach (var id in authId)
//            {
//                if (!_authorRepository.AuthorExists(id))
//                {
//                    ModelState.AddModelError("", "Author Not Found");
//                    return StatusCode(404);
//                }

//            }
//            if (!ModelState.IsValid)
//            {
//                ModelState.AddModelError("", "Critical Error");
//                return BadRequest();
//            }
//            return NoContent();
//        }

//    }
//}

