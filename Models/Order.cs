namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;

    [Table("ORDER")]
    public class ORDER
    {

        public ORDER(int ORDER_ID)
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
                sb.Append("SELECT * FROM [ORDER] WHERE ORDER_ID=" + ORDER_ID.ToString());
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, myConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.ORDER_ID = ORDER_ID;
                            this.TICKET_ID = Convert.ToInt32(reader["TICKET_ID"]);
                            this.SELLER_ID = Convert.ToInt32(reader["SELLER_ID"]);
                            this.BUYER_ID = Convert.ToInt32(reader["BUYER_ID"]);
                            this.ORDER_DATE = reader["ORDER_DATE"].ToString();
                            this.ORDER_SUBTOTAL = reader["ORDER_SUBTOTAL"].ToString();
                            this.ORDER_STATUS = reader["ORDER_STATUS"].ToString();
                        }
                    }
                }
            }
            catch
            {
                this.ORDER_ID = 0;
            }
        }


        [Key]
        public int ORDER_ID { get; set; }

        public int? TICKET_ID { get; set; }


        public bool SET_TICKET_ID(int? TICKET_ID)
        {
            try
            {
                Model1.Update("UPDATE [ORDER] SET TICKET_ID=" + TICKET_ID + " WHERE ORDER_ID=" + this.ORDER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public int? SELLER_ID { get; set; }

        public bool SET_SELLER_ID(int? SELLER_ID)
        {
            try
            {
                Model1.Update("UPDATE [ORDER] SET SELLER_ID=" + SELLER_ID + " WHERE ORDER_ID=" + this.ORDER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        public int? BUYER_ID { get; set; }

        public bool SET_BUYER_ID(int? BUYER_ID)
        {
            try
            {
                Model1.Update("UPDATE [ORDER] SET BUYER_ID=" + BUYER_ID + " WHERE ORDER_ID=" + this.ORDER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(30)]
        public string ORDER_DATE { get; set; }

        public bool SET_ORDER_DATE(string ORDER_DATE)
        {
            try
            {
                Model1.Update("UPDATE [ORDER] SET ORDER_DATE='" + ORDER_DATE.ToString() + "' WHERE ORDER_ID=" + this.ORDER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(10)]
        public string ORDER_SUBTOTAL { get; set; }

        public bool SET_ORDER_SUBTOTAL(string ORDER_SUBTOTAL)
        {
            try
            {
                Model1.Update("UPDATE [ORDER] SET ORDER_SUBTOTAL='" + ORDER_SUBTOTAL.ToString() + "' WHERE ORDER_ID=" + this.ORDER_ID.ToString());
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }

        [StringLength(30)]
        public string ORDER_STATUS { get; set; }

        public bool SET_ORDER_STATUS(string ORDER_STATUS)
        {
            try
            {
                Model1.Update("UPDATE [ORDER] SET ORDER_STATUS='" + ORDER_STATUS.ToString() + "' WHERE ORDER_ID=" + this.ORDER_ID.ToString());
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
