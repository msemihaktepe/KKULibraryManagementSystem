using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserMail { get; set; }
        public bool UserStatus { get; set; }
        public int PositionID { get; set; }
        public Position? Position { get; set; }
        public List<BorrowedBook>? BorrowedBooks { get; set; }
        public List<Message>? Messages { get; set; }

    }
}
