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
    public class ProductPropertyController : Controller
    {
        ProductPropertyManager ppm = new ProductPropertyManager(new EfProductProperty());
        ProductManager pm = new ProductManager(new EfProductDal());
        PropertyManager pmp = new PropertyManager(new EfPropertyDal());

        [Authorize]
        // GET: ProductProperty
        public ActionResult Index()
        {
            
            var productProperty = ppm.GetList();
            return View(productProperty);
        }

        [HttpGet]
        public ActionResult AddProductProperty()
        {
            List<SelectListItem> products = (from x in
                                                   pm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ProductName,
                                                   Value = x.ProductId.ToString()
                                               }).ToList();
            List<SelectListItem> properties = (from x in
                                                   pmp.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Value.ToString(),
                                                 Value = x.PropertyId.ToString()
                                             }).ToList();
            ViewBag.vlc = products;
            ViewBag.dlc = properties;
            return View();
        }

        [HttpPost]
        public ActionResult AddProductProperty(ProductProperty p)
        {
            ppm.ProductPropertyAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProductProperty(int id)
        {
            var productProperty = ppm.GetById(id);
            ppm.ProductPropertyDelete(productProperty);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProductProperty(int id)
        {
            List<SelectListItem> products = (from x in
                                                   pm.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.ProductId.ToString()
                                             }).ToList();
            List<SelectListItem> properties = (from x in
                                                   pmp.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Value.ToString(),
                                                   Value = x.PropertyId.ToString()
                                               }).ToList();
            ViewBag.vlc = products;
            ViewBag.dlc = properties;

            var productProperties = ppm.GetById(id);
            return View(productProperties);
        }

        [HttpPost]
        public ActionResult EditProductProperty(ProductProperty p)
        {
            ppm.ProductPropertyUpdate(p);
            return RedirectToAction("Index");
        }

    }
}