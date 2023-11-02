using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.ValidationRules
{
    public class PropertyValidator : AbstractValidator<Property>
    {
        public PropertyValidator() 
        {
            RuleFor(c => c.Key).NotEmpty().WithMessage("Özellik Numara Alanını Boş Geçemezsiniz");
            RuleFor(c => c.Value).NotEmpty().WithMessage("Özellik Adını Boş Geçemezsiniz");
           
        }
    }
}
