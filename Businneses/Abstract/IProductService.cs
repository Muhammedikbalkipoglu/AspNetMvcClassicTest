using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        void ProductAdd(Product product);
        Product GetById(int id);
        void ProductDelete(Product product);
        void ProductUpdate(Product product);
        List<Product> GetListByCategoryId(int Id);
    }
}
