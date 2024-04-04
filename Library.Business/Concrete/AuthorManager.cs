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
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IResult TAdd(Author author)
        {
            author.AuthorFirstName.ToUpper();
            author.AuthorLastName.ToUpper();
            _authorDal.Add(author);
            return new SuccessResult();
        }

        public IDataResult<List<Author>> TGetAllByStatus()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll(a => a.AuthorStatus == true));
        }

        public IDataResult<Author> TGetById(int id)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(a => a.AuthorID == id));
        }

        public IResult TUpdate(Author author)
        {
            author.AuthorFirstName.ToUpper();
            author.AuthorLastName.ToUpper();
            _authorDal.Update(author);
            return new SuccessResult();
        }
    }
}
