using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerId { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string  OwnerName { get; set; }

        public IEnumerable<Book> Books { get; set; } 
    }
}
