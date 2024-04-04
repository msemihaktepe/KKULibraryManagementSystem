using FluentValidation;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validation
{
    public class AuthorValidations : AbstractValidator<Author>
    {
        public AuthorValidations()
        {
            RuleFor(author => author.AuthorFirstName).NotEmpty().WithMessage("Yazar İsmi Boş Bırakılmamalıdır..");
            RuleFor(author => author.AuthorFirstName).MinimumLength(3).WithMessage("Yazar İsmi Minimum 3 karakter içermelidir.");

            RuleFor(author => author.AuthorLastName).NotEmpty().WithMessage("Yazarın Soyismi Boş Bırakılmamalıdır.");
            RuleFor(author => author.AuthorLastName).MinimumLength(2).WithMessage("Yazar Soyismi Minimum 2 karakter içermelidir.");
        }
    }
}
