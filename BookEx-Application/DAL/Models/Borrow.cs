using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int bookId { get; set; }

        [Required]
        [StringLength(100)]
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}
