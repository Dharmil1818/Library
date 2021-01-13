using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class BookDto
    {
        public int BookId { get; set; }
        
        public string Title { get; set; }
        
        public DateTime? CheckOutDate { get; set; }
    }
}
