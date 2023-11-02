using Businneses.Concrete;
using Businneses.ValidationRules;
using DataAccesses.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcClassicTest.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize]
        public ActionResult Index()
        {
            var categories = cm.GetList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                cm.CategoryAdd(c);
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

        public ActionResult DeleteCategory(int id)
        {
            var category = cm.GetById(id);
            cm.CategoryDelete(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = cm.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            cm.CategoryUpdate(c);
            return RedirectToAction("Index");
        }
    }
}