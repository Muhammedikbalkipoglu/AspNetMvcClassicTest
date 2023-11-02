using DataAccesses.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesses.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        EfDbContext dbContext = new EfDbContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = dbContext.Set<T>();
        }

        public void Delete(T p)
        {
            var entity = dbContext.Entry(p);
            entity.State = EntityState.Deleted;
            //_object.Remove(p);
            dbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var entity = dbContext.Entry(p);
            entity.State = EntityState.Added;
            //_object.Add(p);
            dbContext.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var entity = dbContext.Entry(p);
            entity.State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
