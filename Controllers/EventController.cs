using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Text;

namespace ticketswap.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Order(int id)
        {
            Session["ORDER_ID"] = id;
            return RedirectToAction("index", "ORDER");
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
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

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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
        // GET: Event/List
        public ActionResult list()
        {

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "it484.database.windows.net";
                builder.UserID = "krandall";
                builder.Password = "Epicdata123!";
                builder.InitialCatalog = "it484";

                SqlConnection myConnection = new SqlConnection(builder.ConnectionString);

                try
                {
                    myConnection.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine("error happened");
                }
                StringBuilder sb = new StringBuilder();

                System.Diagnostics.Debug.WriteLine(Request.QueryString["search"]);
                if (Request.QueryString["search"]!=null)
                {

                    sb.Append("SELECT * FROM [EVENT] WHERE LOWER(EVENT_STATE)='"+ Request.QueryString["search"].ToLower()+"'");
                }
                else
                {
                    sb.Append("SELECT * FROM [EVENT]");
                }
                // Fetch the user info by their id
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, myConnection))
                {
                    //command.Parameters.AddWithValue("@time", Convert.ToString(Request.Form["time"]));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            List<ViewModels.eventViewModel> model = new List<ViewModels.eventViewModel>();

                            while (reader.Read())
                            {
                                var details = new ViewModels.eventViewModel();
                                details.EVENT_ID = (Int32)reader["EVENT_ID"];
                                details.EVENT_DATE = (string)reader["EVENT_DATE"];
                                details.EVENT_TIME = (string)reader["EVENT_TIME"];
                                details.EVENT_VENUE = (string)reader["EVENT_VENUE"];
                                details.EVENT_ADDRESS = (string)reader["EVENT_ADDRESS"];
                                details.EVENT_CITY = (string)reader["EVENT_CITY"];
                                details.EVENT_STATE = (string)reader["EVENT_STATE"];
                                details.EVENT_ZIP = (Int32)reader["EVENT_ZIP"];
                                details.EVENT_COUNTRY = (string)reader["EVENT_COUNTRY"];
                                details.EVENT_ICON_LOCATION = (string)reader["EVENT_ICON_LOCATION"];
                                details.EVENT_DESCRIPTION = (string)reader["EVENT_DESCRIPTION"];
                                details.CATEGORY_ID = (Int32)reader["CATEGORY_ID"];
                                model.Add(details);
                            }
                            reader.Close();
                            IEnumerable<ViewModels.eventViewModel> enum_model = model as IEnumerable<ViewModels.eventViewModel>;
                            return View(model);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return View();
            }
            return View();
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
