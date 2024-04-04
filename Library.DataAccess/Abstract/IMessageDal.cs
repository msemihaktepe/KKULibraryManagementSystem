using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetAllFK();
        List<Message> GetAllByStasus();
        List<Message> GetAllByStasus2();
    }
}
