using Businneses.Abstract;
using DataAccesses.Abstract;
using DataAccesses.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
          _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
           return _categoryDal.Get(x => x.CategoryId == id);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _categoryDal.Get(x => x.CategoryName == categoryName);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}
