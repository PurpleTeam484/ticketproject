namespace ticketswap.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Text;

    public static class Model1
    {
        public static SqlDataReader Select(string QUERY_SQL)
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
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            // Fetch the user info by their id
            StringBuilder sb = new StringBuilder();
            sb.Append(QUERY_SQL);
            String sql = sb.ToString();
            using (SqlCommand command = new SqlCommand(sql, myConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader;
                }
            }
        }



        public static bool Update(string QUERY_SQL)
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
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            // Fetch the user info by their id
            StringBuilder sb = new StringBuilder();
            sb.Append(QUERY_SQL);
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, myConnection))
            {
                command.ExecuteNonQuery();
                return true;
            }
        }





    }
}
