using Businneses.Abstract;
using DataAccesses.Abstract;
using DataAccesses.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.Concrete
{
    public class ProductPropertyManager : IProductPropertyService
    {
        IProductPropertyDal _productPropertyDal;

        public ProductPropertyManager(IProductPropertyDal productPropertyDal)
        {
            _productPropertyDal = productPropertyDal;
        }
        public ProductProperty GetById(int id)
        {
            return _productPropertyDal.Get(x => x.ProductPropertyId == id);
        }

        public ProductProperty GetByProductId(int id)
        {
            return _productPropertyDal.Get(x => x.ProductId == id);
        }

        public List<ProductProperty> GetList()
        {
            return _productPropertyDal.List();
        }

        public void ProductPropertyAdd(ProductProperty productProperty)
        {
            _productPropertyDal.Insert(productProperty);
        }

        public void ProductPropertyDelete(ProductProperty productProperty)
        {
            _productPropertyDal.Delete(productProperty);
        }

        public void ProductPropertyUpdate(ProductProperty productProperty)
        {
            _productPropertyDal.Update(productProperty);
        }
    }
}
