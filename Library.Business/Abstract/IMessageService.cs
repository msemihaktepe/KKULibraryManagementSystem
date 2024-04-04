using Library.Business.Results;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        IResult TDelete(Message message);
        IDataResult<List<Message>> TGetAll();
        IDataResult<List<Message>> TGetAllFK();        
        IDataResult<List<Message>> TGetAllByStatusFK();
        IDataResult<List<Message>> TGetAllByStatus2FK();         
       
    }
}
