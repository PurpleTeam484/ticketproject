using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.Text;

namespace ticketswap.ViewModels
{
    public class userViewModel
    {
        public userViewModel(int USER_ID,int? orderid)
        {
            // SELECT all data with this user_id
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
                // Fetch the user info by their id
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM [USER] WHERE USER_ID=" + USER_ID.ToString());
                String sql = sb.ToString();
                
                using (SqlCommand command = new SqlCommand(sql, myConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.USER_ID = USER_ID;
                            this.USER_FNAME = reader["USER_FNAME"].ToString();
                            this.USER_LNAME = reader["USER_LNAME"].ToString();
                            this.USER_EMAIL = reader["USER_EMAIL"].ToString();
                            this.USER_PASSWORD = reader["USER_PASSWORD"].ToString();
                            this.USER_CAN_SELL = reader["USER_CAN_SELL"].ToString();
                            this.Logged_in = true;

                        }
                    }
                }
            }
            catch
            {
                this.USER_ID = 0;
                this.USER_FNAME = "failed";
            }
            if(orderid == null)
            {
                //orderid = 0;
            }
            System.Diagnostics.Debug.WriteLine("testing111: " + orderid);
            //create the list of user orders, current tickets, disputes, etc for user.
            this.ORDER_ID = orderid;
            this.EVENT_NAME = "Maverick Hockey Game";
            this.TICKET_PRICE = "$69.00";
            this.EVENT_DATE = "12/18/2019";
            this.EVENT_TIME = "3:19 AM";
            this.EVENT_VENUE = "Verizon Center";
            this.EVENT_ADDRESS = "131 Main ST.";
            this.EVENT_CITY = "Mankato";
            this.EVENT_STATE = "MN";
            this.EVENT_DESCRIPTION = "A hockey game";
            this.USER_LNAME = "John";
            this.USER_FNAME = "Smith";
            this.CATEGORY_NAME = "Sporting Event";
        }

        public int USER_ID { get; set; }
        public bool Logged_in { get; set; }
        public string USER_FNAME { get; set; }
        public string USER_LNAME { get; set; }
        public string USER_EMAIL { get; set; }
        public string USER_PASSWORD { get; set; }
        public string USER_CAN_SELL { get; set; }
        public int? ORDER_ID { get; set; }
        public string EVENT_NAME { get; set; }
        public string TICKET_PRICE { get; set; }
        public string EVENT_DATE { get; set; }
        public string EVENT_TIME { get; set; }
        public string EVENT_VENUE { get; set; }
        public string EVENT_ADDRESS { get; set; }
        public string EVENT_CITY { get; set; }
        public string EVENT_STATE { get; set; }
        public string EVENT_DESCRIPTION { get; set; }
        public string CATEGORY_NAME { get; set; }


    }

}