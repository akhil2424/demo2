using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace demo2.Models
{
    public class DatabaseContext:DbContext
    {   //Connection String
        public DatabaseContext() : base("Data Source=LAPTOP-20VVHH05;Initial Catalog=akh;Integrated Security=True") => this.Configuration.LazyLoadingEnabled = false;
        public DbSet<Product> Products { get; set; }
        public DbSet<User>Users { get; set; }
    }
}