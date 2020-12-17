using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BOL
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        //[Column(TypeName ="nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string UserName { get; set; } 
        
        public DateTime? CratedDate { get; set; } 

        public IEnumerable<Comment> Comments { get; set; }

        public Book Books { get; set; }

    }
}
