using Library.Business.Abstract;
using Library.Business.Results;
using Library.DataAccess.Abstract;
using Library.DataAccess.EntityFramework;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Concrete
{
    public class RuleManager : IRuleService
    {
        private readonly IRuleDal _ruleDal;

        public RuleManager(IRuleDal ruleDal)
        {
            _ruleDal = ruleDal;
        }

        public IResult TAdd(Rule rule)
        {
            _ruleDal.Add(rule);
            return new SuccessResult();
        }

        public IDataResult<List<Rule>> TGetAllByStatus()
        {
            return new SuccessDataResult<List<Rule>>(_ruleDal.GetAll(t => t.RuleStatus == true).OrderBy(t => t.RuleID).ToList());
        }

        public IDataResult<Rule> TGetById(int id)
        {
            return new SuccessDataResult<Rule>(_ruleDal.Get(t => t.RuleID == id));
        }

        public IResult TUpdate(Rule rule)
        {
            _ruleDal.Update(rule);
            return new SuccessResult();
        }
    }
}
