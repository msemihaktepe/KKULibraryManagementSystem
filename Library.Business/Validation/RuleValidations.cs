using FluentValidation;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validation
{
    public class RuleValidations : AbstractValidator<Rule>
    {
        public RuleValidations()
        {
            RuleFor(rule => rule.RuleDesc).NotEmpty().WithMessage("Kural Giriş Alanı Boş Bırakılmamalıdır..");
            RuleFor(rule => rule.RuleDesc).MinimumLength(10).WithMessage("Kural Giriş Alanı Minimum 10 Karakterli Olmalıdır.");
        }
    }
}
