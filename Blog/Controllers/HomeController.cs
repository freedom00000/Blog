using Blog.Models;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            if(model.Comment != null )
            {
            var readers = new DataBase();
            readers.AddComment(model.title, model.Comment, DateTime.Now.ToString());
            ModelState.Clear();
            this.title = model.title.ToString();
            }
            return RedirectToAction("Index", new { titel = this.title });
        }

        public ActionResult AddPost(AddPostModel model)
        {
            if (model.title != null)
            {
                var readers = new DataBase();
                readers.AddPost(model.title, model.body, DateTime.Now.ToString());
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
                return View();
            
        }

        public ActionResult Enter(string Name, string Password)
        {
            if (Name == "admin" && Password == "adminforwin")
            {
                FormsAuthentication.SetAuthCookie("Admin", false);
            }
            return View();
        }
        //  [HttpGet]
        public ActionResult DelPost(string Name)
        {
            DelPosts obj = new DelPosts();
            obj.DelPost(Name.Replace("_", " "));
            return RedirectToAction("Index");
        }

        public ActionResult DelComment(string id)
        {
            DelComments obj = new DelComments();
            
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                using (var command2 = new SqlCommand(@"select PostID from Comment where CommentID =@id"))
                {

                    command2.Connection = connection;
                    connection.Open();
                    command2.Parameters.Add(new SqlParameter("id", id));
                    using (var dataReader = command2.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {

                            this.title = dataReader["PostID"].ToString();

                        }
                    }
                    connection.Close();
                }
                using (var command2 = new SqlCommand(@"select Title from Post where PostID =@id"))
                {

                    command2.Connection = connection;
                    connection.Open();
                    command2.Parameters.Add(new SqlParameter("id", this.title));
                    using (var dataReader = command2.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {

                            this.title = dataReader["Title"].ToString();

                        }
                    }
                    connection.Close();
                }
            }
            obj.DelPost(id);
            return RedirectToAction("Index", new { titel = this.title });
        }

        public ActionResult ComLink(string titel)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mssql"].ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"select PostID from comment where CommentID = @id"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("id", titel));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            title = reader["PostID"].ToString();

                        }
                    }
                }
                using (var command = new SqlCommand(@"select Title from Post where PostID = @id"))
                {
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("id", title));
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            title = reader["Title"].ToString();

                        }
                    }
                }
            }
            var readers = new DataBase();
            return View(readers.GetArticleModel(title));

        }
    }
}