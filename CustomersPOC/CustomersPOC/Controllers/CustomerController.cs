using CustomersPOC.Models.EntityFramework;
using CustomersPOC.Vievmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomersPOC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomersEntities2 db = new CustomersEntities2();
        public ActionResult Index()
        {
            var model = db.customers.ToList();
            var city = db.city.ToList();
            var district = db.district.ToList();
            ViewBag.city = city;
            ViewBag.district = district;
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new SehirViewModel()
            {
                cityId = db.city.ToList(),
                districtId = db.district.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(customers customer)
        {
            if(customer.customerId==0)
            {
                db.customers.Add(customer);
                
            }
            else
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }

        public ActionResult Guncelle(int id)
        {
            var model = new SehirViewModel()
            {
                cityId = db.city.ToList(),
                districtId = db.district.ToList(),
                customer = db.customers.Find(id)
            };
            return View("Ekle", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecek = db.customers.Find(id);
            if (silinecek == null)
                return HttpNotFound();
            db.customers.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index","Customer");
        }

    }
}