using Blog.Models;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

         public ActionResult Recent()
        {
            var model = new RecentCommentsModel();
            return View(model);
        }



    }
}
