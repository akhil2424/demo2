using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo2.Models
{
    public class Productindex
    {
        public Productindex()
        {
            Product = new Models.Product();
       
        }
        public demo2.Models.Product Product { get; set; }
        public IEnumerable<demo2.Models.Product> Products{ get; set; }
    }
}