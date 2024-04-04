using FluentValidation;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validation
{
    public class PositionValidations : AbstractValidator<Position>
    {
        public PositionValidations()
        {
            RuleFor(position => position.PositionName).NotEmpty().WithMessage("Pozisyon İsmi Boş Bırakılmamalıdır..");
            RuleFor(position => position.PositionName).MinimumLength(3).WithMessage("Pozisyon İsmi Minimum 3 Karakterli Olmalıdır.");
        }
    }
}
