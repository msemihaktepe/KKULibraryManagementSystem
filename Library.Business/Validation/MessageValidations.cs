using FluentValidation;
using Library.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Validation
{
    public class MessageValidations : AbstractValidator<Message>
    {
        public MessageValidations()
        {
            RuleFor(message => message.MessageText).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılmamalı.");
            RuleFor(message => message.MessageText).MinimumLength(30).WithMessage("Mesaj Alanı Minimum 30 Karakterli Olmalıdır.");
            RuleFor(message => message.MessageText).MaximumLength(500).WithMessage("Maksimum 500 Karakter Girişi Yapabilirsiniz.");
        }
    }
}
