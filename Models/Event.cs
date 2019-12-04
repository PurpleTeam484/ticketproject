namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;


    [Table("EVENT")]
    public class EVENT
    {
        // constructer method
        public EVENT(int EVENT_ID)
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
                sb.Append("SELECT * FROM [EVENT] WHERE EVENT_ID=" + EVENT_ID.ToString());
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, myConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.EVENT_ID = EVENT_ID;
                            this.EVENT_NAME = reader["EVENT_NAME"].ToString();
                            this.EVENT_DATE = reader["EVENT_DATE"].ToString();
                            this.EVENT_TIME = reader["EVENT_TIME"].ToString();
                            this.EVENT_VENUE = reader["EVENT_VENUE"].ToString();
                            this.EVENT_ADDRESS = reader["EVENT_ADDRESS"].ToString();
                            this.EVENT_CITY = reader["EVENT_CITY"].ToString();
                            this.EVENT_STATE = reader["EVENT_STATE"].ToString();
                            this.EVENT_ZIP = Convert.ToInt32(reader["EVENT_ZIP"]);
                            this.EVENT_COUNTRY = reader["EVENT_COUNTRY"].ToString();
                            this.EVENT_ICON_LOCATION = reader["EVENT_ICON_LOCATION"].ToString();
                            this.EVENT_DESCRIPTION = reader["EVENT_DESCRIPTION"].ToString();
                            this.CATEGORY_ID = Convert.ToInt32(reader["CATEGORY_ID"]);
                        }
                    }
                }
            }
            catch
            {
                this.EVENT_ID = 0;
            }
        }


        [Key]
        public int EVENT_ID { get; set; }

        [StringLength(50)]
        public string EVENT_DATE { get; set; }

        public bool SET_EVENT_DATE(string EVENT_DATE)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_DATE='" + EVENT_DATE.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public string EVENT_NAME { get; set; }

        [StringLength(50)]
        public string EVENT_TIME { get; set; }

        public bool SET_EVENT_TIME(string EVENT_TIME)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_TIME='" + EVENT_TIME.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }


        [StringLength(50)]
        public string EVENT_VENUE { get; set; }

        public bool SET_EVENT_VENUE(string EVENT_VENUE)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_VENUE='" + EVENT_VENUE.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(50)]
        public string EVENT_ADDRESS { get; set; }

        public bool SET_EVENT_ADDRESS(string EVENT_ADDRESS)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_ADDRESS='" + EVENT_ADDRESS.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(50)]
        public string EVENT_CITY { get; set; }

        public bool SET_EVENT_CITY(string EVENT_CITY)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_CITY='" + EVENT_CITY.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }


        [StringLength(3)]
        public string EVENT_STATE { get; set; }

        public bool SET_EVENT_STATE(string EVENT_STATE)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_STATE='" + EVENT_STATE.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }


        public int? EVENT_ZIP { get; set; }

        public bool SET_EVENT_ZIP(int? EVENT_ZIP)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_ZIP='" + EVENT_ZIP + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(50)]
        public string EVENT_COUNTRY { get; set; }

        public bool SET_EVENT_COUNTRY(string EVENT_COUNTRY)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_COUNTRY='" + EVENT_COUNTRY.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }


        [StringLength(50)]
        public string EVENT_ICON_LOCATION { get; set; }

        public bool SET_EVENT_ICON_LOCATION(string EVENT_ICON_LOCATION)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_ICON_LOCATION='" + EVENT_ICON_LOCATION.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(1000)]
        public string EVENT_DESCRIPTION { get; set; }

        public bool SET_EVENT_DESCRIPTION(string EVENT_DESCRIPTION)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET EVENT_DESCRIPTION='" + EVENT_DESCRIPTION.ToString() + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public int? CATEGORY_ID { get; set; }

        public bool SET_CATEGORY_ID(int? CATEGORY_ID)
        {
            try
            {
                Model1.Update("UPDATE [EVENT] SET CATEGORY_ID='" + CATEGORY_ID + "' WHERE EVENT_ID=" + this.EVENT_ID.ToString());
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
