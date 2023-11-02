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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
        {
           var categories = categoryManager.GetList();
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
            CategoryValidator CategoryValidator = new CategoryValidator();
            ValidationResult validationResult = CategoryValidator.Validate(c);
            if (validationResult.IsValid)
            {
                categoryManager.CategoryAdd(c);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}