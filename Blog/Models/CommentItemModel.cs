using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class CommentItemModel
    {
        private readonly string body;
        private readonly string commentID;
        private readonly DateTime dateCreated;

        public CommentItemModel( string body, DateTime dateCreated, string id)
        {
            this.body = body;
            this.dateCreated = dateCreated;
            commentID = id;
        }
        
        public string Body
        {
            get
            {
                return body;
            }
        }
        public string CommentID
        {
            get
            {
                return commentID;
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