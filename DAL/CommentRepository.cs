using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments();

        Comment GetComment(int commentId);

        IEnumerable<Comment> GetCommnnetsOfABook(int bookId);

        Book GetBookOfAComment(int commentId);

        bool CommentExists(int commentId);
    }

    public class CommentRepository : ICommentRepository
    {
        private LibraryDbContext _commentContext;
       
        public CommentRepository(LibraryDbContext commentContext)
        {
            _commentContext = commentContext;
        }

        public bool CommentExists(int commentId)
        {
            return _commentContext.Comments.Any(c => c.CommentId == commentId);
        }

        public IEnumerable<Comment> GetComments()
        {
            return _commentContext.Comments.OrderBy(c => c.CommentId).ToList();
        }


        public Comment GetComment(int commentId)
        {
            return _commentContext.Comments.Where(c => c.CommentId == commentId).FirstOrDefault();
        }

        public Book GetBookOfAComment(int commentId)
        {
            var bookId = _commentContext.Comments.Where(c => c.CommentId == commentId).Select(b => b.Books.BookId).FirstOrDefault();
            return _commentContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();
        }



        public IEnumerable<Comment> GetCommnnetsOfABook(int bookId)
        {
            return _commentContext.Comments.Where(b => b.Books.BookId == bookId).ToList();
        }
    }
}
