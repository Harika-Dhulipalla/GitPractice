using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CateringProject.DAL;
using CateringProject.Models;

namespace CateringProject.Controllers
{
    public class HomePageController : Controller
    {
        CateringDB cater=new CateringDB();
        // GET: HomePage
        public ActionResult Index()
        {
            return View(cater.GetUsers());
        }
        public ActionResult Menu()
        {
            return View();
        }

        // GET: HomePage/Details/5
        public ActionResult Details(int id)
        {
            return View(cater.GetUsers().Find(pmodel => pmodel.UserId == id));
        }

        // GET: HomePage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomePage/Create
        [HttpPost]
        public ActionResult Create(OrderModel omodel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    cater.AddUser(omodel);
                    return RedirectToAction("ThankYou");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ThankYou()
        {
            return View();
        }
        // GET: HomePage/Edit/5
        public ActionResult Edit(int id)
        {
            return View(cater.GetUsers().Find(pmodel => pmodel.UserId == id));
        }

        // POST: HomePage/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderModel omodel)
        {
            try
            {
                // TODO: Add update logic here
                cater.UpdateUser(omodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomePage/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cater.GetUsers().Find(pmodel => pmodel.UserId == id));
        }

        // POST: HomePage/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OrderModel model)
        {
            try
            {
                // TODO: Add delete logic here
                cater.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
