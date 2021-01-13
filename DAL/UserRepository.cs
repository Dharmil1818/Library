using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUser(int userId);

        IEnumerable<Comment> GetCommentsByUser(int userId);

        User GetUserOfAComment(int commentId);

        bool UserExists(int userId);
    }

    public class UserRepository : IUserRepository
    {
        private LibraryDbContext _userContext;
        
        public UserRepository(LibraryDbContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userContext.Users.OrderBy(u => u.UserName).ToList();
        }

        public User GetUser(int userId)
        {
            return _userContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }
        
        public IEnumerable<Comment> GetCommentsByUser(int userId)
        {
            return _userContext.Comments.Where(u => u.Users.UserId == userId).ToList();
        }


        public User GetUserOfAComment(int commentId)
        {
            var userId = _userContext.Comments.Where(c => c.CommentId == commentId).Select(u => u.Users.UserId).FirstOrDefault();
            return _userContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }

        
        public bool UserExists(int userId)
        {
            return _userContext.Users.Any( u => u.UserId == userId);
        }
    }
}
