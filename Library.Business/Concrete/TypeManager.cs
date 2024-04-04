using Library.Business.Abstract;
using Library.Business.Results;
using Library.DataAccess.Abstract;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Library.Entity.Concrete.Type;

namespace Library.Business.Concrete
{
    public class TypeManager : ITypeService
    {
        private readonly ITypeDal _typeDal;

        public TypeManager(ITypeDal typeDal)
        {
            _typeDal = typeDal;
        }

        public IResult TAdd(Type type)
        {
            type.TypeName.ToUpper();
            _typeDal.Add(type);
            return new SuccessResult();
        }

        public IDataResult<List<Type>> TGetAllByStatus()
        {
            return new SuccessDataResult<List<Type>>(_typeDal.GetAll(t => t.TypeStatus == true).OrderBy(t => t.TypeID).ToList());
        }

        public IDataResult<Type> TGetById(int id)
        {
            return new SuccessDataResult<Type>(_typeDal.Get(t => t.TypeID == id));
        }

        public IResult TUpdate(Type type)
        {
            type.TypeName.ToUpper();
            _typeDal.Update(type);
            return new SuccessResult();
        }
    }
}
