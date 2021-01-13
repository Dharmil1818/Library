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
    public class LocationsController : ControllerBase
    {
        private ILocationRepository _locationRepository;
        private IBookRepository _bookRepository;

        public LocationsController(ILocationRepository locationRepository, IBookRepository bookRepository)
        {
            _locationRepository = locationRepository;
            _bookRepository = bookRepository;
        }
        //api/locations
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LocationDto>))]
        
        public IActionResult GetLocations()
        {
            var locations = _locationRepository.GetLocations().ToList();
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationsDto = new List<LocationDto>();
            
            foreach (var location in locations)
            {
                locationsDto.Add(new LocationDto
                {
                    LocationId = location.LocationId,
                    LocationName = location.LocationName
                });
            }
            return Ok(locationsDto);
        }

        //api/locations/locationId
        [HttpGet("{locationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(LocationDto))]
        
        public IActionResult GetLocation(int locationId)
        {
            if (!_locationRepository.LocationExists(locationId))
                return NotFound();

            var location = _locationRepository.GetLocation(locationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationDto = new LocationDto()
            {
                LocationId = location.LocationId,
                    LocationName  = location.LocationName
            };

            return Ok(locationDto);
          }

        //api/locations/books/bookId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(LocationDto))]

        public IActionResult GetLocationOfABook(int bookId)
        {
            //TO DO - Validate the book exists.
            if (!_bookRepository.BookExists(bookId))
                return NotFound();
            
            var location = _locationRepository.GetLocationOfABook(bookId);
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationDto = new LocationDto()
            {
                LocationId = location.LocationId,
                LocationName = location.LocationName
            };
            return Ok(locationDto);
        }

        //TO DO GetBooksfromALocation
        //api/locations/locationId/books
        [HttpGet("{locationId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]

        public IActionResult GetBooksFromALocation(int locationId)
        {
            if (!_locationRepository.LocationExists(locationId))
                return NotFound();

            var books = _locationRepository.GetBooksFromALocation(locationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var booksDto = new List<BookDto>();

            foreach(var book in books)
            {
                booksDto.Add(new BookDto
                { 
                 BookId = book.BookId,
                 Title = book.Title
                });
            }
            return Ok(booksDto);
        }

        //Put: api/locations/locationId
        [HttpPut("{locationId}")]

        public IActionResult UpdateLcation(int locationId,[FromBody]Location location)
        {
            if (locationId != location.LocationId)
                return BadRequest();

            _locationRepository.UpdateLocation(location);

            try
            {
                _locationRepository.Save();
            }
            catch(Exception)
            {
                if (!_locationRepository.LocationExists(locationId))
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

        //Post: api/locations
        [HttpPost]

        public IActionResult CreateLocation([FromBody]Location locationcreate)
        {
            _locationRepository.CreateLocation(locationcreate);
            _bookRepository.Save();

            return CreatedAtAction("GetLocation", new { locationId = locationcreate.LocationId }, locationcreate);
        }

        //Delete: api/locations/LocationId
        [HttpDelete("{locationId}")]

        public IActionResult DeleteLocation(int locationId)
        {
            var location = _locationRepository.GetLocation(locationId);

            if (location == null)
            {
                return NotFound();
            }

            _locationRepository.DeleteLocation(location);
            _locationRepository.Save();

                return NoContent();
        }
    }
}
