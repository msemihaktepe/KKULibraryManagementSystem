using FluentValidation;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Library.Entity.Concrete.Type;

namespace Library.Business.Validation
{
    public class TypeValidations : AbstractValidator<Type>
    {
        public TypeValidations()
        {
            RuleFor(type => type.TypeName).NotEmpty().WithMessage("Tür İsmi Alanı Boş Bırakılmamalıdır.");
            RuleFor(type => type.TypeName).MinimumLength(2).WithMessage("Tür İsmi Alanı Minimum 2 Karakterli Olmalıdır.");
        }
    }
}
