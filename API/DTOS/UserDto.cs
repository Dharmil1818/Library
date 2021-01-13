using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class UserDto
    {

        public int UserId { get; set; }
        
        public string UserName { get; set; }
        
        public DateTime? CreatedDate { get; set; }

    }
}
