using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticketswap.Models;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.Text;
using ticketswap.ViewModels;
namespace ticketswap.Controllers

{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["USER_ID"] == null)
            {
                return RedirectToAction("Login", "USER");
            }
            System.Diagnostics.Debug.WriteLine("testing12221: " + Session["ORDER_ID"]);
            int USER_ID;
            USER_ID = Convert.ToInt32(Session["USER_ID"]);
            var user = new userViewModel(USER_ID, Convert.ToInt32(Session["ORDER_ID"]));

            ViewBag.User = user;

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            return View(user);
            //return Content("user info:" + user.USER_FNAME + " " + user.USER_LNAME);
            
        }


        // GET: USER/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(FormCollection collection)
        {
            System.Diagnostics.Debug.WriteLine("testing: " + Convert.ToString(Request.Form["USER_EMAIL"]));
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
                    System.Diagnostics.Debug.WriteLine("testing: 1111");
                }
                // Fetch the user info by their id
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT USER_ID, USER_PASSWORD FROM [USER] WHERE USER_EMAIL=@email");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, myConnection))
                {
                    command.Parameters.AddWithValue("@email", Convert.ToString(Request.Form["USER_EMAIL"]));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string password_sql;
                            password_sql = reader["USER_PASSWORD"].ToString();
                            string user_id_sql;
                            user_id_sql = reader["USER_ID"].ToString();
                            System.Diagnostics.Debug.WriteLine(password_sql);
                            if (password_sql == Convert.ToString(Request.Form["USER_PASSWORD"]))
                            {
                                Session["USER_ID"] = Convert.ToInt32(user_id_sql);
                                if (Session["ORDER_ID"] != null)
                                {
                                    return RedirectToAction("Index", "ORDER");
                                }
                                return RedirectToAction("Index", "USER");
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("test 33");
                                return RedirectToAction("Login", "USER");
                            }
                        }
                        System.Diagnostics.Debug.WriteLine("testing 44");
                        return RedirectToAction("Login", "USER");
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return RedirectToAction("Login", "USER");
            }

        }


        // GET: User/Edit/5
        public ActionResult Edit()
        {
            int USER_ID;
            USER_ID = Convert.ToInt32(Session["USER_ID"]);          
            var user = new USER(USER_ID);
            ViewBag.User = user;
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                int USER_ID;
                USER_ID = Convert.ToInt32(Session["USER_ID"]);
                var user = new USER(USER_ID);
                if (collection["USER_LNAME"] != user.USER_LNAME)
                {
                    user.SET_USER_LNAME(collection["USER_LNAME"]);
                }
                if (collection["USER_FNAME"] != user.USER_FNAME)
                {
                    user.SET_USER_FNAME(collection["USER_FNAME"]);
                }
                if (collection["USER_EMAIL"] != user.USER_EMAIL)
                {
                    user.SET_USER_EMAIL(collection["USER_EMAIL"]);
                }
                if (collection["USER_PASSWORD"] != user.USER_PASSWORD)
                {
                    user.SET_USER_PASSWORD(collection["USER_PASSWORD"]);
                }

                return RedirectToAction("Index", "USER");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            int USER_ID;
            USER_ID = Convert.ToInt32(Session["USER_ID"]);
            var user = new USER(USER_ID);
            ViewBag.User = user;
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                try
                {
                    _ = Model1.Update("INSERT INTO [USER] (USER_FNAME, USER_LNAME, USER_EMAIL, USER_PASSWORD, USER_CAN_SELL) VALUES ('"+
                        collection["USER_FNAME"]+"', '"+collection["USER_LNAME"]+"', '"+collection["USER_EMAIL"]+"', '"+collection["USER_PASSWORD"]+"', 'YES')");
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }

                return RedirectToAction("Login", "USER");
            }
            catch
            {
                return View();
            }
        }

        /*
        

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
    */
    }
}
