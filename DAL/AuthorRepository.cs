using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();

        Author GetAuthor(int authorId);

        IEnumerable<Author> GetAuthorsOfABook(int bookId);

        IEnumerable<Book> GetBooksOfAnAuthor(int authorId);

        bool AuthorExists(int authorId);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private LibraryDbContext _authorContext;
        
        public AuthorRepository(LibraryDbContext authorContext)
        {
            _authorContext = authorContext;
        }

        public bool AuthorExists(int authorId)
        {
            return _authorContext.Authors.Any(a => a.AuthorId == authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _authorContext.Authors.OrderBy(a => a.AuthorName).ToList();
        }

        public Author GetAuthor(int authorId)
        {
            return _authorContext.Authors.Where(a => a.AuthorId == authorId).FirstOrDefault();
        }


        public IEnumerable<Author> GetAuthorsOfABook(int bookId)
        {
            return _authorContext.BookAuthors.Where(b => b.Book.BookId == bookId).Select(a => a.Author).ToList();
        }

        public IEnumerable<Book> GetBooksOfAnAuthor(int authorId)
        {
            return _authorContext.BookAuthors.Where(a => a.Author.AuthorId == authorId).Select(b => b.Book).ToList();
        }
    }
}
