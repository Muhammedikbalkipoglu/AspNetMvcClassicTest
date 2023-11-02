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
    public class PropertyController : Controller
    {
        PropertyManager pmp = new PropertyManager(new EfPropertyDal());
        // GET: Property
        [Authorize]
        public ActionResult Index()
        {
            var properties = pmp.GetList();
            return View(properties);
        }

        [HttpGet]
        public ActionResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProperty(Property p)
        {
            pmp.PropertyAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProperty(int id)
        {
            var property = pmp.GetById(id);
            pmp.PropertyDelete(property);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProperty(int id)
        {
            var property = pmp.GetById(id);
            return View(property);
        }

        [HttpPost]
        public ActionResult EditProperty(Property p)
        {
            pmp.PropertyUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
