using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.Repositories;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.EntityFramework
{
    public class EfRuleDal : GenericRepository<Rule, Context>, IRuleDal
    {
    }
}
