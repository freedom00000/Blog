using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Blog.Repository
{
    public class CommentsRepository
    {
        public static readonly ICollection<string> Comments = new Collection<string>();
    }
}