using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        public IResult TAdd(T t);        
        public IResult TUpdate(T t);
        public IDataResult<T> TGetById(int id);
    }
}
