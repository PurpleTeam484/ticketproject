using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ticketswap.Controllers
{
    public class DisputeController : Controller
    {
        // GET: Dispute
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dispute/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dispute/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dispute/Create
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

        // GET: Dispute/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dispute/Edit/5
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

        // GET: Dispute/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dispute/Delete/5
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
