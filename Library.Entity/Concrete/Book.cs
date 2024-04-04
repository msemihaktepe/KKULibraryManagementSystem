using Library.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entity.Concrete
{
    public class Book : IEntity
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int NumberOfPage { get; set; }
        public string BookImage { get; set; }
        public bool BookStatus { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }
        public List<BorrowedBook>? BorrowedBooks { get; set; }

    }
}
