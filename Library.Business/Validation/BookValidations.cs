using FluentValidation;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validation
{
    public class BookValidations : AbstractValidator<Book>
    {
        public BookValidations()
        {
            RuleFor(book => book.BookName).NotEmpty().WithMessage("Kitap İsmi Boş Bırakılamaz.");
            RuleFor(book => book.BookName).MinimumLength(2).WithMessage("Kitap İsmi Minimum 2 Karakterden Oluşmalıdır.");

            RuleFor(book => book.NumberOfPage).NotEmpty().WithMessage("Sayfa Sayısı Boş Bırakılamaz.");
            RuleFor(book => book.NumberOfPage).LessThanOrEqualTo(2000).WithMessage("Sayfa Sayısı Maksimum 2000 Olmalı");
        }
    }
}
