namespace ticketswap.ViewModels
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;


    public class orderViewModel : DbContext
    {
        // Your context has been configured to use a 'orderViewModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ticketswap.ViewModels.orderViewModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'orderViewModel' 
        // connection string in the application configuration file.
        public orderViewModel()
        {
            this.ORDER_ID = 0;
            this.EVENT_NAME = "Maverick Hockey Game";
            this.TICKET_PRICE = "69";
            this.EVENT_DATE = "12/18/2019";
            this.EVENT_TIME = "3:19 AM";
            this.EVENT_VENUE = "Verizon Center";
            this.EVENT_ADDRESS = "131 Main ST.";
            this.EVENT_CITY = "Mankato";
            this.EVENT_STATE = "MN";
            this.EVENT_DESCRIPTION = "A hockey game between MSU and UMD";
            this.USER_LNAME = "John";
            this.USER_FNAME = "Smith";
            this.CATEGORY_NAME = "Sporting Event";
        }
        
        public orderViewModel(int ORDER_ID)
            : base("name=orderViewModel")
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
                    sb.Append("SELECT T.TICKET_PRICE, E.EVENT_DATE, E.EVENT_TIME, E.EVENT_VENUE, E.EVENT_ADDRESS,E.EVENT_CITY,E.EVENT_STATE,E.EVENT_DESCRIPTION,E.CATEGORY_ID,U.USER_LNAME,U.USER_FNAME,C.CATEGORY_NAME FROM [TICKET] T JOIN [USER] U ON T.SELLER_ID=U.USER_ID JOIN [EVENT] E ON E.EVENT_ID=T.EVENT_ID JOIN [CATEGORY] C ON C.CATEGORY_ID=E.CATEGORY_ID WHERE TICKET_ID=" + ORDER_ID.ToString());
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, myConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.ORDER_ID = ORDER_ID;
                                this.EVENT_NAME = "Maverick Hockey Game";
                                this.TICKET_PRICE = reader["TICKET_PRICE"].ToString();
                                this.EVENT_DATE = reader["EVENT_DATE"].ToString();
                                this.EVENT_TIME = reader["EVENT_TIME"].ToString();
                                this.EVENT_VENUE = reader["EVENT_VENUE"].ToString();
                                this.EVENT_ADDRESS = reader["EVENT_ADDRESS"].ToString();
                                this.EVENT_CITY = reader["EVENT_CITY"].ToString();
                                this.EVENT_STATE = reader["EVENT_STATE"].ToString();
                                this.EVENT_DESCRIPTION = reader["EVENT_DESCRIPTION"].ToString();
                                this.USER_LNAME = reader["USER_LNAME"].ToString();
                                this.USER_FNAME = reader["USER_FNAME"].ToString();
                                this.CATEGORY_NAME = reader["CATEGORY_NAME"].ToString();
                            }
                        }
                    }
                }
                catch
                {
                    this.ORDER_ID = 0;
                }
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
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
        public string USER_LNAME { get; set; }
        public string USER_FNAME { get; set; }
        public string CATEGORY_NAME { get; set; }





    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}