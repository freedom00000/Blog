using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Blog.Repository
{
    public class CountriesRepository
    {
        public static readonly ICollection<string> Countries =
    new Collection<string> { "Russia", "Belarus", "Ukraine" };
    }
}