using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();

        Book GetBook(int bookId);

        bool BookExists(int bookId);

        //bool IsDuplicateName(int bookId, string bookName);

        bool CreateBook(List<int> authorId, Book book);
        
        bool UpdateBook(List<int> authorId, Book book);

        bool DeleteBook(Book book);

        bool Save();
    }

    public class BookRepository : IBookRepository
    {
        private LibraryDbContext _bookDbContext;
        
        public BookRepository(LibraryDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookDbContext.Books.OrderBy(b => b.Title).ToList();
        }

        public Book GetBook(int bookId)
        {
            return _bookDbContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();
        }

        public bool BookExists(int bookId)
        {
            return _bookDbContext.Books.Any(b => b.BookId == bookId);
        }

        //new 

        public bool CreateBook(List<int> authorId, Book book)
        {
            var authors = _bookDbContext.Authors.Where(a => authorId.Contains(a.AuthorId)).ToList();

            foreach(var author in authors)
            {
                var bookAuthor = new BookAuthor()
                {
                    Author = author,
                    Book = book
                };
                _bookDbContext.Add(bookAuthor);
            }
            _bookDbContext.Add(book);
            return Save();
        }

        public bool UpdateBook(List<int> authorId, Book book)
        {
            var authors = _bookDbContext.Authors.Where(a => authorId.Contains(a.AuthorId)).ToList();

            var bookAuthorsToDelete = _bookDbContext.BookAuthors.Where(b => b.BookId == book.BookId);

            _bookDbContext.RemoveRange(bookAuthorsToDelete);
            
            foreach(var author in authors)
            {
                var bookAuthor = new BookAuthor()
                {
                    Author = author,
                    Book = book
                };
                _bookDbContext.Add(bookAuthor);
            }
            _bookDbContext.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _bookDbContext.Remove(book);
            return Save();
        }

        public bool Save()
        {
            var saved = _bookDbContext.SaveChanges();
            return saved >= 0 ? false : true;
        }
    }
}
    //public  class BookRepository
    //{
    //    private LibraryDbContext objBookdb;

    //    public BookRepository()
    //    {
    //        objBookdb = new LibraryDbContext();
    //    }

    //    public IQueryable<Book> GetALL()

    //    {
    //        return objBookdb.Books;
    //    }

    //    //public IEnumerable<Book> GetALL()
    //    //{
    //    //    return objBookdb.Books.ToList();
    //    //}
    //    //public async Task<List<Book>> GetALL()

    //    //{
    //    //    var books = new List<Book>();
    //    //    var allbooks = await objBookdb.Books.ToListAsync();
    //    //    if (allbooks?.Any() == true)
    //    //    {
    //    //        foreach (var book in allbooks)
    //    //        {
    //    //            books.Add(new Book()
    //    //            {
    //    //                Title = book.Title,
    //    //                Locations = book.Locations,
    //    //                Statuses = book.Statuses,
    //    //                Users = book.Users
    //    //            });
    //    //        }
    //    //    }

    //    //    return books;
    //    //}


    //    public Book GetStatusById(int Id)
    //    {
    //        return objBookdb.Books.Find(Id);
    //    }

    //    public Book GetBookById(int Id)
    //    {
    //        return objBookdb.Books.Find(Id);
    //    }

    //    public async Task Create(Book book)
    //    {
    //        objBookdb.Add<Book>(book);
    //        await objBookdb.SaveChangesAsync();
    //    }

    //    public void Delete(int Id)
    //    {
    //        Book book = objBookdb.Books.Find(Id);
    //        objBookdb.Books.Remove(book);
    //        objBookdb.SaveChanges();
    //    }

    //    public void Update(Book book)
    //    {
    //        objBookdb.Entry(book).State = EntityState.Modified;
    //        //objBookdb.Configuration.ValidateOnSaveEnabled = false;
    //        objBookdb.SaveChanges();
    //        //objBookdb.Configuration.ValidateOnSaveEnabled = true;
    //    }

    //    //public void Save()
    //    //{
    //    //    objBookdb.SaveChanges();
    //    //}

