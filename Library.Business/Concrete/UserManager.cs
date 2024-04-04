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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult TAdd(User user)
        {
            user.UserFirstName.ToUpper();
            user.UserLastName.ToUpper();            
            try
            {
                _userDal.Add(user);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
        }

        public IDataResult<User> TCheckUser(User user)
        {
            var result = _userDal.Get(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword && u.UserStatus == true);
            if (result != null)
            {
                return new SuccessDataResult<User>(result);
               
            }
            return new ErrorDataResult<User>(result);
        }

        public IResult TCheckUsername(string userName)
        {
            var result = _userDal.Get(u => u.UserName == userName);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<User>> TGetAllByStatus()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.UserStatus == true));
        }

        public IDataResult<List<User>> TGetAllByStatusFK()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAllByStasus());
        }

        public IDataResult<List<User>> TGetAllFK()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAllFK());
        }

        public IDataResult<User> TGetById(int id)
        {
            var result = _userDal.Get(u => u.UserID == id);
            if (result == null)
            {
                return new ErrorDataResult<User>(result);
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> TGetByUsername(string userName)
        {
            return new SuccessDataResult<User>(_userDal.GetUserName(userName));
        }

        public IDataResult<int> TNumberOfPositionUsers(int positionID)
        {
            return new SuccessDataResult<int>(_userDal.GetAll(u => u.PositionID == positionID && u.UserStatus == true).Count);
        }

        public IResult TUpdate(User user)
        {
            user.UserFirstName.ToUpper();
            user.UserLastName.ToUpper();            
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
