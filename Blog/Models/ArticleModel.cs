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
        private readonly ICollection<string> comments;

        public ArticleModel()
        {
            post = new PostModel(
                "Тут заголовок поста",
                "<p>Нейкий пост.................</p>",
                DateTime.Now);
            comments = CommentsRepository.Comments;
        }

        public ArticleModel(PostModel post, ICollection<string> comments)
        {
            this.post = post;
            this.comments = comments;
        }

        public PostModel Post
        {
            get
            {
                return post;
            }
        }

        public ICollection<string> Comments
        {
            get
            {
                return comments;
            }
        }

        public AddCommentModel NewComment { get; set; }
    }
}