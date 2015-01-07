using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class DelComments
    {
        public void DelPost(string id)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var sqlCommand = new SqlCommand(@"delete from Comment where CommentID = @CommentID"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("CommentID", id));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }
    }
}