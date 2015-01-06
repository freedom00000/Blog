using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CommentItemModel
    {
        private readonly string body;
        private readonly DateTime dateCreated;

        public CommentItemModel( string body, DateTime dateCreated)
        {
           
            this.body = body;
            this.dateCreated = dateCreated;
        }
        
        public string Body
        {
            get
            {
                return body;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
        }
    }
}