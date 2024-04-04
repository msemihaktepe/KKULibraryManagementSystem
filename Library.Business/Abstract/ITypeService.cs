using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Library.Entity.Concrete.Type;

namespace Library.Business.Abstract
{
    public interface ITypeService : IGenericService<Entity.Concrete.Type>
    {
        IDataResult<List<Type>> TGetAllByStatus();
    }
}
