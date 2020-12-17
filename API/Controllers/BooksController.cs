using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BOL;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDb objbookDb;

        public BooksController(BookDb objbookDb)
        {
            this.objbookDb = objbookDb;
        }

        //GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return Ok(await objbookDb.GetALL().ToListAsync());
        }
        //[HttpGet]
        //public IActionResult GetALL()
        //{
        //    IList<Book> books = null;
        //    using (var ctx = new LibraryDbContext())
        //    {
        //        books = ctx.Books.Include("Status")
        //            .Select(s => new Book()
        //            {
        //                BookId = s.BookId,
        //                Title = s.Title,
        //                Statuses = s.Statuses,
        //                Locations = s.Locations,
        //            }).ToList<Book>();

        //    }
        //    if (books.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(books);

        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        //{
        //    return Ok(await objbookDb.GetALL());
        //}

        //// GET: api/Books/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Book>> GetBook(int id)
        //{
        //    var book = await BookDb.;
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        //// PUT: api/Books/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBook(int id, Book book)
        //{
        //    if (id != book.BookId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(book).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
           await objbookDb.Create(book);
            

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        //// DELETE: api/Books/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Book>> DeleteBook(int id)
        //{
        //    var book = await _context.Books.FindAsync(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();

        //    return book;
        //}

        //private bool BookExists(int id)
        //{
        //    return _context.Books.Any(e => e.BookId == id);
        //}
    }
}
