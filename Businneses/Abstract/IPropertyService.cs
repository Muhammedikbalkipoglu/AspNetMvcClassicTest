using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.Abstract
{
    public interface IPropertyService
    {

        List<Property> GetList();
        void PropertyAdd(Property property);
        Property GetById(int id);
        void PropertyDelete(Property property);
        void PropertyUpdate(Property property);
    }
}
