using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RecentDataModel
    {
        public RecentDataModel()
        {
            Items = new Collection<RecentDataItemModel>();
            Items.Add(new RecentDataItemModel());
            Items.Add(new RecentDataItemModel());
            Items.Add(new RecentDataItemModel());
        }
        public ICollection<RecentDataItemModel> Items { get; set; }
    }
}