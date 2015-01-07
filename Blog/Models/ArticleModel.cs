using Blog.Repository;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleModel
    {
        private readonly PostModel post;
        private readonly List<CommentItemModel> comments;

        public ArticleModel(PostModel post, List<CommentItemModel> comment)
        {
            this.post = post;
            this.comments = comment;
        }

        public PostModel Post
        {
            get
            {
                return post;
            }
        }

        public List<CommentItemModel> Comments
        {
            get
            {
                return comments;
            }
        }
    }
}