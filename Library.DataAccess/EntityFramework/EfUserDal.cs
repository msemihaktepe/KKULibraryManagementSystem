using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete;
using Library.DataAccess.Repositories;
using Library.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.EntityFramework
{
    public class EfUserDal : GenericRepository<User, Context>, IUserDal
    {
        public List<User> GetAllByStasus()
        {
            using (var context = new Context())
            {
                return context.Users.Include(u => u.Position).Where(u => u.UserStatus == true).OrderBy(u => u.UserID).ToList();
            }
        }

        public User GetUserName(string userName)
        {
            using (var context = new Context())
            {
                return context.Users.Include(u => u.Position).FirstOrDefault(u => u.UserName == userName);
            }
        }

        public List<User> GetAllFK()
        {
            using (var context = new Context())
            {
                return context.Users.Include(u => u.Position).OrderBy(u => u.UserID).ToList();
            }
        }
    }
}
