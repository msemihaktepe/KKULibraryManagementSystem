using Library.Entity.Concrete;

namespace Library.WebUI.Models
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
        public List<Position> Positions { get; set; }
        public BorrowedBook BorrowedBook { get; set; }
    }
}
