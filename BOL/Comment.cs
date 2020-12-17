using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        
        public string Description { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public DateTime? ModifiedDate { get; set; }
        
        [ForeignKey("BookId")]

        public int BookId { get; set; }

        public Book Books { get; set; }
        
        [ForeignKey("UserId")]
        
        public int UserId { get; set; }

        public User Users { get; set; }

    }
}
