using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BOL
{
    [Table("Location")]
    
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

       // [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]

        public string LocationName { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
