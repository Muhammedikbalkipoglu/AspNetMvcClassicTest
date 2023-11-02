using Businneses.Abstract;
using DataAccesses.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Businneses.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            string salt = "test";
            string saltPassword = HashPassword(user.Saltpassword + salt);
            user.Saltpassword = saltPassword;
            user.Hashpassword = HashPassword(saltPassword);
            _userDal.Insert(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int id)
        {
            return _userDal.Get(x => x.UserId == id);
        }

        public List<User> GetList()
        {
            return _userDal.List();
        }

        public void Update(User user)
        {
            string salt = "test";
            string saltPassword = HashPassword(user.Saltpassword + salt);
            user.Saltpassword = saltPassword;
            user.Hashpassword = HashPassword(saltPassword);
            _userDal.Update(user);
        }

        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedpassword);
        }

        public User GetUserByUser(string userName, string passwordHash)
        {
            return _userDal.Get(x => x.UserName == userName && x.Hashpassword == passwordHash);
        }
    }
}
