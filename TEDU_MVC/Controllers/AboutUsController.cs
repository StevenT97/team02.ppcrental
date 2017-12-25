using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.FrameWork;

namespace TEDU_MVC.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        DemoPPCRentalEntities model = new DemoPPCRentalEntities();
       
        public ActionResult Index(int id=1)
        {

            var about = model.About_Us.Find(2);
            return View(about);
        }

        // GET: AboutUs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AboutUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutUs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutUs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AboutUs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AboutUs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AboutUs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
