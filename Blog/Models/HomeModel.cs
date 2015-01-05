using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class HomeModel : LoyoutModel
    {
        public HomeModel()
        {
            Article = new ArticleModel();

        }
        public ArticleModel Article { get; set; }

    }
}