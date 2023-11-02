using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(c => c.ParentCategoryId).NotEmpty().WithMessage("Üst Kategori Alanı Yok ise 0 Sayısını Yazın");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalı");
            RuleFor(c => c.CategoryName).MaximumLength(100).WithMessage("Kategori Adı En Fazla 100 Karakter Olmalı");
        }
    }
}
