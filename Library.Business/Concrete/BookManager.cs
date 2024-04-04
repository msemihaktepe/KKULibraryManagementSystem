using Library.Business.Abstract;
using Library.Business.Results;
using Library.DataAccess.Abstract;
using Library.Entity.Concrete;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult TAdd(Book book)
        {
            book.BookName.ToUpper();
            _bookDal.Add(book);
            return new SuccessResult();
        }

        public IResult TDelete(Book book)
        {
            book.BookName.ToUpper();
            _bookDal.Delete(book);
            return new SuccessResult();
        }

        public IDataResult<List<Book>> TGetAllByStatus()
        {
            var result = _bookDal.GetAllFK(b => b.BookStatus == true);
            return new SuccessDataResult<List<Book>>(result);
        }

        public IDataResult<List<Book>> TGetAllByStatusFK()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAllByStasus());
        }

        public IDataResult<List<Book>> TGetAllSearch(string searchText)
        {
            var result = _bookDal.GetAllFK(b => b.BookStatus == true && (b.BookName.Contains(searchText.ToUpper()) || b.Author.AuthorFirstName.Contains(searchText.ToUpper()) || b.Author.AuthorLastName.Contains(searchText.ToUpper()) || b.Type.TypeName.Contains(searchText.ToUpper())));
            return new SuccessDataResult<List<Book>>(result);
        }

        public IDataResult<Book> TGetById(int id)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.BookID == id));
        }

        public IDataResult<int> TNumberOfBooksAuthor(int authorID)
        {
            return new SuccessDataResult<int>(_bookDal.GetAll(b => b.AuthorID == authorID && b.BookStatus == true).Count);
        }

        public IDataResult<int> TNumberOfBooksType(int typeID)
        {
            return new SuccessDataResult<int>(_bookDal.GetAll(b => b.TypeID == typeID && b.BookStatus == true).Count);
        }

        public IResult TUpdate(Book book)
        {
            book.BookName.ToUpper();
            _bookDal.Update(book);
            return new SuccessResult();
        }
    }
}
