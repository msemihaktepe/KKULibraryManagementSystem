using Library.Business.Abstract;
using Library.Business.Results;
using Library.DataAccess.Abstract;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Position = Library.Entity.Concrete.Position;

namespace Library.Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;

        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }
        

        public IResult TAdd(Position position)
        {
            position.PositionName.ToUpper();
            _positionDal.Add(position);
            return new SuccessResult();
        }

        public IDataResult<List<Position>> TGetAllByStatus()
        {
            return new SuccessDataResult<List<Position>>(_positionDal.GetAll(p => p.PositionStatus == true));
        }

        public IDataResult<Position> TGetById(int id)
        {
            return new SuccessDataResult<Position>(_positionDal.Get(p => p.PositionID == id));
        }

        public IDataResult<Position> TGetByName(string positionName)
        {
            return new SuccessDataResult<Position>(_positionDal.Get(p => p.PositionName.Contains(positionName)));
        }

        public IResult TUpdate(Position position)
        {
            position.PositionName.ToUpper();
            _positionDal.Update(position);
            return new SuccessResult();
        }
       
    }
}
