using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RecentCommentsItemModel
    {
        public RecentCommentsItemModel(string title, DateTime date, string id)
        {
            this.Text = title;
            this.Date = date;
            this.CommentID = id;
        }
            public string Text { get; set; }
            public string URL { get; set; }
            public string CommentID { get; set; }
            public DateTime Date { get; set; }
        }
   
}