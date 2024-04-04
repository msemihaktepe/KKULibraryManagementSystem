using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface IBorrowedBookDal : IGenericDal<BorrowedBook>
    {
        List<BorrowedBook> GetAllFK();
        BorrowedBook GetFK(int userID);
        List<BorrowedBook> GetAllByStasus();
        List<BorrowedBook> GetAllByStasus2();
    }
}
