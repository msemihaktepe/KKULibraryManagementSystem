using Library.Entity.Concrete;

namespace Library.WebUI.Models
{
    public class BorrowedBookViewModel
    {
        public BorrowedBook BorrowedBook { get; set; }
        public List<BorrowedBook> BorrowedBooks { get; set; }
    }
}
