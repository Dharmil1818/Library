using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        
        Location GetLocation(int locationId);

        Location GetLocationOfABook(int bookId);

        IEnumerable<Book> GetBooksFromALocation(int locationId);

        bool LocationExists(int locationId);

        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool Save();

    }

    public class LocationRepository : ILocationRepository

    {
        private LibraryDbContext _locationContext;
        
        public LocationRepository(LibraryDbContext locationContext)
        {
            _locationContext = locationContext;
        }

        public bool LocationExists(int locationId)
        {
            return _locationContext.Locations.Any(l => l.LocationId == locationId);
        }

        public IEnumerable<Location> GetLocations()
        {
            return _locationContext.Locations.OrderBy(l => l.LocationName).ToList();
        }

        public Location GetLocation(int locationId)
        {
            return _locationContext.Locations.Where(l => l.LocationId == locationId).FirstOrDefault();
        }

        public Location GetLocationOfABook(int bookId)
        {
            return _locationContext.Books.Where(b => b.BookId == bookId).Select(l => l.Locations).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksFromALocation(int locationId)
        {
            return _locationContext.Books.Where(l => l.Locations.LocationId == locationId).ToList();
        }

        public bool CreateLocation(Location location)
        {
            _locationContext.Add(location);
            return Save();
        }

        public bool UpdateLocation(Location location)
        {
            _locationContext.Update(location);
            return Save();
        }

        public bool DeleteLocation(Location location)
        {
            _locationContext.Remove(location);
            return Save();
        }

        public bool Save()
        {
            var saved = _locationContext.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}
