using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UserModel
    {
        public ICollection<string> Countries
        {
            get
            {
                return Repository.CountriesRepository.Countries;
            }
        }

        public HttpPostedFileWrapper Avatar { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        public string Username { get; set; }
    }
}