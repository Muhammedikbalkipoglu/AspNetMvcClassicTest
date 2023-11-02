using DataAccesses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesses.Concrete.Repositories
{
    public class CategoryRepo : ICategoryDal
    {
        EfDbContext dbContext = new EfDbContext();
        DbSet<Category> _categoryObj;
        public void Delete(Category c)
        {
            _categoryObj.Remove(c);
            dbContext.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category c)
        {
            _categoryObj.Add(c);
            dbContext.SaveChanges();
        }

        public List<Category> List()
        {
            throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> ListCategory()
        {
            return _categoryObj.ToList();
        }

        public void Update(Category c)
        {
            dbContext.SaveChanges();
        }
    }
}
