using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.Abstract
{
    public interface IProductPropertyService
    {
        List<ProductProperty> GetList();
        void ProductPropertyAdd(ProductProperty productProperty);
        ProductProperty GetById(int id);
        void ProductPropertyDelete(ProductProperty productProperty);
        void ProductPropertyUpdate(ProductProperty productProperty);
        ProductProperty GetByProductId(int id);
    }
}
