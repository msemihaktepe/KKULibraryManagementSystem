using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface IBookDal : IGenericDal<Book>
    {
        List<Book> GetAllFK(Expression<Func<Book, bool>> filter = null);
        List<Book> GetAllByStasus(Expression<Func<Book, bool>> filter = null);
    }
}
