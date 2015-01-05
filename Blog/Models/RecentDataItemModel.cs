using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RecentDataItemModel
    {
        public RecentDataItemModel()
        {
            Text = "SOME recent data TEXT";
            URL = "http://google.com";
            Date = DateTime.Now.AddDays(-1);
        }
        public string Text { get; set;}
        public string URL { get; set; }
        public DateTime Date { get; set; }
    }
}