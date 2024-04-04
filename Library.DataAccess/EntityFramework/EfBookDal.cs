using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.Repositories;
using Library.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.EntityFramework
{
    public class EfBookDal : GenericRepository<Book, Context>, IBookDal
    {
        public List<Book> GetAllByStasus(Expression<Func<Book, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null
                    ? context.Books.Include(b => b.Author).Include(b => b.Type).Where(b => b.BookStatus == true).OrderBy(b => b.BookID).ToList()
                    : context.Books.Include(b => b.Author).Include(b => b.Type).Where(b => b.BookStatus == true).OrderBy(b => b.BookID).Where(filter).ToList();
            }
        }

        public List<Book> GetAllFK(Expression<Func<Book, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null
                    ? context.Books.Include(b => b.Author).Include(b => b.Type).OrderBy(b => b.BookID).ToList()
                    : context.Books.Include(b => b.Author).Include(b => b.Type).OrderBy(b => b.BookID).Where(filter).ToList();
            }
        }
    }
}
