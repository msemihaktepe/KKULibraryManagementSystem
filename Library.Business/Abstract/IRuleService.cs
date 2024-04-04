using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IRuleService : IGenericService<Rule>
    {
        IDataResult<List<Rule>> TGetAllByStatus();
    }
}
