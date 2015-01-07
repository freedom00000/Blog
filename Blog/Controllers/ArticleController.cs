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
    public class ArticleController : Controller
    {

        public ActionResult Recent(int? i)
        {

            var model = new RecentPostsModel(i);
            return View(model);

        }
    }
}
