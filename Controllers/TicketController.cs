using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketswap.Models;

namespace ticketswap.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (Session["USER_ID"] == null)
            {
                return RedirectToAction("Login", "USER");
            }
            try
            {
                // TODO: Add insert logic here

                Model1.Update("INSERT INTO [TICKET] (EVENT_ID, TICKET_DATE, SELLER_ID, TICKET_FILE_LOCATION, TICKET_PRICE, TICKET_SOLD, TICKET_ACTIVE) VALUES ('" +
                            Session["EVENT_ID"].ToString() + "', 'empty', '" + Session["USER_ID"].ToString() + "', 'empty', '" + collection["TICKET_PRICE"] + "', 'NO', 'YES')");
                return RedirectToAction("View", "EVENT", new { id = Convert.ToInt32(Session["EVENT_ID"]) });
            }
            catch
            {
                return RedirectToAction("Index", "USER");
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
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

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
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
