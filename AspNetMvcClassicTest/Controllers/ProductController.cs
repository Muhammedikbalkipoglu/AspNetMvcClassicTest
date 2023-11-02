using Businneses.Concrete;
using DataAccesses.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcClassicTest.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CurrencyManager currencyManager = new CurrencyManager();
        // GET: Product

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            decimal dolar = currencyManager.Currency();
            ViewBag.dolar = dolar;

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

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> categories = (from x in
                                                   cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.vlc = categories;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            pm.ProductAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = pm.GetById(id);
            pm.ProductDelete(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SelectListItem> categories = (from x in
                                                   cm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.vlc = categories;
            var product = pm.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            pm.ProductUpdate(p);
            return RedirectToAction("Index");
        }
    }
}