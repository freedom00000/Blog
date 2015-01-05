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
            Collection<string> comments = null;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Post WHERE title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));

                    using (var dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            postModel = new PostModel(
                                dataReader["Title"].ToString(),
                                dataReader["Body"].ToString(),
                                DateTime.Parse(dataReader["DateCreated"].ToString())
                                );
                        }
                    }
                }

                using (var command = new SqlCommand("SELECT Comment.* FROM Comment INNER JOIN Post ON Comment.PostID = Post.PostID WHERE Post.Title = @title"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("title", title));
                    comments = new Collection<string>();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            comments.Add(dataReader["Body"].ToString());
                        }
                    }
                }

                return new ArticleModel(postModel, comments);
            }
        }

        public void AddComment(string title, string comment)
        {
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString);
            var sqlCommand = new SqlCommand(@"INSERT INTO Comment
	            SELECT PostID, @comment AS MyPost 
                FROM Post 
                WHERE Title = @title");
            sqlCommand.Parameters.Add(new SqlParameter("comment", comment));
            sqlCommand.Parameters.Add(new SqlParameter("title", title));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Dispose();
        }
    }
}