using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        IDataResult<List<User>> TGetAllFK();
        IDataResult<List<User>> TGetAllByStatus();
        IDataResult<List<User>> TGetAllByStatusFK();
        IDataResult<User> TCheckUser(User user);
        IResult TCheckUsername(string userName);       
        IDataResult<int> TNumberOfPositionUsers(int positionID);
        IDataResult<User> TGetByUsername(string userName);
    }
}
