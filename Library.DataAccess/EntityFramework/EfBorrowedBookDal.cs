using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.Repositories;
using Library.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.EntityFramework
{
    public class EfBorrowedBookDal : GenericRepository<BorrowedBook, Context>, IBorrowedBookDal
    {
        public BorrowedBook GetFK(int userID)
        {
            using (var context = new Context())
            {
                return context.BorrowedBooks.Include(b => b.Book).Include(b => b.User).SingleOrDefault(b => b.UserID == userID && b.BorrowedBookStatus == true);
            }
        }

        public List<BorrowedBook> GetAllFK()
        {
            using (var context = new Context())
            {
                return context.BorrowedBooks.Include(b => b.Book).Include(b => b.User).OrderBy(b => b.BorrowedBookID).ToList();
            }
        }

        public List<BorrowedBook> GetAllByStasus()
        {
            using (var context = new Context())
            {
                return context.BorrowedBooks.Include(b => b.Book).Include(b => b.User).Where(b => b.BorrowedBookStatus == true).OrderBy(b => b.BorrowedBookID).ToList();
            }
        }

        public List<BorrowedBook> GetAllByStasus2()
        {
            using (var context = new Context())
            {
                return context.BorrowedBooks.Include(b => b.Book).Include(b => b.User).Where(b => b.BorrowedBookStatus == false).OrderBy(b => b.BorrowedBookID).ToList();
            }
        }
    }
}
