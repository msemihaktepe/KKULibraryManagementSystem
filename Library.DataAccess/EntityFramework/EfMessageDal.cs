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
    public class EfMessageDal : GenericRepository<Message, Context>, IMessageDal
    {
        public List<Message> GetAllByStasus()
        {
            using (var context = new Context())
            {
                return context.Messages.Include(m => m.User).Where(m => m.MessageStatus == true).OrderBy(m => m.MessageID).ToList();
            }
        }

        public List<Message> GetAllByStasus2()
        {
            using (var context = new Context())
            {
                return context.Messages.Include(m => m.User).Where(m => m.MessageStatus == false).OrderBy(m => m.MessageID).ToList();
            }
        }

        public List<Message> GetAllFK()
        {
            using (var context = new Context())
            {
                return context.Messages.Include(m => m.User).OrderBy(m => m.MessageID).ToList();
            }
        }
    }
}
