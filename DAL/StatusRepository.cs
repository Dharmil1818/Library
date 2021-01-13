using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public interface IStatusRepository
    {
        IEnumerable<Status> GetStatuses();

        Status GetStatus(int statusId);

        Status GetStatusOfABook(int bookId);
        
        IEnumerable<Book> GetBooksFromAStatus(int statusId);
        
        bool StatusExists(int statusId);


    }

    public class StatusRepository : IStatusRepository
    {
        private LibraryDbContext _statusContext;

        public StatusRepository(LibraryDbContext statusContext)
        {
            _statusContext = statusContext; 
        }

        public bool StatusExists(int statusId)
        {
            return _statusContext.Statuses.Any(s => s.StatusId == statusId);
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _statusContext.Statuses.OrderBy(s => s.StatusName).ToList();
        }

        public Status GetStatus(int statusId)
        {
            return _statusContext.Statuses.Where(s => s.StatusId == statusId).FirstOrDefault();
        }

        public Status GetStatusOfABook(int bookId)
        {
            return _statusContext.Books.Where(b => b.BookId == bookId).Select(s => s.Statuses).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksFromAStatus(int statusId)
        {
            return _statusContext.Books.Where(s => s.Statuses.StatusId == statusId).ToList();
        }
                
    }
}
