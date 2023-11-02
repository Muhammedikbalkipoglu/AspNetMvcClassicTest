using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businneses.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetById(int id);
        User GetUserByUser(string userName, string passwordHash);

    }
}
