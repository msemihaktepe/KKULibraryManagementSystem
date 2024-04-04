using Library.Business.Abstract;
using Library.Business.Results;
using Library.DataAccess.Abstract;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concrete
{
    public class BorrowedBookManager : IBorrowedBookService
    {
        private readonly IBorrowedBookDal _borrowedBookDal;

        public BorrowedBookManager(IBorrowedBookDal borrowedBookDal)
        {
            _borrowedBookDal = borrowedBookDal;
        }

        public IResult TAdd(BorrowedBook borrowedBook)
        {
            _borrowedBookDal.Add(borrowedBook);
            return new SuccessResult();
        }

        public IResult TDelete(BorrowedBook borrowedBook)
        {
            _borrowedBookDal.Delete(borrowedBook);
            return new SuccessResult();
        }

        public IDataResult<List<BorrowedBook>> TGetAllByFK()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBookDal.GetAllFK());
        }

        public IDataResult<List<BorrowedBook>> TGetAllByStatus()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBookDal.GetAll(b => b.BorrowedBookStatus == true));
        }

        public IDataResult<List<BorrowedBook>> TGetAllByStatus2FK()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBookDal.GetAllByStasus2());
        }

        public IDataResult<List<BorrowedBook>> TGetAllByStatusFK()
        {
            return new SuccessDataResult<List<BorrowedBook>>(_borrowedBookDal.GetAllByStasus());
        }

        public IDataResult<BorrowedBook> TGetById(int id)
        {
            return new SuccessDataResult<BorrowedBook>(_borrowedBookDal.Get(b => b.BorrowedBookID == id));
        }

        public IDataResult<BorrowedBook> TGetUserId(int userID)
        {
            var result = _borrowedBookDal.GetFK(userID);
            if (result == null)
            {
                return new ErrorDataResult<BorrowedBook>(result);
            }
            return new SuccessDataResult<BorrowedBook>(result);
        }

        public IResult TUpdate(BorrowedBook borrowedBook)
        {
            _borrowedBookDal.Update(borrowedBook);
            return new SuccessResult();
        }
    }
}
