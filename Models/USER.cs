namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;

    [Table("USER")]
    
    public class USER
    {
        //TODO: add constructor method that selects on user_id
        public USER(int USER_ID)
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
                sb.Append("SELECT * FROM [USER] WHERE USER_ID="+USER_ID.ToString());
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
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [StringLength(20)]
        public string USER_FNAME { get; set; }

        public bool SET_USER_FNAME(string NEW_FNAME)
        {
            try
            {
                Model1.Update("UPDATE [USER] SET USER_FNAME='" + NEW_FNAME.ToString() + "' WHERE USER_ID=" + this.USER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(20)]
        public string USER_LNAME { get; set; }

        public bool SET_USER_LNAME(string NEW_LNAME)
        {
            try
            {
                Model1.Update("UPDATE [USER] SET USER_LNAME='" + NEW_LNAME.ToString() + "' WHERE USER_ID=" + this.USER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(35)]
        public string USER_EMAIL { get; set; }

        public bool SET_USER_EMAIL(string NEW_EMAIL)
        {
            try
            {
                Model1.Update("UPDATE [USER] SET USER_EMAIL='" + NEW_EMAIL.ToString() + "' WHERE USER_ID=" + this.USER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(100)]
        public string USER_PASSWORD { get; set; }

        public bool SET_USER_PASSWORD(string NEW_PASSWORD)
        {
            try
            {
                Model1.Update("UPDATE [USER] SET USER_PASSWORD='" + NEW_PASSWORD.ToString() + "' WHERE USER_ID=" + this.USER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(4)]
        public string USER_CAN_SELL { get; set; }

        public bool SET_USER_CAN_SELL(string NEW_SELL)
        {
            try
            {
                Model1.Update("UPDATE [USER] SET USER_CAN_SELL='" + NEW_SELL.ToString() + "' WHERE USER_ID=" + this.USER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public bool Logged_in { get; set; }

    }
}
