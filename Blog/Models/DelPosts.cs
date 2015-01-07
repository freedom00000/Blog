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
                using (var command = new SqlCommand(@"select  Title, Post.PostID, CommentID
                                                                        from Comment
                                                                        INNER JOIN Post ON Comment.PostID = Post.PostID
                                                                           where Title = @title
                                                                        order by CommentID desc"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                                  commentsID.Add( dataReader["CommentID"].ToString());
                                  postID = dataReader["PostID"].ToString();
                                  
                        }
                    }
                }
                using (var sqlCommand2 = new SqlCommand(@"delete from Post where PostId = @PostID"))
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
