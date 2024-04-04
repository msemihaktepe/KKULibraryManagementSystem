using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class BorrowedBook : IEntity
    {        
        public int BorrowedBookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool BorrowedBookStatus { get; set; }        
        public int UserID { get; set; }
        public User? User { get; set; }
        public int BookID { get; set; }
        public Book? Book { get; set; }
       
    }
}
