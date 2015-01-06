using Blog.Models;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index (string title)
        {
            if (title == null)
            {
                title = "Thsi is my first title";
            
            }
            var readers = new DataBase();
            return View(readers.GetArticleModel(title));
        }

        [HttpPost]
        public ActionResult Index(AddCommentModel model)
        {
            var title = "Thsi is my first title";
            if(model.Comment != null && ModelState.IsValid)
            {
                var readers = new DataBase();
                readers.AddComment(title, model.Comment, DateTime.Now.ToString());
                ModelState.Clear();
                return View(readers.GetArticleModel(title));
            }

            return View(model);
        }
    }
}
