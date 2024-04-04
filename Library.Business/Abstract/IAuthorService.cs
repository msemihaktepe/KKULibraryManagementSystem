using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IAuthorService : IGenericService<Author>
    {
        IDataResult<List<Author>> TGetAllByStatus();
    }
}
