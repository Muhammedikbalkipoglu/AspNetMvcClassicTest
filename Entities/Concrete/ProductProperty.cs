using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductProperty
    {
        [Key]
        public int ProductPropertyId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }



    }
}
