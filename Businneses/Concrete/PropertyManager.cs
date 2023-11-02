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
    public class PropertyManager : IPropertyService
    {
        IPropertyDal _propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }
        public Property GetById(int id)
        {
            return _propertyDal.Get(x => x.PropertyId == id);
        }

        public List<Property> GetList()
        {
            return _propertyDal.List();
        }

        public void PropertyAdd(Property property)
        {
            _propertyDal.Insert(property);
        }

        public void PropertyDelete(Property property)
        {
            _propertyDal.Delete(property);
        }

        public void PropertyUpdate(Property property)
        {
            _propertyDal.Update(property);
        }
    }
}
