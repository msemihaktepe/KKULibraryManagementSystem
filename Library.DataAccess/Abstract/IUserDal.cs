using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        List<User> GetAllFK();
        List<User> GetAllByStasus();
        User GetUserName(string userName);
    }
}
