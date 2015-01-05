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
            RecentComment = new RecentDataModel();
            RecentPosts = new RecentDataModel();
        }
        public RecentDataModel RecentPosts { get; set; }
        public RecentDataModel RecentComment { get; set; }
    }
}