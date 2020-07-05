using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace demo2.Models
{
    public class Product
    {
        public int Productid { get; set; }
        [Required]
        public string Productname { get; set; }
       
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }

    }
}