using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //public interface IBookDb 
    //{
    //    IEnumerable<Book> GetALL();

    //    Book GetBookById(int Id);

    //    void Create(Book book);

    //    void Delete(int Id);

    //    void 
    //}
   public  class BookDb
    {
        private LibraryDbContext objBookdb;

        public BookDb()
        {
            objBookdb = new LibraryDbContext();
        }

        public IQueryable<Book> GetALL()

        {
            return objBookdb.Books;
        }

        //public IEnumerable<Book> GetALL()
        //{
        //    return objBookdb.Books.ToList();
        //}
        //public async Task<List<Book>> GetALL()

        //{
        //    var books = new List<Book>();
        //    var allbooks = await objBookdb.Books.ToListAsync();
        //    if (allbooks?.Any() == true)
        //    {
        //        foreach (var book in allbooks)
        //        {
        //            books.Add(new Book()
        //            {
        //                Title = book.Title,
        //                Locations = book.Locations,
        //                Statuses = book.Statuses,
        //                Users = book.Users
        //            });
        //        }
        //    }

        //    return books;
        //}


        public Book GetStatusById(int Id)
        {
            return objBookdb.Books.Find(Id);
        }

        public Book GetBookById(int Id)
        {
            return objBookdb.Books.Find(Id);
        }

        public async Task Create(Book book)
        {
            objBookdb.Add<Book>(book);
            await objBookdb.SaveChangesAsync();
        }

        public void Delete(int Id)
        {
            Book book = objBookdb.Books.Find(Id);
            objBookdb.Books.Remove(book);
            objBookdb.SaveChanges();
        }

        public void Update(Book book)
        {
            objBookdb.Entry(book).State = EntityState.Modified;
            //objBookdb.Configuration.ValidateOnSaveEnabled = false;
            objBookdb.SaveChanges();
            //objBookdb.Configuration.ValidateOnSaveEnabled = true;
        }

        //public void Save()
        //{
        //    objBookdb.SaveChanges();
        //}
    }
}
