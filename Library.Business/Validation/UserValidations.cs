using FluentValidation;
using Library.Business.Concrete;
using Library.DataAccess.EntityFramework;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validation
{
    public class UserValidations : AbstractValidator<User>
    {
        public UserValidations()
        {

            RuleFor(user => user.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılmamalıdır.");
            RuleFor(user => user.UserName).GreaterThan("5").WithMessage("Kullanıcı Adı Minimum 6 Karakterli Olmalıdır.");
            RuleFor(user => user.UserName).Must(UniqueUsername).WithMessage("Kullanıcı Adı Mevcut.");


            RuleFor(user => user.UserFirstName).NotEmpty().WithMessage("İsim Alanı Boş Bırakılmamalıdır.");
            RuleFor(user => user.UserFirstName).MinimumLength(3).WithMessage("İsim Minimum 3 Karakterli Olmalıdır.");


            RuleFor(user => user.UserLastName).NotEmpty().WithMessage("Soyisim Alanı Boş Bırakılmamalıdır.");
            RuleFor(user => user.UserLastName).MinimumLength(2).WithMessage("Soyisim Minimum 2 Karakterli Olmalıdır.");


            RuleFor(user => user.UserPassword).NotEmpty().WithMessage("Şifre Alanı Boş Bırakılmamalıdır.");
            RuleFor(user => user.UserPassword).GreaterThan("5").WithMessage("Şifre en az 6 Karakterli Olmalıdır.");


            RuleFor(user => user.UserMail).NotEmpty().WithMessage("Email Alanı Boş Bırakılmamalıdır.");
            RuleFor(user => user.UserMail).EmailAddress().WithMessage("Email Adresini Hatalı Girdiniz.");
        }

        private bool UniqueUsername(string arg)
        {
            var userManager = new UserManager(new EfUserDal());
            return userManager.TCheckUsername(arg).Success;
        }
    }
}

