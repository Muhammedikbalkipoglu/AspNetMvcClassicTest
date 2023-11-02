using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(c => c.ProductName).NotEmpty().WithMessage("Ürün Adını Boş Geçemezsiniz");
            RuleFor(c => c.CategoryId).NotEmpty().WithMessage("Ürün Kategorisi giriniz");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Ürün Fiyatı Giriniz");
            RuleFor(c => c.ImagePath).NotEmpty().WithMessage("Ürün Resim Yolunu Giriniz");
            
        }
    }
}
