using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class DelPosts
    {
        public void DelPost(string title)
        {
            List<string> commentsID = new List<string>();
            string postID = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"select Post.PostId
                                                    from Comment
                                                    INNER JOIN Post ON Comment.PostID = Post.PostId
                                                    where Post.Title = @Title
                                                    group by Post.PostId"))
                     {

                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("Title", title));
                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                                
                                  postID = dataReader["PostID"].ToString();
                                  
                        }
                    }
                    connection.Close();
                }
                using (var sqlCommand = new SqlCommand(@"delete from Comment where PostID = @PostID"))
                {
                    if (postID != null)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("PostID", postID));
                        sqlCommand.Connection = connection;
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                using (var command2 = new SqlCommand(@"select PostID from Post where Title = @Title"))
                {

                    command2.Connection = connection;
                    connection.Open();
                    command2.Parameters.Add(new SqlParameter("Title", title));
                    using (var dataReader = command2.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {

                            postID = dataReader["PostID"].ToString();

                        }
                    }
                    connection.Close();
                }

                using (var sqlCommand2 = new SqlCommand(@"delete from Post where PostID = @PostID"))
                {
                    sqlCommand2.Parameters.Add(new SqlParameter("PostID", postID));
                    sqlCommand2.Connection = connection;
                    connection.Open();
                    sqlCommand2.ExecuteNonQuery();
                }
            }
        }
    }
}
