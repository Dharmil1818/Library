using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("Book")]

     public class Book
      {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        public DateTime? CheckOutDate { get; set; }

        [ForeignKey("StatusId")]
        
        public int StatusId { get; set; }
        
        public Status Statuses { get; set; }

        [ForeignKey("LocationId")]

        public int LocationId { get; set; }

        public Location Locations { get; set; }

        [ForeignKey("UserId"),Column("CheckedOutBy")]
        
        public int?  UserId { get; set; }
        
        public User Users { get; set; }

        [ForeignKey("OwnerId")]
        
        public int OwnerId { get; set; }

        public Owner Owners { get; set; }

        public IEnumerable<BookAuthor> BookAuthors { get; set; }
    
        public IEnumerable<Comment> Comments { get; set; }
    
    }
}
