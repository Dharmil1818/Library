using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("Status")]

    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }

        //[Column(TypeName = "nvarchar")]
        [MaxLength(50)]

        public string StatusName { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
