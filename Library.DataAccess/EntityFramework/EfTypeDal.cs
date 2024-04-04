using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.Repositories;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Library.Entity.Concrete.Type;

namespace Library.DataAccess.EntityFramework
{
    public class EfTypeDal : GenericRepository<Type, Context> , ITypeDal
    {
        
    }
}
