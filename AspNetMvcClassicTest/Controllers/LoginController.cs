using Businneses.Concrete;
using DataAccesses.Concrete;
using DataAccesses.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspNetMvcClassicTest.Controllers
{
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            string salt = "test";
            string passwordSalt = um.HashPassword(u.Saltpassword + salt);
            string passwordHash = um.HashPassword(passwordSalt);

            var user = um.GetUserByUser(u.UserName, passwordHash);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = user.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}