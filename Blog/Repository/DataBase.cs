using Blog.Models;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Repository
{
    public class DataBase
    {
        public ArticleModel GetArticleModel(string title)
        {
            PostModel postModel = null;
            List<CommentItemModel> comments = new List<CommentItemModel>();
            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM POST WHERE Title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            postModel = new PostModel(
                                reader["Title"].ToString(),
                                reader["Body"].ToString(),
                                DateTime.Parse(reader["DateCreated"].ToString())
                                );
                        }
                    }
                }
                using (var command = new SqlCommand("SELECT Comment.* FROM Comment INNER JOIN Post ON Comment.PostID = Post.PostID WHERE Post.Title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                                  comments.Add( new CommentItemModel(
                                  dataReader["Body"].ToString(),
                                  DateTime.Parse(dataReader["DateCreated"].ToString()),
                                  dataReader["CommentID"].ToString()
                                  ));
                        }
                    }
                }
            }

            return new ArticleModel(postModel, comments);
        }


        public void AddComment(string title, string comment, string date)
        {
          using(var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using(var sqlCommand = new SqlCommand(@"INSERT INTO Comment
	            SELECT PostID, @comment, @date AS MyPost 
                FROM Post 
                WHERE Title = @title"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("comment", comment));
                    sqlCommand.Parameters.Add(new SqlParameter("date", date));
                    sqlCommand.Parameters.Add(new SqlParameter("title", title));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void AddPost(string title, string body, string date)
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var sqlCommand = new SqlCommand("INSERT INTO Post VALUES(@title , @body , @date)"))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("body", body));
                    sqlCommand.Parameters.Add(new SqlParameter("date", date));
                    sqlCommand.Parameters.Add(new SqlParameter("title", title));
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}