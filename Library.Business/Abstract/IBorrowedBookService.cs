using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IBorrowedBookService : IGenericService<BorrowedBook>
    {
        IResult TDelete(BorrowedBook borrowedBook);
        IDataResult<List<BorrowedBook>> TGetAllByFK();
        IDataResult<List<BorrowedBook>> TGetAllByStatusFK();
        IDataResult<List<BorrowedBook>> TGetAllByStatus2FK();
        IDataResult<List<BorrowedBook>> TGetAllByStatus();        
        IDataResult<BorrowedBook> TGetUserId(int userID);
    }
}
