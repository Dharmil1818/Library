using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public string Desscription { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public DateTime? ModifiedDate { get; set; }
    }
}
