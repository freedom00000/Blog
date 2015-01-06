using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class LoyoutModel
    {

        public LoyoutModel()
        {
            RecentComment = new RecentPostsModel();
            RecentPosts = new RecentPostsModel();
        }
        public RecentPostsModel RecentPosts { get; set; }
        public RecentPostsModel RecentComment { get; set; }
    }
}