using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
        [Table("Author")]
   public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]

        public string AuthorName { get; set; }

        public IEnumerable<BookAuthor> BookAuthors { get; set; }

    }
}
