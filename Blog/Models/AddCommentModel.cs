using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class AddCommentModel
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}