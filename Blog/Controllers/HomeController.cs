using Blog.Models;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public string title;
        [HttpGet]
        public ActionResult Index(string titel)
        {
            if (titel == null)
            {

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
                            if (reader.Read())
                            {
                                title = reader["Title"].ToString();

                            }
                        }
                    }

                }
            }
            else
                this.title = titel.Replace("_", " ");
            var readers = new DataBase();
            return View(readers.GetArticleModel(title));
        }

        // [HttpPost]
        public ActionResult Index(AddCommentModel model)
        {
            var readers = new DataBase();
            readers.AddComment(model.title, model.Comment, DateTime.Now.ToString());
            ModelState.Clear();
            this.title = model.title.ToString();
            string ss = model.ToString();
            return View(readers.GetArticleModel(title));


        }
       
        public ActionResult AddPost(AddPostModel model)
        {
            if (model.title != null)
            {
                var readers = new DataBase();
                readers.AddPost(model.title, model.body, DateTime.Now.ToString());
                ModelState.Clear();
            }
            return View();
        }
    }
}
