using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Adınızı Boş Geçemezsiniz");
            RuleFor(c => c.Surname).NotEmpty().WithMessage("Soyadınız Boş Geçemezsiniz");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Kullanıcı Adınızı Boş Geçemezsiniz");
            RuleFor(c => c.Saltpassword).NotEmpty().WithMessage("Lütfen Şifre Belirleyiniz");
            RuleFor(c => c.Saltpassword).MinimumLength(3).WithMessage("Şifre En Az 3 Karakter Olmalı");
        }
    }
}
