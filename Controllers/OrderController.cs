using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ticketswap.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            if (Session["USER_ID"] == null)
            {
                return RedirectToAction("Login", "USER");
            }
            else
            {
                if (1==1)//Session["ORDER_ID"]==null)
                {
                    Session["ORDER_ID"] = 25;
                    ViewModels.orderViewModel model = new ViewModels.orderViewModel(25);
                    return View(model);
                }
                else
                {
                    ViewModels.orderViewModel model = new ViewModels.orderViewModel(Convert.ToInt32(Session["ORDER_ID"]));
                    var details = new ViewModels.eventViewModel();
                    return View(model);
                }
            }
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            if (Session["USER_ID"] == null)
            {
                return RedirectToAction("Login", "USER");
            }
            else
            {
                ViewModels.orderViewModel model = new ViewModels.orderViewModel(id);
                return View(model);
            }
        }
        public ActionResult Confirmation()
        {
            ViewModels.orderViewModel model = new ViewModels.orderViewModel();
            var details = new ViewModels.eventViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Confirmation(int id, FormCollection collection)
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


        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
