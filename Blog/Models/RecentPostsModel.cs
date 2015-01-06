using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RecentPostsModel
    {
        public RecentPostsModel()
        {
            Items = new List<RecentPostsItemModel>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT * FROM POST 
                                     WHERE PostID > 0
                                ORDER by DateCreated  DESC"))
                {
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            reader.Read();
                                Items.Add(new RecentPostsItemModel(
                                    reader["Title"].ToString(),
                                    DateTime.Parse(reader["DateCreated"].ToString())
                                    ));
                        }
                    }
                }
            }
        }
        public List<RecentPostsItemModel> Items { get; set; }
    }
}