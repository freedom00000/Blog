using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RecentCommentsModel
    {
        public RecentCommentsModel()
        {
            Items = new List<RecentCommentsItemModel>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT * FROM Comment 
                                     WHERE PostID > 0
                                ORDER by DateCreated  DESC"))
                {
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if(reader.Read())
                            Items.Add(new RecentCommentsItemModel(
                                reader["Body"].ToString(),
                                DateTime.Parse(reader["DateCreated"].ToString()), 
                                reader["CommentID"].ToString())
                                );
                        }
                    }
                }
            }
        }
        public List<RecentCommentsItemModel> Items { get; set; }
    }
}