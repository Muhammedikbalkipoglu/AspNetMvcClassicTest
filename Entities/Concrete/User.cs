using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Surname { get; set; }
        [StringLength(300)]
        public string UserName { get; set; }
        public string Hashpassword { get; set; }
        public string Saltpassword { get; set; }
    }
}
