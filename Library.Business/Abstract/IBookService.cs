using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IBookService : IGenericService<Book>
    {
        IResult TDelete(Book book);
        IDataResult<List<Book>> TGetAllByStatus();
        IDataResult<List<Book>> TGetAllByStatusFK();
        IDataResult<List<Book>> TGetAllSearch(string searchText);               
        IDataResult<int> TNumberOfBooksAuthor(int authorID);
        IDataResult<int> TNumberOfBooksType(int typeID);
    }
}
