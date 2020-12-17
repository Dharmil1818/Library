using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BOL
{
    [Table("BookAuthor")]
    public class BookAuthor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookAuthorId { get; set; }
        
        [ForeignKey("BookId")]
        
        public int BookId { get; set; }

        public Book Books { get; set; }
        
        [ForeignKey("AuthorId")]
        
        public int AuthorId { get; set; }

        public Author Authors { get; set; }
         

    }
}
