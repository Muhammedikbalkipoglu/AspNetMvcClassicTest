using Businneses.Concrete;
using DataAccesses.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcClassicTest.Controllers
{
    public class ProductUIController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ProductPropertyManager ppm = new ProductPropertyManager(new EfProductProperty());
        CurrencyManager currencyManager = new CurrencyManager();

        // GET: ProductUI

        [HttpGet]
        public ActionResult Index()
        {

            decimal dolar = currencyManager.Currency();
            ViewBag.dolar = dolar;

            var productProperty = ppm.GetList();
            ViewBag.listProductProperty = productProperty;

            var products = pm.GetList();
            return View(products);
        }

        [HttpPost]
        public ActionResult Index(string categoryName)
        {

            decimal dolar = currencyManager.Currency();
            ViewBag.dolar = dolar;

            var category = cm.GetCategoryByName(categoryName);
            var products = pm.GetListByCategoryId(category.CategoryId);

            return View(products);
        }
    }
}