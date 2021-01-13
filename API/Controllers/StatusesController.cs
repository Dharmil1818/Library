using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using BOL;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private IStatusRepository _statusRepository;
        private IBookRepository _bookRepository;

        public StatusesController(IStatusRepository statusRepository, IBookRepository bookRepository)
        {
            _statusRepository = statusRepository;
            _bookRepository = bookRepository;
        }

        //api/statuses
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StatusDto>))]

        public IActionResult GetStatuses()
        {
            var statuses = _statusRepository.GetStatuses().ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var statusDto = new List<StatusDto>();
            foreach (var status in statuses)
            {
                statusDto.Add(new StatusDto
                {
                    StatusId = status.StatusId,
                    StatusName = status.StatusName
                });
            }

            return Ok(statusDto);
        }

        //api/statuses/statusId
        [HttpGet("{statusId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(StatusDto))]

        public IActionResult GetStatus(int statusId)
        {
            if (!_statusRepository.StatusExists(statusId))
                return NotFound();

            var status = _statusRepository.GetStatus(statusId);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var statusDto = new StatusDto()
            {
                StatusId = status.StatusId,
                StatusName = status.StatusName
            };

        return Ok(statusDto);
        
        }

        //api/statuses/books/bookId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(StatusDto))]

        public IActionResult GetStatusOfABook(int bookId)
        {
            //TO DO - Validate the book exists
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            var status = _statusRepository.GetStatusOfABook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var statusDto = new StatusDto()
            {
                StatusId = status.StatusId,
                StatusName = status.StatusName
            };
            return Ok(statusDto);
        }

        //TO DO GetBooksfromAStatus
        //api/statuses/statusId/books
        [HttpGet("{statusId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]

        public IActionResult GetBooksFromAStatus(int statusId)
        {
            if (!_statusRepository.StatusExists(statusId))
                return NotFound();

            var books = _statusRepository.GetBooksFromAStatus(statusId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var booksDto = new List<BookDto>();

            foreach (var book in books)
            {
                booksDto.Add(new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title
                });
            }
            return Ok(booksDto);
        }
        //Post: api/statuses
        //[HttpPost]
        
        //public IActionResult CreateStatus([FromBody]Status statuscreate)
        //{
        //    _statusRepository.
        //}

    }
}
