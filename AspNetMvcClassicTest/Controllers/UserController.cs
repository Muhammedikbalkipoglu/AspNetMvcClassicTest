using Businneses.Concrete;
using Businneses.ValidationRules;
using DataAccesses.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspNetMvcClassicTest.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();
        // GET: User
        public ActionResult Index()
        {
            var users = um.GetList();
            return View(users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User u)
        {
            
            ValidationResult result = userValidator.Validate(u);
            if (result.IsValid)
            {
                um.Add(u);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = um.GetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            ValidationResult result = userValidator.Validate(u);
            if (result.IsValid)
            {
                um.Update(u);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public ActionResult DeleteUser(int id)
        {
            var user = um.GetById(id);
            um.Delete(user);
            return RedirectToAction("Index");
        }
    }
}