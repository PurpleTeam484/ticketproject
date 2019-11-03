namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;


    [Table("TICKET")]
    public partial class TICKET
    {

        public TICKET(int TICKET_ID)
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
                sb.Append("SELECT * FROM [TICKET] WHERE TICKET_ID=" + TICKET_ID.ToString());
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, myConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.TICKET_ID = TICKET_ID;
                            this.EVENT_ID = Convert.ToInt32(reader["EVENT_ID"]);
                            this.SELLER_ID = Convert.ToInt32(reader["SELLER_ID"]);
                            this.TICKET_DATE = reader["TICKET_DATE"].ToString();
                            this.TICKET_FILE_LOCATION = reader["TICKET_FILE_LOCATION"].ToString();
                            this.TICKET_PRICE = reader["TICKET_PRICE"].ToString();
                            this.TICKET_ACTIVE = reader["TICKET_ACTIVE"].ToString();
                            this.TICKET_SOLD = reader["TICKET_SOLD"].ToString();
                        }
                    }
                }
            }
            catch
            {
                this.TICKET_ID = 0;
            }
        }


        [Key]
        public int TICKET_ID { get; set; }

        public int? EVENT_ID { get; set; }

        public bool SET_EVENT_ID(int? EVENT_ID)
        {
            try
            {
                Model1.Update("UPDATE [TICKET] SET EVENT_ID=" + EVENT_ID + " WHERE TICKET_ID=" + this.TICKET_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public int? SELLER_ID { get; set; }

        [StringLength(50)]
        public string TICKET_DATE { get; set; }
        public bool SET_TICKET_DATE(string TICKET_DATE)
        {
            try
            {
                Model1.Update("UPDATE [TICKET] SET TICKET_DATE='" + TICKET_DATE.ToString() + "' WHERE TICKET_ID=" + this.TICKET_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(155)]
        public string TICKET_FILE_LOCATION { get; set; }

        public bool SET_TICKET_FILE_LOCATION(string TICKET_FILE_LOCATION)
        {
            try
            {
                Model1.Update("UPDATE [TICKET] SET TICKET_FILE_LOCATION='" + TICKET_FILE_LOCATION.ToString() + "' WHERE TICKET_ID=" + this.TICKET_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(10)]
        public string TICKET_PRICE { get; set; }

        public bool SET_TICKET_PRICE(string TICKET_PRICE)
        {
            try
            {
                Model1.Update("UPDATE [TICKET] SET TICKET_PRICE='" + TICKET_PRICE.ToString() + "' WHERE TICKET_ID=" + this.TICKET_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(5)]
        public string TICKET_ACTIVE { get; set; }

        public bool SET_TICKET_ACTIVE(string TICKET_ACTIVE)
        {
            try
            {
                Model1.Update("UPDATE [TICKET] SET TICKET_ACTIVE='" + TICKET_ACTIVE.ToString() + "' WHERE TICKET_ID=" + this.TICKET_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(5)]
        public string TICKET_SOLD { get; set; }

        public bool SET_TICKET_SOLD(string TICKET_SOLD)
        {
            try
            {
                Model1.Update("UPDATE [TICKET] SET TICKET_SOLD='" + TICKET_SOLD.ToString() + "' WHERE TICKET_ID=" + this.TICKET_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

    }
}
