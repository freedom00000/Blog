using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RecentCommentsItemModel
    {
        public RecentCommentsItemModel(string title, DateTime date)
        {
            this.Text = title;
            this.Date = date;
        }
            public string Text { get; set; }
            public string URL { get; set; }
            public DateTime Date { get; set; }
        }
   
}