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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult TAdd(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult();
        }

        public IResult TDelete(Message message)
        {
            _messageDal.Delete(message);
            return new SuccessResult();
        }

        public IDataResult<List<Message>> TGetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll());
        }

        public IDataResult<List<Message>> TGetAllByStatus2FK()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllByStasus2());
        }

        public IDataResult<List<Message>> TGetAllByStatusFK()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllByStasus());
        }

        public IDataResult<List<Message>> TGetAllFK()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAllFK());
        }

        public IDataResult<Message> TGetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(m => m.MessageID == id));
        }

        public IResult TUpdate(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult();
        }
    }
}
